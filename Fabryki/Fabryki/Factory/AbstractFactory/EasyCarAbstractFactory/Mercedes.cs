using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Cars.Easy;
using Fabryki.Elements.Engines;
using Fabryki.Elements.Equipments;
namespace Fabryki.Factory.AbstractFactory.EasyCarAbstractFactory
{
    public class Mercedes20TFSI : CarAbstractFactory
    {
        public Car createCar(string color)
        {
            return new Mercedes(color);
        }
    }
}
