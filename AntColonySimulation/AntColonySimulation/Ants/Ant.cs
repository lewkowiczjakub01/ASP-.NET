using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonySimulation.Ants
{
    public abstract class Ant
    {
        public int Strength { get; set; }
        public int Memory { get; set; }
        public int Health { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsInColony { get; set; }
        public int Age { get; set; }



        public virtual void Move(int width, int height)
        {
            Age++;
        }

        public abstract char GetMapSymbol();

        public override string ToString()
        {
            return $"Ant(Type={GetType().Name}, Strength={Strength}, Memory={Memory}, Health={Health}, Position=({X}, {Y}), InColony={IsInColony}, Age={Age})";
        }
    }
}
