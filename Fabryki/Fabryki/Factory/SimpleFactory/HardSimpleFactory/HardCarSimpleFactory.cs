
using Fabryki.Elements.Engines;
using Fabryki.Marks;
using Fabryki.Elements.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Cars.Hard;
using Fabryki.Elements.Guarantee;

namespace Fabryki.Factory.SimpleFactory.HardSimpleFactory
{
    public class HardCarSimpleFactory
    {
        public Car createCar(string type, string color, Engine engine, int yearOfProduction, Guarantee guarantee)
        {
            return type switch
            {
                CarNames.AUDI => CreateAudi(color, engine, yearOfProduction, guarantee),
                CarNames.BMW => CreateBMW(color, engine, yearOfProduction, guarantee),
                CarNames.MERCEDES => CreateMercedes(color, engine, yearOfProduction, guarantee),
                CarNames.SKODA => CreateSkoda(color, engine, yearOfProduction, guarantee),
                _ => throw new ArgumentException("Unknown car mark: " + type),
            };
        }
        private static Car CreateAudi(string color, Engine engine, int yearOfProduction, Guarantee guarantee)
        {
            List<string> equipment = new List<string> { Equipment.AC, Equipment.HeatedSeats, Equipment.AlloyWheels, Equipment.LeatherSeats };
            return new Audi(color, engine, yearOfProduction, equipment, guarantee);
        }

        private static Car CreateBMW(string color, Engine engine, int yearOfProduction, Guarantee guarantee)
        {
            List<string> equipment = new List<string> { Equipment.AC, Equipment.AlloyWheels, Equipment.LeatherSeats };
            return new BMW(color, engine, yearOfProduction, equipment, guarantee);
        }

        private static Car CreateMercedes(string color, Engine engine, int yearOfProduction, Guarantee guarantee)
        {
            List<string> equipment = new List<string> { Equipment.AC, Equipment.PremiumAudioSystem, Equipment.AlloyWheels, Equipment.LeatherSeats, Equipment.HeatedSeats, Equipment.Sunroof };
            return new Mercedes(color, engine, yearOfProduction, equipment, guarantee);
        }

        private static Car CreateSkoda(string color, Engine engine, int yearOfProduction, Guarantee guarantee)
        {
            List<string> equipment = new List<string> { Equipment.AC };
            return new Skoda(color, engine, yearOfProduction, equipment, guarantee);
        }
    }
}
