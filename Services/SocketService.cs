using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using CesiWatch.Models;

namespace CesiWatch
{
	class SocketService
	{
		const int PORT_NUMBER = 15000;

		const string BROADCAST_IP = "255.255.255.255";

		Thread t = null;

		IAsyncResult asyncResult_ = null;

		private readonly UdpClient udpClient_ = new UdpClient(PORT_NUMBER);

		public void Start()
		{
			if (t != null)
			{
				throw new Exception("Already started, stop first");
			}

			Console.WriteLine("Started listening");
			StartListening();
		}

		private void StartListening()
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

		private void Receive(IAsyncResult asyncResult)
		{
			IPEndPoint ip = new IPEndPoint(IPAddress.Any, PORT_NUMBER); // Can receive from everyone

			byte[] bytes = udpClient_.EndReceive(asyncResult, ref ip);

			string json = Encoding.ASCII.GetString(bytes);

			// TODO: tests on received data !
			var watch = JsonService.Deserialize(json);

			// TODO: do stuff with received data

			StartListening();
		}

		public void Send(WatchModel watchModel)
		{
			UdpClient tmpClient = new UdpClient();

			IPEndPoint broadcastIp = new IPEndPoint(IPAddress.Broadcast, PORT_NUMBER); // Can send on broadcast

			watchModel.Counter += 1; // Update "TimeStamp" to check for changes on remote watches !

			string json = JsonService.Serialize(watchModel);

			byte[] buffer = Encoding.ASCII.GetBytes(json);

			tmpClient.Send(buffer, buffer.Length, broadcastIp);

			tmpClient.Close();
		}
	}
}