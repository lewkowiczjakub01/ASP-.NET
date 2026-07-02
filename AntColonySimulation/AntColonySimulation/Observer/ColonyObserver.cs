using AntColonySimulation.AntColonies;

namespace AntColonySimulation.Observer
{
    public class ColonyObserver : IColonyObserver
    {
        public void Update(CompositeAntColony colony)
        {
            //Console.WriteLine("Colony updated:");
            var ants = colony.GetAnts();
            foreach (var ant in ants)
            {
                Console.WriteLine($"Ant {ant.GetMapSymbol()} at ({ant.X}, {ant.Y}) with strength {ant.Strength}, health {ant.Health}, memory {ant.Memory}, ");
            }
        }
    }
}
