using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fabryki.Elements.Engines;
using Fabryki.Marks;
namespace Fabryki.Cars.Easy
{
    public class BMW : Car
    {
        public BMW(string color)
        {
            mark = CarNames.BMW;
            this.color = color;
        }

        public override void prepareCar()
        {
            Console.WriteLine("Preparing BMW");
            Console.WriteLine(this);
        }
    }
}
