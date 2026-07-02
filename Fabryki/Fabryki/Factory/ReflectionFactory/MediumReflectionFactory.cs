using Fabryki.Cars.Medium;
using Fabryki.Elements.Engines;
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
    public class MediumReflectionFactory
    {
        public Car createCar(string mark, string color, Engine engine, int yearOfProduction)
        {
            try
            {
                Type carType = Type.GetType("Fabryki.Cars.Medium." + mark);
                ConstructorInfo constructor = carType.GetConstructor(new[] { typeof(string), typeof(Engine), typeof(int) });
                return (Car)constructor.Invoke(new object[] { color, engine, yearOfProduction });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
