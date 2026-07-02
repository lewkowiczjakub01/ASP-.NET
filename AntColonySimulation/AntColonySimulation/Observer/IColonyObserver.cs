using AntColonySimulation.AntColonies;

namespace AntColonySimulation.Observer
{
    public interface IColonyObserver
    {
        void Update(CompositeAntColony colony);
    }
}
