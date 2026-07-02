using Fabryki.Cars.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryki.Factory.FactoryWithMethod.EasyCarFactory
{
    public class EasySkoda : EasyCarFactory
    {
        public Car createCar(string color)
        {
            return new Skoda(color);
        }

    }
}
