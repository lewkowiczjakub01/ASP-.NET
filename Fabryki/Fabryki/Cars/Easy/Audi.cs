using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Marks;
using Fabryki.Elements.Engines;
namespace Fabryki.Cars.Easy
{
    public class Audi : Car
    {
        public Audi(string color) {
            mark = CarNames.AUDI;
            this.color = color;
        }

        public override void prepareCar()
        {
            Console.WriteLine("Preparing Audi");
            Console.WriteLine(this);
        }
    }
}
