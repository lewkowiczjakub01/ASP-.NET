
using Fabryki.Elements.Engines;
using Fabryki.Marks;
using Fabryki.Elements.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Cars.Easy;
using Fabryki.Elements.Guarantee;

namespace Fabryki.Factory.SimpleFactory.EasySimpleFactory
{
    public class EasyCarSimpleFactory
    {
        public Car createCar(string type, string color)
        {
            return type switch
            {
                CarNames.AUDI => CreateAudi(color),
                CarNames.BMW => CreateBMW(color),
                CarNames.MERCEDES => CreateMercedes(color),
                CarNames.SKODA => CreateSkoda(color),
                _ => throw new ArgumentException("Unknown car mark: " + type),
            };
        }
        private static Car CreateAudi(string color)
        {
            return new Audi(color);
        }

        private static Car CreateBMW(string color)
        {
            return new BMW(color);
        }

        private static Car CreateMercedes(string color)
        {
            return new Mercedes(color);
        }

        private static Car CreateSkoda(string color)
        {
            return new Skoda(color);
        }
    }
}
