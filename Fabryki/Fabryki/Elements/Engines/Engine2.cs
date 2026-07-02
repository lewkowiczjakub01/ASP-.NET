using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryki.Elements.Engines
{
    public class Engine2 : Engine
    {
        public Engine2()
        {
            this.name = "1.0 EcoBoost";
            this.power = "125 HP";
        }

        public override void prepareEngine()
        {
            Console.WriteLine("Preparing 1.0 EcoBoost ...");
        }
    }
}
