using Fabryki.Cars.Easy;
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
    public class EasyReflectionFactory
    {
        public Car createCar(string mark, string color)
        {
            try
            {
                Type carType = Type.GetType("Fabryki.Cars.Easy." + mark);
                ConstructorInfo constructor = carType.GetConstructor(new[] { typeof(string) });
                return (Car)constructor.Invoke(new object[] { color });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
