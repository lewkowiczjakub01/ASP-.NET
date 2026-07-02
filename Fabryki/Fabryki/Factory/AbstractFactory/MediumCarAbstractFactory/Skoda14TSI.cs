using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Cars.Medium;
using Fabryki.Elements.Engines;
using Fabryki.Elements.Equipments;
namespace Fabryki.Factory.AbstractFactory.MediumCarAbstractFactory
{
    public class Skoda14TSI : CarAbstractFactory
    {
        public Car createCar(string color, int yearOfProduction)
        {
            return new Skoda(color, createEngine(), yearOfProduction);
        }

        public Engine createEngine()
        {
            return new Engine1();
        }
    }
}
