using AntColonySimulation.AntColonies;


namespace AntColonySimulation.Strategy
{
    public interface ITask
    {
        bool CanCompleteTask(AntColony colony);
    }
}
