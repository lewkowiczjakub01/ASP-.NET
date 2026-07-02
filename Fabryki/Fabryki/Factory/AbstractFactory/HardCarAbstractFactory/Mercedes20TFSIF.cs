using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Cars;
using Fabryki.Cars.Hard;
using Fabryki.Elements.Engines;
using Fabryki.Elements.Equipments;
using Fabryki.Elements.Guarantee;
namespace Fabryki.Factory.AbstractFactory.HardCarAbstractFactory
{
    public class Mercedes20TFSIF : CarAbstractFactory
    {
        public Car createCar(string color, int yearOfProduction)
        {
            return new Mercedes(color, createEngine(), yearOfProduction, createEquipment(), createGuarantee());
        }

        public Engine createEngine()
        {
            return new Engine3();
        }

        public List<string> createEquipment()
        {
            return new List<string> { Equipment.AC, Equipment.PremiumAudioSystem, Equipment.AlloyWheels, Equipment.LeatherSeats, Equipment.HeatedSeats, Equipment.Sunroof };
        }

        public Guarantee createGuarantee()
        {
            return new FullGuarantee();
        }
    }
}
