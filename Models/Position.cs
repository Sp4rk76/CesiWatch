using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesiWatch.Models
{
    struct Position
    {
		int v1;
		int v2;
		int x;
        int y;

		public Position(int v1, int v2) : this()
		{
			this.v1 = v1;
			this.v2 = v2;
		}
	}
}
