using AntColonySimulation.Ants;
using AntColonySimulation.Observer;
using AntColonySimulation.World.Items;
using AntColonySimulation.World.Items.AbstractFactory;
using AntColonySimulation.AntColonies;
using AntColonySimulation.Strategy;


namespace AntColonySimulation.World
{
    public class TurnBasedSystem
    {
        private CompositeAntColony colony;
        private int turn = 0;
        private int mapWidth;
        private int mapHeight;
        private Map map;
        private ItemFactory itemFactory;
        private ITask task;
        private TaskObserver taskObserver;

        public TurnBasedSystem(CompositeAntColony colony, int mapWidth, int mapHeight, Map map, ItemFactory itemFactory, ITask task)
        {
            this.colony = colony;
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.map = map;
            this.itemFactory = itemFactory;
            this.task = task;
            this.taskObserver = new TaskObserver(task);
            colony.Attach(taskObserver);
        }

        public void NextTurn()
        {
            Console.WriteLine($"Tura: {turn}");
            turn++;

            List<Ant> newAnts = new List<Ant>();
            List<Ant> antsToRemove = new List<Ant>();

            if (turn % 1 == 0)
            {
                Item newItem = itemFactory.CreateItem(mapWidth, mapHeight, map);
                if (map.GetItemAt(newItem.x, newItem.y) == null)
                {
                    map.AddItem(newItem);
                }
            }

            foreach (var ant in colony.GetAnts())
            {
                if (ant is QueenAnt queen)
                {
                    WorkerAnt newWorkerAnt = queen.ProduceWorkerAnt();
                    newAnts.Add(newWorkerAnt);
                }

                if (ant.Age >= 5 && (ant is WorkerAnt))
                {
                    StrongAnt strongAnt = new StrongAnt(ant);
                    antsToRemove.Add(ant);
                    newAnts.Add(strongAnt);
                }
                else if (ant is StrongAnt strongAnt)
                {
                    Item foundItem = map.GetItemAt(strongAnt.X, strongAnt.Y);
                    if (foundItem != null && foundItem.weight<= ant.Strength)
                    {
                        //Console.WriteLine($"StrongAnt found {foundItem.GetSymbol()}.");
                        colony.numOfItems = colony.numOfItems + 1;
                        strongAnt.Move(-1, mapHeight);
                        if (strongAnt.IsInColony)
                        {
                            map.RemoveItem(foundItem);
                            ant.Health = ant.Health + 3;
                            ant.Strength = ant.Strength + 3;
                            Console.WriteLine($"StrongAnt brought {foundItem.GetSymbol()} to the colony.");
                        }
                    }
                    else if (ant.Age >= 15)
                    {
                        antsToRemove.Add(ant);
                    }
                    else
                    {
                        ant.Move(mapWidth, mapHeight);
                    }
                }
                else
                {
                    ant.Move(mapWidth, mapHeight);
                }
            }

            foreach (var ant in antsToRemove)
            {
                colony.RemoveAnt(ant);
            }

            foreach (var ant in newAnts)
            {
                colony.AddAnt(ant);
            }

            colony.Notify();

        }
    }
}
