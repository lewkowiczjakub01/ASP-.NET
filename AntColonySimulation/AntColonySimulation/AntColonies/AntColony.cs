using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntColonySimulation.Ants;
using AntColonySimulation.Strategy;

namespace AntColonySimulation.AntColonies
{
    public abstract class AntColony
    {
        protected List<Ant> ants = new List<Ant>();
        public int numOfItems = 0;
        public ITask task;

        public abstract void AddAnt(Ant ant);
        public abstract void RemoveAnt(Ant ant);
        public abstract int GetTotalStrength();
        public abstract int GetTotalMemory();
        public abstract int GetTotalHealth();

        public IEnumerable<Ant> GetAnts() => ants;
    }
}
