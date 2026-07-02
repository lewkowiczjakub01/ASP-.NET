using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Marks;
using Fabryki.Elements.Engines;
using Fabryki.Elements.Guarantee;
namespace Fabryki.Cars.Hard
{
    public class Audi : Car
    {
        public Audi(string color, Engine engine, int yearOfProduction, List<string> equipment, Guarantee guarantee)
        {
            mark = CarNames.AUDI;
            this.color = color;
            this.engine = engine;
            this.yearOfProduction = yearOfProduction;
            this.equipment = equipment;
            this.guarantee = guarantee;
        }

        public override void prepareCar()
        {
            Console.WriteLine("Preparing Audi");
            Console.WriteLine(this);
        }
    }
}
