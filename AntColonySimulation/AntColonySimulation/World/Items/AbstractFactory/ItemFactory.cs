using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonySimulation.World.Items.AbstractFactory
{
    public interface ItemFactory
    {
        Item CreateItem(int mapWidth, int mapHeight, Map map);
    }
}
