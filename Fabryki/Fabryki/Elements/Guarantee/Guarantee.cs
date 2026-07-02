using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryki.Elements.Guarantee
{
    public abstract class Guarantee
    {
        public int timeInYears;
        public string size;

        public abstract void prepareGuarantee();
    }
}
