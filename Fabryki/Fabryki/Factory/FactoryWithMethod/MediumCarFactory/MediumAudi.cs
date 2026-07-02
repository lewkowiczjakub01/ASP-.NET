using Fabryki.Cars.Medium;
using Fabryki.Elements.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryki.Factory.FactoryWithMethod.MediumCarFactory
{
    public class MediumAudi : MediumCarFactory
    {
        public Car createCar(string color, Engine engine, int yearOfProduction)
        {
            return new Audi(color, engine, yearOfProduction);
        }
    }
}
