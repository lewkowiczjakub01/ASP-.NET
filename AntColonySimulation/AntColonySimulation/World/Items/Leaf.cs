using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonySimulation.World.Items
{
    public class Leaf : Item
    {
        public Leaf(int x, int y, int weight) 
        {
            this.x = x;
            this.y = y;
            this.weight = weight;
        }
        public override char GetSymbol() => 'l';
    }
}
