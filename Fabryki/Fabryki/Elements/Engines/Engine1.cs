using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryki.Elements.Engines
{
    public class Engine1 : Engine
    {
        public Engine1()
        {
            this.name = "1.4 TSI";
            this.power = "150 HP";
        }

        public override void prepareEngine()
        {
            Console.WriteLine("Preparing 1.4 TSI ...");
        }
    }
}
