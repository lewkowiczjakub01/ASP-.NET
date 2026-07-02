using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fabryki.Elements.Engines;
namespace Fabryki.Cars.Medium
{
    public abstract class Car
    {
        public string mark { get; set; }
        public string color { get; set; }
        public Engine engine { get; set; }
        public int yearOfProduction  { get; set; }


        public abstract void prepareCar();
    }
}
