using System;

namespace RobotNavProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //read file
            if (File.Exists(args[0]))
            {
                String[] lines = File.ReadAllLines(args[0]);
            }
            

           
        }
    }
}