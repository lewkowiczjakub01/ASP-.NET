using Fabryki.Elements.Engines;
using Fabryki.Marks;
using Fabryki.Elements.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Cars.Medium;
using Fabryki.Elements.Guarantee;

namespace Fabryki.Factory.SimpleFactory.MediumSimpleFactory
{
    public class MediumCarSimpleFactory
    {
        public Car createCar(string type, string color, Engine engine, int yearOfProduction)
        {
            return type switch
            {
                CarNames.AUDI => CreateAudi(color, engine, yearOfProduction),
                CarNames.BMW => CreateBMW(color, engine, yearOfProduction),
                CarNames.MERCEDES => CreateMercedes(color, engine, yearOfProduction),
                CarNames.SKODA => CreateSkoda(color, engine, yearOfProduction),
                _ => throw new ArgumentException("Unknown car mark: " + type),
            };
        }
        private static Car CreateAudi(string color, Engine engine, int yearOfProduction)
        {
            return new Audi(color,engine,yearOfProduction);
        }

        private static Car CreateBMW(string color, Engine engine, int yearOfProduction)
        {
            return new BMW(color, engine, yearOfProduction);
        }

        private static Car CreateMercedes(string color, Engine engine, int yearOfProduction)
        {
            return new Mercedes(color, engine, yearOfProduction);
        }

        private static Car CreateSkoda(string color, Engine engine, int yearOfProduction)
        {
            return new Skoda(color, engine, yearOfProduction);
        }
    }
}
