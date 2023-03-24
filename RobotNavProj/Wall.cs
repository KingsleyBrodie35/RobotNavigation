using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavProj
{
    internal class Wall : Cell
    {
        int height, width;

        public Wall(int x, int y, int height, int width) : base(x, y)
        {
            this.height = height;
            this.width = width;
        }

    }
}
