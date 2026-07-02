using AntColonySimulation.Ants;

namespace AntColonySimulation.AntColonies
{
    public class AntColonyBuilder
    {
        private CompositeAntColony colony;

        public AntColonyBuilder()
        {
            colony = new CompositeAntColony();
        }

        public AntColonyBuilder AddAnt(Ant ant)
        {
            colony.AddAnt(ant);
            return this;
        }

        public CompositeAntColony Build()
        {
            return colony;
        }
    }
}
