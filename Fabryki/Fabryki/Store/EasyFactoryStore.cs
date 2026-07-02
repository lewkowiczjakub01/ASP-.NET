using Fabryki.Cars.Easy;
using Fabryki.Factory.AbstractFactory.EasyCarAbstractFactory;
using Fabryki.Factory.FactoryWithMethod.EasyCarFactory;
using Fabryki.Factory.ReflectionFactory;
using Fabryki.Factory.SimpleFactory.EasySimpleFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryki.Store
{
    public class EasyFactoryStore
    {
        private EasyCarSimpleFactory easyCarSimpleFactory;
        private EasyCarFactory easyCarFactoryWithMethod;
        private CarAbstractFactory easyCarAbstractFactory;
        private EasyReflectionFactory easyReflectionFactory;

        public EasyFactoryStore(EasyCarSimpleFactory easyCarSimpleFactory,EasyCarFactory easyCarFactoryWithMethod ,CarAbstractFactory easyCarAbstractFactory, EasyReflectionFactory easyReflectionFactory)
        {
            this.easyCarSimpleFactory = easyCarSimpleFactory;
            this.easyCarFactoryWithMethod = easyCarFactoryWithMethod;
            this.easyCarAbstractFactory = easyCarAbstractFactory;
            this.easyReflectionFactory = easyReflectionFactory;
        }

        public Car createWithSimpleFactory(string mark, string color)
        {
            return easyCarSimpleFactory.createCar(mark, color);
        }

        public Car createWithFactoryWithMethod(string color)
        {
            return easyCarFactoryWithMethod.createCar(color);
        }

        public Car createWithAbstractFactory(string color)
        {
            return easyCarAbstractFactory.createCar(color);
        }

        public Car createWithReflectionFactory(string mark, string color)
        {
            return easyReflectionFactory.createCar(mark, color);
        }
    }
}
