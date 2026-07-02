using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Cars.Medium;
using Fabryki.Elements.Engines;

namespace Fabryki.Factory.AbstractFactory.MediumCarAbstractFactory
{
    public interface CarAbstractFactory
    {
        Car createCar(string color, int yearOfProduction);
        Engine createEngine();
    }
}
