using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Cars.Easy;
using Fabryki.Elements.Engines;

namespace Fabryki.Factory.AbstractFactory.EasyCarAbstractFactory
{
    public interface CarAbstractFactory
    {
        Car createCar(string color);
    }
}
