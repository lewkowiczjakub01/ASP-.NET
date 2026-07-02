using AntColonySimulation.AntColonies;
using AntColonySimulation.World.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonySimulation.Strategy
{
    public class FindItemsTask : ITask
    {
        private int requiredItemCount;

        public FindItemsTask(int requiredItemCount)
        {
            this.requiredItemCount = requiredItemCount;
        }

        public bool CanCompleteTask(AntColony colony)
        {
            if (colony.numOfItems >= requiredItemCount)
                return true;
            return false;
        }


    }
}
