using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using CesiWatch.Models;
using Newtonsoft.Json;

namespace CesiWatch
{
	public class WatchController
	{
		const int PORT_NUMBER = 15000;

		const string BROADCAST_IP = "255.255.255.255";

		const int SLEEP_TIME_MS = 1000;

		private bool isPlaying = false;

		Thread threadReceive_ = null;

		Thread threadSend_ = null;

		IAsyncResult asyncResult_ = null;

		DateTime previousTime_ = DateTime.Now;

		private UdpClient udpClient_ = null;

		private WatchModel watchModel_ = null;

		public List<WatchModel> watches_ { get; set; }

	public WatchController()
		{
			watches_ = new List<WatchModel>();

			watchModel_ = new WatchModel("192.168.1.1", new Position(32, 32), 1);

            watches_.Add(watchModel_);

            udpClient_ = new UdpClient(PORT_NUMBER);
        }

        /** NICO's job here **/
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
            if(isPlaying == true)
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
			var watches = new JsonService().Deserialize(json);

			UpdateWatchList(watches);

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

			IPEndPoint broadcastIp = new IPEndPoint(IPAddress.Broadcast, PORT_NUMBER); // Can send on broadcast

			// Yep, you can serialize a whole list !
			string json = new JsonService().Serialize(watches_);

			byte[] buffer = Encoding.ASCII.GetBytes(json);

			tmpClient.Send(buffer, buffer.Length, broadcastIp);

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
					if (watch.Counter > findWatch.Counter)
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
