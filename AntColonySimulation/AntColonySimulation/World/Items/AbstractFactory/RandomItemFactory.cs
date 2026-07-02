using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonySimulation.World.Items.AbstractFactory
{
    public class RandomItemFactory : ItemFactory
    {
        protected static Random random = new Random();

        public Item CreateItem(int mapWidth, int mapHeight, Map map)
        {
            int x, y;
            do
            {
                x = random.Next(0, mapWidth);
                y = random.Next(0, mapHeight);
            } while (!map.IsEmpty(x, y));

            int s = random.Next(5, 12);

            if (random.Next(2) == 0)
                return new Leaf(x, y, s);
            else
                return new Seed(x, y, s);
        }
    }
}
