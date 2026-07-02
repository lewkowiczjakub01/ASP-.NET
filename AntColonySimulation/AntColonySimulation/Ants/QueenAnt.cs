using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonySimulation.Ants
{
    public class QueenAnt : Ant
    {

        public override char GetMapSymbol()
        {
            return 'Q';
        }

        public WorkerAnt ProduceWorkerAnt()
        {
            return new WorkerAnt { Strength = 3, Memory = 3, Health = 3, X = this.X, Y = this.Y, IsInColony = true };
        }

        public override string ToString()
        {
            return $"QueenAnt(Type={GetType().Name}, Strength={Strength}, Memory={Memory}, Health={Health}, Position=({X}, {Y}), InColony={IsInColony}, Age={Age})";
        }
    }
}
