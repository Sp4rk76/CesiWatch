using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using CesiWatch.Models;
using Newtonsoft.Json;
using System.Net.NetworkInformation;

namespace CesiWatch
{
	public class WatchController
	{
		const int PORT_NUMBER = 15000;

		const string MULTICAST_IP = "239.0.0.222";

		const int SLEEP_TIME_MS = 1000;

		private bool isPlaying = false;

		private MainWindow mainWindow_ = null;

		Thread threadReceive_ = null;

		Thread threadSend_ = null;

		IAsyncResult asyncResult_ = null;

		DateTime previousTime_ = DateTime.Now;

		private UdpClient udpClient_ = null;

		private WatchModel watchModel_ = null;

		public WatchModel WatchModel
		{
			get { return watchModel_; }
			set { watchModel_ = value; }
		}

		public List<WatchModel> watches_ { get; set; }

		private String LocalIP = "unknown";

		public WatchController(MainWindow window)
		{
			udpClient_ = new UdpClient();

			NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface adapter in nics)
			{
				if (adapter.Name == "wlan0")
				{
					IPv4InterfaceProperties p = adapter.GetIPProperties().GetIPv4Properties();
					foreach (UnicastIPAddressInformation ip in adapter.GetIPProperties().UnicastAddresses)
					{
						if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
						{
							this.LocalIP = ip.Address.ToString();
							Console.WriteLine(ip.Address.ToString());
							break;
						}
					}
					//Console.WriteLine (adapter.GetIPProperties().);
					udpClient_.Client.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastInterface, (int)IPAddress.HostToNetworkOrder(p.Index));
					Console.WriteLine("assigned " + adapter.Name + " as multicast address : " + (int)IPAddress.HostToNetworkOrder(p.Index));
				}
			}

			IPEndPoint localEp;
			localEp = new IPEndPoint(IPAddress.Any, PORT_NUMBER);

			udpClient_.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
			udpClient_.ExclusiveAddressUse = false;
			udpClient_.Client.Bind(localEp);

			IPAddress multicastaddress = IPAddress.Parse(MULTICAST_IP);
			udpClient_.JoinMulticastGroup(multicastaddress);

			watches_ = new List<WatchModel>();

			watchModel_ = new WatchModel(LocalIP, new Position(32, 32), 1);

			watches_.Add(watchModel_);
		}

		public Position GetGeolocalizedPosition()
		{
			string latitude = string.Empty;
			string longitude = string.Empty;

			// Get Latitude && Longitude data from GPS sensor

			return LatLongToDecimal(latitude, longitude);
		}

		public Position LatLongToDecimal(string latitude, string longitude)
		{
			int x = 0, y = 0;

			// Do conversion stuff here !

			return new Position(x, y);
		}

		/** NICO's job here **/
		public void UpdateWatch()
		{
			/* Géolocalisation calculation here ! */
			watchModel_.Position = GetGeolocalizedPosition();

			/* Update our Watch's data in the list */
			watchModel_.Date = DateTime.Now;

			var watchIndex = watches_.FindIndex(w => w.Address == watchModel_.Address); // Find self watch in list

			watches_[watchIndex].Date = watchModel_.Date; // Update self watch in the list
		}

		public void Start()
		{
			if (isPlaying == true)
			{
				throw new Exception("Already playing, stop first");
			}

			if (threadReceive_ != null || threadSend_ != null)
			{
				throw new Exception("Already started, stop first");
			}

			isPlaying = true;

			threadSend_ = new Thread(new ThreadStart(QuerySend));

			threadSend_.Start();

			PrepareReceive();

			Console.WriteLine("Started listening");
		}

		public void PrepareReceive()
		{
			asyncResult_ = udpClient_.BeginReceive(Receive, new object());
		}

		public void Stop()
		{
			try
			{
				isPlaying = false;

				threadSend_.Join();
				threadReceive_.Join();

				threadSend_ = null;
				threadReceive_ = null;

				udpClient_.Close();
				udpClient_ = null;

				Console.WriteLine("Stopped listening");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		public void Receive(IAsyncResult asyncResult)
		{
			IPEndPoint ip = new IPEndPoint(IPAddress.Any, PORT_NUMBER); // Can receive from everyone

			byte[] bytes = udpClient_.EndReceive(asyncResult, ref ip);

			if (ip.Address.ToString() != LocalIP)
			{
				Console.WriteLine("listing from : " + ip.Address.ToString());
				string json = Encoding.ASCII.GetString(bytes);

				// TODO: tests on received data !
				var watches = new JsonService().Deserialize(json);
				UpdateWatchList(watches);
			}

			// (Re)Start listening to Receive data again
			PrepareReceive();
		}

		public void QuerySend()
		{
			do
			{
				Send();

				Thread.Sleep(SLEEP_TIME_MS);

			} while (isPlaying);

		}

		public void Send()
		{
			UpdateWatch();

			UdpClient tmpClient = new UdpClient();
			NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface adapter in nics)
			{
				if (adapter.Name == "wlan0")
				{
					IPv4InterfaceProperties p = adapter.GetIPProperties().GetIPv4Properties();
					tmpClient.Client.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastInterface, (int)IPAddress.HostToNetworkOrder(p.Index));
					//Console.WriteLine ("assigned " + adapter.Name + " as multicast address : " + (int)IPAddress.HostToNetworkOrder(p.Index));
				}
			}

			IPAddress multicastaddress = IPAddress.Parse(MULTICAST_IP);

			tmpClient.JoinMulticastGroup(multicastaddress);

			IPEndPoint multicastPoint = new IPEndPoint(multicastaddress, PORT_NUMBER); // Can send on broadcast

			// Yep, you can serialize a whole list !
			string json = new JsonService().Serialize(watches_);

			byte[] buffer = Encoding.ASCII.GetBytes(json);

			tmpClient.Send(buffer, buffer.Length, multicastPoint);

			tmpClient.Close();
		}

		public void UpdateWatchList(List<WatchModel> watches)
		{
			foreach (WatchModel watch in watches)
			{
				var findWatchTeam = watches_.Find(w => w.TeamId == watch.TeamId);
				if (findWatchTeam == null) // Not in this team
				{
					continue;
				}

				var findWatch = watches_.Find(w => w.Address == watch.Address);

				// If watch's address is not in the watch list
				if (findWatch == null)
				{
					// Add watch to watch list
					watches_.Add(watch);
				}
				else // existing watch was found
				{
					// If watch timespan (counter) is greater than the timespan from the watch list
					if (watch.Date > findWatch.Date)
					{
						// Update data
						var index = watches_.FindIndex(x => x.Address == watch.Address);
						watches_[index] = watch;
					}
				}
			}
		}
	}
}
