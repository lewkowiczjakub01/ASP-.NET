using Fabryki.Cars.Medium;
using Fabryki.Elements.Engines;
using Fabryki.Factory.AbstractFactory.MediumCarAbstractFactory;
using Fabryki.Factory.FactoryWithMethod.MediumCarFactory;
using Fabryki.Factory.ReflectionFactory;
using Fabryki.Factory.SimpleFactory.MediumSimpleFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryki.Store
{
    public class MediumFactoryStore
    {
        private MediumCarSimpleFactory mediumCarSimpleFactory;
        private MediumCarFactory mediumCarFactoryWithMethod;
        private CarAbstractFactory mediumCarAbstractFactory;
        private MediumReflectionFactory mediumReflectionFactory;

        public MediumFactoryStore(MediumCarSimpleFactory mediumCarSimpleFactory,MediumCarFactory mediumCarFactoryWithMethod ,CarAbstractFactory mediumCarAbstractFactory, MediumReflectionFactory mediumReflectionFactory)
        {
            this.mediumCarSimpleFactory = mediumCarSimpleFactory;
            this.mediumCarFactoryWithMethod = mediumCarFactoryWithMethod;
            this.mediumCarAbstractFactory = mediumCarAbstractFactory;
            this.mediumReflectionFactory = mediumReflectionFactory;
        }

        public Car createWithSimpleFactory(string mark, string color, Engine engine, int yearOfProduction)
        {
            return mediumCarSimpleFactory.createCar(mark, color, engine, yearOfProduction);
        }

        public Car createWithFactoryWithMethod(string color, Engine engine, int yearOfProduction)
        {
            return mediumCarFactoryWithMethod.createCar(color, engine, yearOfProduction);
        }

        public Car createWithAbstractFactory(string color, int yearOfProduction)
        {
            return mediumCarAbstractFactory.createCar(color, yearOfProduction);
        }

        public Car createWithReflectionFactory(string mark, string color, Engine engine, int yearOfProduction)
        {
            return mediumReflectionFactory.createCar(mark, color, engine, yearOfProduction);
        }
    }
}
