using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonySimulation.World.Items.AbstractFactory
{
    public class LeafFromFactory : ItemFactory
    {
        protected static Random random = new Random();

        public Item CreateItem(int mapWidth, int mapHeight, Map m)
        {
            int x = random.Next(0, mapWidth);
            int y = random.Next(0, mapHeight);
            int s = random.Next(3, 10);
            return new Leaf(x,y,s);
        }
    }
}
