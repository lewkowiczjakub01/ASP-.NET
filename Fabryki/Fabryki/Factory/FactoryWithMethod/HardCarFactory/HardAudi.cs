using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Cars.Hard;
using Fabryki.Elements.Engines;
using Fabryki.Elements.Equipments;
using Fabryki.Elements.Guarantee;

namespace Fabryki.Factory.FactoryWithMethod.HardCarFactory
{
    public class HardAudi : HardCarFactory
    {
        public Car createCar(string color, Engine engine, int yearOfProduction,List<string> equipment, Guarantee guarantee)
        {
            return new Audi(color, engine, yearOfProduction, equipment, guarantee);
        }
    }
}
