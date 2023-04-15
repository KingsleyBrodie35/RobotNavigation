using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavProj
{
    internal class GraphN
    {
        public Cell root { get; set; }
        public List<Cell> connectedCells { get; set; }
        public GraphN(Cell root) { 
            this.root = root;
            connectedCells = new List<Cell>();
        }

        public void addCell(Cell child)
        {
            connectedCells.Add(child);
        }





    }
}
