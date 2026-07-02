using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntColonySimulation.Strategy;
using AntColonySimulation.AntColonies;

namespace AntColonySimulation.Observer
{
    public class TaskObserver : IColonyObserver
    {
        bool notifyOnce = true;
        private ITask task;

        public TaskObserver(ITask task)
        {
            this.task = task;
        }

        public void Update(CompositeAntColony colony)
        {
            if (task.CanCompleteTask(colony) && notifyOnce)
            {
                Console.WriteLine($"Task {task.GetType()} has been completed!");
                notifyOnce = false;
            }
        }
    }
}
