using System;
using System.Collections.Generic;
using CesiWatch.Models;
using Newtonsoft.Json;

namespace CesiWatch
{
	public static class JsonService
	{
		public static string Serialize(List<WatchModel> watches)
		{
			var json = JsonConvert.SerializeObject(watches, Formatting.Indented);

			Console.WriteLine("Json for this watch: {0}", json);

			return json;
		}

		public static List<WatchModel> Deserialize(string json)
		{
			var watches = JsonConvert.DeserializeObject<List<WatchModel>>(json);

			Console.WriteLine(watches);

			return watches;
		}
	}
}