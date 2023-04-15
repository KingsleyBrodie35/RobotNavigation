using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavProj
{
    internal class Cell
    {
        public int x, y;
        bool wall;
        bool goal;
        bool start;
        List<Cell> connectedCells;

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
            connectedCells = new List<Cell>();  
        }

        public bool Wall
        {
            get { return wall; }
            set => wall = value;
        }

        public bool Goal
        {
            get { return goal; }
            set => wall = value;
        }

        public bool Start
        {
            get { return start; }
            set => start = value;   
        }

        public void AddCell(Cell c)
        {
            connectedCells.Add(c);
        }

    }
}
