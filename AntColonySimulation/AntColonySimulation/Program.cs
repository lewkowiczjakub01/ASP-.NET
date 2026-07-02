using AntColonySimulation.Ants;
using AntColonySimulation.AntColonies;
using AntColonySimulation.Observer;
using AntColonySimulation.Strategy;
using AntColonySimulation.World;
using AntColonySimulation.World.Items.AbstractFactory;

namespace AntColonySimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int mapWidth = 10;
            int mapHeight = 10;
            int colonyX = mapWidth / 2;
            int colonyY = mapHeight / 2;
            Map map = new Map(mapWidth, mapHeight);
            ColonyObserver colonyObserver = new ColonyObserver();
            ItemFactory itemFactory = new RandomItemFactory();

            AntBuilder antBuilder = new AntBuilder();
            WorkerAnt ant1 = antBuilder.SetStrength(5).SetMemory(3).SetHealth(5).SetPosition(colonyX - 1, colonyY - 1).Build();
            WorkerAnt ant2 = antBuilder.SetStrength(5).SetMemory(3).SetHealth(5).SetPosition(colonyX, colonyY - 1).Build();
            WorkerAnt ant3 = antBuilder.SetStrength(5).SetMemory(3).SetHealth(5).SetPosition(colonyX - 1, colonyY).Build();
            QueenAnt queenAnt = new QueenAnt { Strength = 10, Memory = 10, Health = 10, X = colonyX, Y = colonyY, IsInColony = true };

            AntColonyBuilder colonyBuilder = new AntColonyBuilder().AddAnt(queenAnt).AddAnt(ant1).AddAnt(ant2).AddAnt(ant3);
            CompositeAntColony colony = colonyBuilder.Build();
            TaskObserver taskObserver = new TaskObserver(colony.task);
            colony.Attach(colonyObserver);
            colony.Attach(taskObserver);
            TurnBasedSystem turnBasedSystem = new TurnBasedSystem(colony, mapWidth, mapHeight, map, itemFactory, colony.task);

            for (int i = 0; i < 20; i++)
            {
                turnBasedSystem.NextTurn();
                map.UpdateMap(colony.GetAnts());
                map.DisplayMap();
                Console.WriteLine();
            }
        }
    }
}
