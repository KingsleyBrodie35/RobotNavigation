using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavProj
{
    internal class Grid
    {
        int rows, columns;
        Cell[,] map;
        Agent agent;

        public Grid(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            map = new Cell[rows, columns];
            createCells();
        }

        public int Rows {
            get { return rows; }
        }
        public int Columns
        {
            get { return columns;  }
        }
        public Cell[,] Map
        {
            get { return map; }
        }

        public void createCells()
        {
           for (int i = 0; i <= rows - 1; i++)
            {
                for(int j = 0; j <= columns - 1; j++)
                {
                    map[i, j] = new Cell(i, j);
                }
            }
        }

        public Agent generateAgent(Tuple <int, int> start, Tuple<int, int, int, int> goals)
        {
            
            Cell startCell = map[start.Item2, start.Item1];
            Cell goalCell01 = map[goals.Item2, goals.Item1];
            Cell goalCell02 = map[goals.Item4, goals.Item3];
            Tuple<Cell, Cell> goalCells = new Tuple<Cell, Cell>(goalCell01, goalCell02);

            this.agent = new Agent(startCell, goalCells);
            return agent;
        }

        public void isWall(int y, int x)
        {
            map[y, x].Wall = true;
            
        }

    }
}
