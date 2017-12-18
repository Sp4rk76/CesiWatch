using System;
using Newtonsoft.Json;

namespace CesiWatch.Models
{
	// A watch has:
	// - an address
	// - give its position
	// - belongs to a "team" (represented as an id)
	[JsonObject(MemberSerialization.OptIn)]
	public class WatchModel
	{
		private string playerName_;
		private string address_;
		private Position position_;
		private int teamId_;
		private int counter_;
		private DateTime date_;

		[JsonPropertyAttribute]
		public string PlayerName
		{
			get
			{
				return playerName_;
			}
			set
			{
				playerName_ = value;
			}
		}

		[JsonPropertyAttribute]
		public string Address
		{
			get
			{
				return address_;
			}
			set
			{
				address_ = value;
			}
		}

		[JsonPropertyAttribute]
		public Position Position
		{
			get
			{
				return position_;
			}
			set
			{
				position_ = value;
			}
		}

		[JsonPropertyAttribute]
		public int TeamId
		{
			get
			{
				return teamId_;
			}
			set
			{
				if (IsValid(value))
				{
					teamId_ = value;
				}
			}
		}

		[JsonPropertyAttribute]
		public int Counter
		{
			get
			{
				return counter_;
			}
			set
			{
				if (IsValid(value))
				{
					counter_ = value;
				}
			}
		}

		[JsonPropertyAttribute]
		public DateTime Date
		{
			get
			{
				return date_;
			}
			set
			{
				date_ = value;
			}
		}

		public WatchModel()
		{
			this.address_ = string.Empty;
			this.position_ = new Position(0, 0);
			this.teamId_ = -1;
			this.counter_ = 0;
			this.date_ = DateTime.Now;
		}

		public WatchModel(string address, Position position, int teamId, int counter = 0)
		{
			Console.WriteLine("creating Watch object ...");
			this.address_ = address;
			this.position_ = position;
			this.teamId_ = teamId;
			this.counter_ = counter;
			this.date_ = DateTime.Now;
		}

		public bool IsValid(int input)
		{
			return (input > -1);
		}
	}
}
