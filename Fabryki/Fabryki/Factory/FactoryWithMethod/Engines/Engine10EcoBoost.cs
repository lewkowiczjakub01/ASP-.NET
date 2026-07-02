using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Elements.Engines;
namespace Fabryki.Factory.FactoryWithMethod.Engines
{
    public class Engine10EcoBoost : EngineFactory
    {
        public Engine createEngine()
        {
            return new Engine2();
        }
    }
}
