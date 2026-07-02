using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonySimulation.Ants
{
    public class AntBuilder
    {
        private WorkerAnt ant;

        public AntBuilder()
        {
            ant = new WorkerAnt();
        }

        public AntBuilder SetStrength(int strength)
        {
            ant.Strength = strength;
            return this;
        }

        public AntBuilder SetMemory(int memory)
        {
            ant.Memory = memory;
            return this;
        }

        public AntBuilder SetHealth(int health)
        {
            ant.Health = health;
            return this;
        }

        public AntBuilder SetPosition(int x, int y)
        {
            ant.X = x;
            ant.Y = y;
            return this;
        }

        public WorkerAnt Build()
        {
            return ant;
        }
    }
}
