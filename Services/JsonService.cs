using System;
using CesiWatch.Models;
using Newtonsoft.Json;

namespace CesiWatch
{
	public static class JsonService
	{
		public static String Serialize(WatchModel watchModel)
		{
			var json = JsonConvert.SerializeObject(watchModel);

			Console.WriteLine("Json for this watch: {0}", json);

			return json;
		}

		public static WatchModel Deserialize(String json)
		{
			var watch = JsonConvert.DeserializeObject<WatchModel>(json);

			Console.WriteLine("Address: {0}\nPosition: ({1};{2})\nTeamID: {3}\nCounter: {4}", watch.Address, watch.Position.X, watch.Position.Y, watch.TeamId, watch.Counter);

			return watch;
		}
	}
}