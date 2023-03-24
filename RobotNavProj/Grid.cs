using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavProj
{
    internal class Grid
    {
        int rows;
        int columns;
        Cell[,] map;

        public Grid(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            map = new Cell[rows, columns];
        }

        public void createCells()
        {
           for (int i = 0; i <= rows; i++)
            {
                for(int j = 0; j <= columns; j++)
                {
                    map[i, j] = new Cell(i, j);
                }
            }
        }

    }
}
