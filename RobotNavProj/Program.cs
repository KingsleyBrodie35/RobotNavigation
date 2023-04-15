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
            //create Start & Goals
            //Parse string to int
            MatchCollection startingPosMatches = findNum.Matches(lines[1], 0);
            MatchCollection goalMatches = findNum.Matches(lines[2], 0);
            int startX = 0, startY = 0, goal0x = 0, goal0y = 0, goal1x = 0, goal1y = 0;
            try
            {
                startY = Int32.Parse(startingPosMatches[0].Value);
                startX = Int32.Parse(startingPosMatches[1].Value);
                goal0y = Int32.Parse(goalMatches[0].Value);
                goal0x = Int32.Parse(goalMatches[1].Value);
                goal1y = Int32.Parse(goalMatches[2].Value);
                goal1x = Int32.Parse(goalMatches[3].Value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            grid.Map[startX, startY].Start = true;
            grid.Map[goal0x, goal0y].Goal = true;
            grid.Map[goal1x, goal1y].Goal = true;

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
            Queue<Cell> frontier = new Queue<Cell>();
            frontier.Enqueue(grid.Map[startX, startY]);
            while (frontier.Count != 0)
            {
                Cell cell = frontier.Dequeue();

                //add connected cells to cell edges
                //up
                if (cell.x - 1 != -1)
                {
                    if (!cell.Wall && !grid.Map[cell.x - 1, cell.y].Wall)
                    {
                        cell.AddCell(grid.Map[cell.x - 1, cell.y]);
                        frontier.Enqueue(grid.Map[cell.x - 1, cell.y]);
                    }
                }
                //Left
                if (cell.y - 1 != -1)
                {
                    if (!cell.Wall && !grid.Map[cell.x, cell.y - 1].Wall)
                    {
                        cell.AddCell(grid.Map[cell.x, cell.y - 1]);
                        frontier.Enqueue(grid.Map[cell.x, cell.y - 1]);
                    }
                } 
                //Down
                if (cell.x + 1 < rows)
                {
                    if (!cell.Wall && !grid.Map[cell.x + 1, cell.y].Wall)
                    {
                        cell.AddCell(grid.Map[cell.x + 1, cell.y]);
                        frontier.Enqueue(grid.Map[cell.x + 1, cell.y]);
                    }
                }
                //Right
                if (cell.y + 1 < columns)
                {
                    if (!cell.Wall && !grid.Map[cell.x, cell.y + 1].Wall)
                    {
                        cell.AddCell(grid.Map[cell.x, cell.y + 1]);
                        frontier.Enqueue(grid.Map[cell.x, cell.y + 1]);
                    }
                }
            }

            




















            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < columns; j++)
            //    {
            //        //up
            //        if (i - 1 != -1)
            //        {
            //            if (!grid.Map[i, j].Wall && !grid.Map[i - 1, j].Wall)
            //            {
            //                graph.AddEdge(idx, grid.Map[i - 1, j]);
            //            }
            //        }
            //        //left
            //        if (j - 1 != -1)
            //        {
            //            if (!grid.Map[i, j].Wall && !grid.Map[i, j - 1].Wall)
            //            {
            //                graph.AddEdge(idx, grid.Map[i, j - 1]);
            //            }
            //        }
            //        //down
            //        if (i + 1 < rows) 
            //        { 
            //            if (!grid.Map[i, j].Wall && !grid.Map[i + 1, j].Wall)
            //            {
            //                graph.AddEdge(idx, grid.Map[i + 1, j]);
            //            }
            //        }
            //        //right
            //        if (j + 1 < columns)
            //        {
            //            if (!grid.Map[i, j].Wall && !grid.Map[i, j + 1].Wall)
            //            {
            //                graph.AddEdge(idx, grid.Map[i, j + 1]);
            //            }
            //        }
            //        idx++;
            //    }
                
            //}
            //Cell c = graph.BFS(grid.Map[startX, startY], grid);
            //Console.WriteLine("mod y " + 36 % 11);
        }
    }
}