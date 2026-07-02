using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonySimulation.World.Items
{
    public abstract class Item
    {
        public int x { get; set; }
        public int y { get; set; }
        public int weight { get; set; }

        public abstract char GetSymbol();
    }
}
