using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonySimulation.Ants
{
    public class WorkerAnt : Ant
    {
        public override char GetMapSymbol()
        {
            return 'W';
        }

        public override string ToString()
        {
            return $"WorkerAnt(Type={GetType().Name}, Strength={Strength}, Memory={Memory}, Health={Health}, Position=({X}, {Y}), InColony={IsInColony}, Age={Age})";
        }
    }
}
