using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fabryki.Elements.Engines;
using Fabryki.Marks;
namespace Fabryki.Cars.Easy
{
    public class Skoda : Car
    {
        public Skoda(string color)
        {
            mark = CarNames.SKODA;
            this.color = color;
        }

        public override void prepareCar()
        {
            Console.WriteLine("Preparing Skoda");
            Console.WriteLine(this);
        }
    }
}

