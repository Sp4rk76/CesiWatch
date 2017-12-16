using System;
using CesiWatch.Models;

namespace CesiWatch
{
	public class WatchController
	{
		bool isRunning_ = false;
		private WatchModel watchModel_ = null;
		private WatchToJsonService watchToJsonService = null;

		public WatchController()
		{
			Console.WriteLine("HHHHHHHH");

			watchModel_ = new WatchModel("192.168.1.1", new Position(32,32), 1);
			watchToJsonService = new WatchToJsonService();

			watchToJsonService.Serialize(watchModel_);

			// Start();
		}

		public void Start()
		{
			isRunning_ = true;
			while (isRunning_)
			{
				Update();
			}
		}

		public void Update()
		{
			UpdateWatch();
			UpdateTeamData();
		}

		public void UpdateWatch()
		{
			/* Géolocalisation calculation here ! */
			// DoStuffAboutGeolocalisation();
			// var newPosition = new Position(positionX, positionY);

			/* Set new position */
			// watchModel_.setPosition(newPosition);
		}

		public void UpdateTeamData()
		{
			
		}

		public void Receive(String message)
		{

		}

		public void Send(String message)
		{

		}
	}
}
