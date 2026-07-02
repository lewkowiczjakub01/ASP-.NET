using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fabryki.Elements.Engines;
using Fabryki.Marks;
namespace Fabryki.Cars.Medium
{
    public class Skoda : Car
    {
        public Skoda(string color, Engine engine, int yearOfProduction)
        {
            mark = CarNames.SKODA;
            this.color = color;
            this.engine = engine;
            this.yearOfProduction = yearOfProduction;
        }

        public override void prepareCar()
        {
            Console.WriteLine("Preparing Skoda");
            Console.WriteLine(this);
        }
    }
}

