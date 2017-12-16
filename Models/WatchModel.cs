using System;

namespace CesiWatch.Models
{
	// A watch has:
	// - an address
	// - give its position
	// - belongs to a "team" (represented as an id)
	public class WatchModel
	{
		private string address_;
		private Position position_;
		private int teamId_;
		private int counter_;

		public WatchModel()
		{
			this.address_ = string.Empty;
			this.position_ = new Position(0, 0);
			this.teamId_ = -1;
			this.counter_ = 0;
		}

		public WatchModel(string address, Position position, int teamId, int counter = 0)
		{
			this.address_ = address;
			this.position_ = position;
			this.teamId_ = teamId;
			this.counter_ = counter;
		}

		public string getAddress()
		{
			return address_;
		}

		public Position getPosition()
		{
			return position_;
		}

		public int getTeamId()
		{
			return teamId_;
		}

		public int getCounter()
		{
			return counter_;
		}

		public void setAddress(string address)
		{
			this.address_ = address;
		}

		public void setPosition(Position position)
		{
			this.position_ = position;
		}

		public void setTeamId(int teamId)
		{
			if (IsValid(teamId))
			{
				this.teamId_ = teamId;
			}
		}

		public void setCounter(int counter)
		{
			if (IsValid(counter))
			{
				this.counter_ = counter;
			}
		}

		public bool IsValid(int input)
		{
			return (input > -1);
		}
	}
}
