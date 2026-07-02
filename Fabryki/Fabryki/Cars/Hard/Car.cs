using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Elements.Engines;
using Fabryki.Elements.Guarantee;
namespace Fabryki.Cars.Hard
{
    public abstract class Car
    {
        public string mark { get; set; }
        public string color { get; set; }
        public Engine engine { get; set; }
        public int yearOfProduction { get; set; }
        public List<string> equipment { get; set; }
        public Guarantee guarantee { get; set; }

        public void addEquipment(string equip)
        {
            equipment.Add(equip);
        }

        public abstract void prepareCar();
    }
}
