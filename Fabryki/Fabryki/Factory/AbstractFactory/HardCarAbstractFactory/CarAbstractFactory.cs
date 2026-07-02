using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Cars.Hard;
using Fabryki.Elements.Engines;
using Fabryki.Elements.Equipments;
using Fabryki.Elements.Guarantee;

namespace Fabryki.Factory.AbstractFactory.HardCarAbstractFactory
{
    public interface CarAbstractFactory
    {
        Car createCar(string color, int yearOfProduction);
        Engine createEngine();
        List<string> createEquipment();
        Guarantee createGuarantee();
    }
}
