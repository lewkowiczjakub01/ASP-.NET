using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryki.Elements.Engines
{
    public abstract class Engine
    {
        public string name { get; set; }
        public string power { get; set; }

        public abstract void prepareEngine();
    }
}
