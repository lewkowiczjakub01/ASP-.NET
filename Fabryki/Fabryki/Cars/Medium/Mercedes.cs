using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fabryki.Elements.Engines;
using Fabryki.Marks;
namespace Fabryki.Cars.Medium
{
    public class Mercedes : Car
    {
        public Mercedes(string color, Engine engine, int yearOfProduction)
        {
            mark = CarNames.MERCEDES;
            this.color = color;
            this.engine = engine;
            this.yearOfProduction = yearOfProduction;
        }

        public override void prepareCar()
        {
            Console.WriteLine("Preparing Mercedes");
            Console.WriteLine(this);
        }
    }
}