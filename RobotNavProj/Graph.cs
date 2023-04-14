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


    }
}
