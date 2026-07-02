using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fabryki.Elements.Engines;
namespace Fabryki.Cars.Easy
{
    public abstract class Car
    {
        public string mark { get; set; }
        public string color { get; set; }

        public abstract void prepareCar();
    }
}
