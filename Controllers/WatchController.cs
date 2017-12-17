using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using CesiWatch.Models;

namespace CesiWatch
{
	public class WatchController
	{
		const int PORT_NUMBER = 15000;

		const string BROADCAST_IP = "255.255.255.255";

		Thread thread_ = null;

		IAsyncResult asyncResult_ = null;

		private readonly UdpClient udpClient_ = null;

		private WatchModel watchModel_ = null;

		private List<WatchModel> watches_ = null;

		public WatchController()
		{
			udpClient_ = new UdpClient(PORT_NUMBER);

			watches_ = new List<WatchModel>();

			watchModel_ = new WatchModel("192.168.1.1", new Position(32, 32), 1);

			watches_.Add(watchModel_);
		}

		public void UpdateWatch()
		{
			/* Géolocalisation calculation here ! */
			// DoStuffAboutGeolocalisation();
			// var newPosition = new Position(positionX, positionY);

			/* Set new position */
			// watchModel_.setPosition(newPosition);

			/* Update our Watch's data in the list */
			watchModel_.Counter += 1; // Update "TimeStamp" to check for changes on remote watches !

			var thisWatch = watches_.Find(w => w.Address == watchModel_.Address); // Find self watch in list

			thisWatch.Counter = watchModel_.Counter; // Update self watch in the list
		}

		public void Start()
		{
			if (thread_ != null)
			{
				throw new Exception("Already started, stop first");
			}

			Console.WriteLine("Started listening");
			StartListening();
		}

		public void StartListening()
		{
			asyncResult_ = udpClient_.BeginReceive(Receive, new object());
		}

		public void Stop()
		{
			try
			{
				udpClient_.Close();
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

			string json = Encoding.ASCII.GetString(bytes);

			// TODO: tests on received data !
			var watch = JsonService.Deserialize(json);

			// TODO: do stuff with received data
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
				if (watch.Counter > findWatch.Counter)
				{
					// Update data
					var index = watches_.FindIndex(x => x.Address == watch.Address);
					watches_[index] = watch;
				}
			}

			// when something is Received, we Send our watch's data
			// foreach (var watchData in watches_)
			// {
			//  Send(watchData);
			// }

			// (Re)Start listening to Receive data again
			StartListening();
		}

		public void Send(WatchModel watchModel)
		{
			UpdateWatch();

			UdpClient tmpClient = new UdpClient();

			IPEndPoint broadcastIp = new IPEndPoint(IPAddress.Broadcast, PORT_NUMBER); // Can send on broadcast

			string json = JsonService.Serialize(watchModel);

			byte[] buffer = Encoding.ASCII.GetBytes(json);

			tmpClient.Send(buffer, buffer.Length, broadcastIp);

			tmpClient.Close();
		}
	}
}
