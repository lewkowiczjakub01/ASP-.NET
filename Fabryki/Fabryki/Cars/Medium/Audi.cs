using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Marks;
using Fabryki.Elements.Engines;
namespace Fabryki.Cars.Medium
{
    public class Audi : Car
    {
        public Audi(string color, Engine engine, int yearOfProduction) {
            mark = CarNames.AUDI;
            this.color = color;
            this.engine = engine;
            this.yearOfProduction = yearOfProduction;
        }

        public override void prepareCar()
        {
            Console.WriteLine("Preparing Audi");
            Console.WriteLine(this);
        }
    }
}
