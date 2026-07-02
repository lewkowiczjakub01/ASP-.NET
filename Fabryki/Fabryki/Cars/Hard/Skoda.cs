using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Elements.Engines;
using Fabryki.Elements.Guarantee;
using Fabryki.Marks;
namespace Fabryki.Cars.Hard
{
    public class Skoda : Car
    {
        public Skoda(string color, Engine engine, int yearOfProduction, List<string> equipment, Guarantee guarantee)
        {
            mark = CarNames.SKODA;
            this.color = color;
            this.engine = engine;
            this.yearOfProduction = yearOfProduction;
            this.equipment = equipment;
            this.guarantee = guarantee;
        }

        public override void prepareCar()
        {
            Console.WriteLine("Preparing Skoda");
            Console.WriteLine(this);
        }
    }
}

