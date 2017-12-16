using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesiWatch.Models
{
	// A watch has:
	// - an address
	// - give its position
	// - belongs to a "team" (represented as an id)

    public class WatchModel
    {
        private Position position_;
		private String address_;
		private int teamId_;

		WatchModel()
		{
			this.address_ = String.Empty;
			this.position_ = new Position(0, 0);
			this.teamId_ = -1;
		}

		WatchModel(String address, Position position, Int32 teamId)
		{
			this.address_ = address;
			this.position_ = position;
			this.teamId_ = teamId;
		}
    }
}
