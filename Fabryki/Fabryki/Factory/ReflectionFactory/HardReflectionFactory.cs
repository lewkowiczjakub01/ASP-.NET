using Fabryki.Cars.Hard;
using Fabryki.Elements.Engines;
using Fabryki.Elements.Guarantee;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fabryki.Factory.ReflectionFactory
{
    public class HardReflectionFactory
    {
        public Car createCar(string mark, string color, Engine engine, int yearOfProduction, List<string> equipment,  Guarantee guarantee)
        {
            try
            {
                Type carType = Type.GetType("Fabryki.Cars.Hard." + mark);
                ConstructorInfo constructor = carType.GetConstructor(new[] {typeof(string), typeof(Engine), typeof(int), typeof(List<string>), typeof(Guarantee) });
                return (Car)constructor.Invoke(new object[] { color, engine, yearOfProduction, equipment,  guarantee });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
