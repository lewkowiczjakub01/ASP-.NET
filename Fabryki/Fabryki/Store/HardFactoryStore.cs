using Fabryki.Cars.Hard;
using Fabryki.Elements.Engines;
using Fabryki.Elements.Guarantee;
using Fabryki.Factory.AbstractFactory.HardCarAbstractFactory;
using Fabryki.Factory.FactoryWithMethod.HardCarFactory;
using Fabryki.Factory.ReflectionFactory;
using Fabryki.Factory.SimpleFactory.HardSimpleFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryki.Store
{
    public class HardFactoryStore
    {
        private HardCarSimpleFactory hardCarSimpleFactory;
        private HardCarFactory hardCarFactoryWithMethod;
        private CarAbstractFactory hardCarAbstractFactory;
        private HardReflectionFactory hardReflectionFactory;

        public HardFactoryStore (HardCarSimpleFactory hardCarSimpleFactory, HardCarFactory hardCarFactoryWithMethod, CarAbstractFactory hardCarAbstractFactory, HardReflectionFactory hardReflectionFactory)
        {
            this.hardCarSimpleFactory = hardCarSimpleFactory;
            this.hardCarFactoryWithMethod = hardCarFactoryWithMethod;
            this.hardCarAbstractFactory = hardCarAbstractFactory;
            this.hardReflectionFactory = hardReflectionFactory;
        }

        public Car createWithSimpleFactory(string mark, string color, Engine engine, int yearOfProduction, Guarantee guarantee)
        {
            return hardCarSimpleFactory.createCar(mark, color, engine, yearOfProduction, guarantee);
        }

        public Car createWithFactoryWithMethod(string color, Engine engine, int yearOfProduction, List<string> equipment, Guarantee guarantee)
        {
            return hardCarFactoryWithMethod.createCar(color, engine, yearOfProduction, equipment, guarantee);
        }

        public Car createWithAbstractFactory(string color, int yearOfProduction)
        {
            return hardCarAbstractFactory.createCar(color, yearOfProduction);
        }

        public Car createWithReflectionFactory(string mark, string color, Engine engine, int yearOfProduction, List<string> equipment,  Guarantee guarantee)
        {
            return hardReflectionFactory.createCar(mark, color, engine, yearOfProduction, equipment,  guarantee);
        }
    }
}
