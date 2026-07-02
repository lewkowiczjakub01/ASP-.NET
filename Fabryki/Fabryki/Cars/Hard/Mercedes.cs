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
    public class Mercedes : Car
    {
        public Mercedes(string color, Engine engine, int yearOfProduction, List<string> equipment, Guarantee guarantee)
        {
            mark = CarNames.MERCEDES;
            this.color = color;
            this.engine = engine;
            this.yearOfProduction = yearOfProduction;
            this.equipment = equipment;
            this.guarantee = guarantee;
        }

        public override void prepareCar()
        {
            Console.WriteLine("Preparing Mercedes");
            Console.WriteLine(this);
        }
    }
}