using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabryki.Elements.Engines;
namespace Fabryki.Factory.FactoryWithMethod.Engines
{
    public interface EngineFactory
    {
        Engine createEngine();
    }
}
