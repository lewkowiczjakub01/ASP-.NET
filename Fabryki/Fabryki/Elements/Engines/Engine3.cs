using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryki.Elements.Engines
{
    public class Engine3 : Engine
    {
        public Engine3()
        {
            this.name = "2.0 TFSI";
            this.power = "250 HP";
        }
        public override void prepareEngine()
        {
            Console.WriteLine("Preparing 2.0 TFSI ...");
        }
    }
}
