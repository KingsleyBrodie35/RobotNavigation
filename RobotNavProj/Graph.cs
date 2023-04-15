using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavProj
{
    internal class Graph
    {
        public int vertices { get; set; }
        //Array of adjacent cells (is edge)
        List<Cell>[] adjacencyList;

        public Graph(int vertices)
        {
            this.vertices = vertices;
            adjacencyList = new List<Cell>[vertices];
            for(int i = 0; i < vertices; i++)
            {
                adjacencyList[i] = new List<Cell>();
            }
        }

        public void AddEdge(int index, Cell c)
        {
            adjacencyList[index].Add(c);
        }


        public Cell BFS(Cell start, Grid grid)
        {
            //initialise variables
            int indexStart = start.x * 10 + start.y;
            List<Cell> visited = new List<Cell>();
            Queue<List<Cell>> frontier = new Queue<List<Cell>>();
            int y = indexStart % 10;
            int x = (indexStart - y) / 10;


            //if start is goal return cell
            if (grid.Map[x, y].Goal)
            {
                return grid.Map[x, y];
            }

            frontier.Enqueue(adjacencyList[indexStart + 1]);

            while (frontier.Count != 0) {
                List<Cell> children = frontier.Dequeue();

                foreach (Cell c in children)
                {
                    if (c.Goal)
                    {
                        return c;
                    }
                    if (!visited.Contains(c))
                    {
                        frontier.Enqueue(adjacencyList[c.x * 10 + c.y]);
                        visited.Add(c);
                    }
                }
            }
            return null;
        }
    }
}
