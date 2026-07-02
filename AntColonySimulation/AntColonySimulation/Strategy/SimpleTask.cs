using AntColonySimulation.AntColonies;

namespace AntColonySimulation.Strategy
{
    public class SimpleTask : ITask
    {
        public int RequiredStrength { get; }
        public int RequiredMemory { get; }
        public int RequiredHealth { get; }

        public SimpleTask(int requiredStrength, int requiredMemory, int requiredHealth)
        {
            RequiredStrength = requiredStrength;
            RequiredMemory = requiredMemory;
            RequiredHealth = requiredHealth;
        }

        public bool CanCompleteTask(AntColony colony)
        {
            int totalStrength = colony.GetAnts().Sum(ant => ant.Strength);
            int totalMemory = colony.GetAnts().Sum(ant => ant.Memory);
            int totalHealth = colony.GetAnts().Sum(ant => ant.Health);

            if (totalStrength >= RequiredStrength && totalMemory >= RequiredMemory && totalHealth >= RequiredHealth)
            {
                return true;
            }
            return false;
        }
    }
}
