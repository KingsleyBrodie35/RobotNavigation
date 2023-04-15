using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//not in use currently
namespace RobotNavProj
{
    internal class Agent
    {
        Cell start;
        Tuple<Cell, Cell> goals;

        public Agent(Cell start, Tuple<Cell, Cell> goals)
        {
            this.start = start;
            this.goals = goals;
        }
    }
}
