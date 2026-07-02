using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryki.Elements.Guarantee
{
    public class FullGuarantee : Guarantee
    {
        public FullGuarantee()
        {
            this.timeInYears = 7;
            this.size = "full";
        }

        public override void prepareGuarantee()
        {
            Console.WriteLine("Preparing full guarantee");
        }
    }
}
