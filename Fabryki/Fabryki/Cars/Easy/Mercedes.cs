using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fabryki.Elements.Engines;
using Fabryki.Marks;
namespace Fabryki.Cars.Easy
{
    public class Mercedes : Car
    {
        public Mercedes(string color)
        {
            mark = CarNames.MERCEDES;
            this.color = color;
        }

        public override void prepareCar()
        {
            Console.WriteLine("Preparing Mercedes");
            Console.WriteLine(this);
        }
    }
}