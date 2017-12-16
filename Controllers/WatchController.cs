using System;
using System.Collections.Generic;
using CesiWatch.Models;

namespace CesiWatch
{
	public class WatchController
	{
		bool isRunning_ = false;
		private WatchModel watchModel_ = null;
		private JsonService jsonService_ = null;

		private List<WatchModel> watches_ = null;

		public WatchController()
		{
			watches_ = new List<WatchModel>();

			jsonService_ = new JsonService();

			watchModel_ = new WatchModel("192.168.1.1", new Position(32,32), 1);

			watches_.Add(watchModel_);

			// DEBT: remove this, only for test purposes
			var json = jsonService_.Serialize(watchModel_);
			var watch = jsonService_.Deserialize(json);

			// TODO: implement Thread & Socket
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

		/* Receive json from network (Socket) */
		public void Receive()
		{
			var json = @"{ 'Address':'222','Position':{ 'X':32,'Y':32},'TeamId':1,'Counter':0}";
			var watch = watchToJsonService.Deserialize(json);

			// If watch's address is not in the watch list
				// Add watch to watch list

			// Else
				// If watch's address exists
					// Go to address in the watch list
						// If watch timespan (counter) is greater than the timespan from the watch list
						// Assign watch to watch list
		}

		/* Send watch data through network (Socket) */
		public void Send()
		{
			/// TODO: There is probably a simpler way to update this.
			/// For example, by not putting watchModel in the list..
			/// Because we only send our watch data

			// Increment the watch counter (timespan) by 1
			watchModel_.Counter += 1;

			// Find self watch in list
			//var thisWatch = watches_.Find(w => w.Address == watchModel_.Address);

			// Update self watch in the list
			// thisWatch.Counter = watchModel_.Counter;

			///---------------------------------------------------///

			var json = jsonService_.Serialize(watchModel_);

			// Trigger Socket Send
			// socket.write(json);
		}
	}
}
