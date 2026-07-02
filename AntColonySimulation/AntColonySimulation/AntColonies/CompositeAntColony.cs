using AntColonySimulation.Ants;
using AntColonySimulation.Observer;
using AntColonySimulation.Strategy;

namespace AntColonySimulation.AntColonies
{
    public class CompositeAntColony : AntColony
    {

        private List<IColonyObserver> observers = new List<IColonyObserver>();
        private Random random = new Random();

        public CompositeAntColony()
        {
            if (random.Next(2) == 0)
                task = new SimpleTask(60, 35, 60);
            else
                task = new FindItemsTask(3);
        }



        public void Attach(IColonyObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IColonyObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                //Console.WriteLine("New ant has born");
                observer.Update(this);
            }
        }
        public override void AddAnt(Ant ant)
        {
            ants.Add(ant);
        }

        public override void RemoveAnt(Ant ant)
        {
            ants.Remove(ant);
        }

        public override int GetTotalStrength()
        {
            return ants.Sum(a => a.Strength);
        }

        public override int GetTotalMemory()
        {
            return ants.Sum(a => a.Memory);
        }

        public override int GetTotalHealth()
        {
            return ants.Sum(a => a.Health);
        }


        public override string ToString()
        {
            return $"Colony have {ants.Count} ants";
        }
    }
}
