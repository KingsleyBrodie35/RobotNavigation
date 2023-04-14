using System;
using System.Text.RegularExpressions;

namespace RobotNavProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String[] lines = File.ReadAllLines(args[0]);
            //find number of rows and columns
            Regex findNum = new Regex(@"\d+");
            MatchCollection gridMatches = findNum.Matches(lines[0], 0);
            int rows = 0;
            int columns = 0;
            try
            {
                rows = Int32.Parse(gridMatches[0].Value);
                columns = Int32.Parse(gridMatches[1].Value);
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //create grid
            Grid grid = new Grid(rows, columns);
            grid.createCells();
            //create agent
            //extract positions
            MatchCollection startingPosMatches = findNum.Matches(lines[1], 0);
            MatchCollection goalMatches = findNum.Matches(lines[2], 0);
            int startX = 0, startY = 0, goal0x = 0, goal0y = 0, goal1x = 0, goal1y = 0;
            try
            {
                startX = Int32.Parse(startingPosMatches[0].Value);
                startY = Int32.Parse(startingPosMatches[1].Value);
                goal0x = Int32.Parse(goalMatches[0].Value);
                goal0y = Int32.Parse(goalMatches[1].Value);
                goal1x = Int32.Parse(goalMatches[2].Value);
                goal1y = Int32.Parse(goalMatches[3].Value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Tuple<int, int> start = new Tuple<int, int>(startX, startY);
            Tuple<int, int, int, int> goals = new Tuple<int, int, int, int>(goal0x, goal0y, goal1x, goal1y);
            Agent agent = grid.generateAgent(start, goals);
            //createWalls
            for (int i = 3; i < lines.Length; i++)
            {
                int x = 0, y = 0, width = 0, height = 0;
                MatchCollection wallVals = findNum.Matches(lines[i], 0);
                try
                {
                    x = Int32.Parse(wallVals[0].Value);
                    y = Int32.Parse(wallVals[1].Value);
                    width = Int32.Parse(wallVals[2].Value);
                    height = Int32.Parse(wallVals[3].Value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                List<Tuple<int, int>> cells = new List<Tuple<int, int>>();
                cells.Add(new Tuple<int, int>(y, x));

                for (int j = 0; j < width; j++)
                {

                    for (int k = 0; k < height; k++)
                    {
                        grid.isWall(y + k, x + j);
                        Console.WriteLine($"{y + k}, {x + j}");

                    }
                }
            }
            int idx = 0;
            //create Graph
            Graph graph = new Graph(rows * columns);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    //up
                    if (i - 1 != -1)
                    {
                        graph.AddEdge(idx, grid.Map[i - 1, j]);
                    }
                    //left
                    if (j - 1 != -1)
                    {
                        graph.AddEdge(idx, grid.Map[i, j - 1]);
                    }
                    //down
                    if (i + 1 < rows)
                    {
                        graph.AddEdge(idx, grid.Map[i + 1, j]);
                    }
                    //right
                    if (j + 1 < columns)
                    {
                        graph.AddEdge(idx, grid.Map[i, j + 1]);
                    }
                    idx++;
                }
                Console.WriteLine("Hello");
            }
        }
    }
}