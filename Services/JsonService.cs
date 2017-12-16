using System;
using CesiWatch.Models;
using Newtonsoft.Json;

namespace CesiWatch
{
	public class JsonService
	{
		public String Serialize(WatchModel watchModel)
		{
			var json = JsonConvert.SerializeObject(watchModel);

			Console.WriteLine("Json for this watch: {0}", json);

			return json;
		}

		public WatchModel Deserialize(String json)
		{
			var watch = JsonConvert.DeserializeObject<WatchModel>(json);

			Console.WriteLine("Address: {0}\nPosition: ({1};{2})\nTeamID: {3}\nCounter: {4}", watch.Address, watch.Position.X, watch.Position.Y, watch.TeamId, watch.Counter);

			return watch;
		}
	}
}