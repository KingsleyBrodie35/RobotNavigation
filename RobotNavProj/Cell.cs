using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavProj
{
    internal class Cell
    {
        int x, y;
        bool wall;
        //List<Cell> edges;

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
            //edges = new List<Cell>();
        }
        
        public bool Wall
        {
            get { return wall; }
            set => wall = value;
        }

        //public void AddEdge(Cell c)
        //{
        //    edges.Add(c);
        //}

    }
}
