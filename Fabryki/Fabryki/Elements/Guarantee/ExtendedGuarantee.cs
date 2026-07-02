using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryki.Elements.Guarantee
{
    public class ExtendedGuarantee : Guarantee
    {
        public ExtendedGuarantee() 
        {
            this.timeInYears = 5;
            this.size = "Extended";
        }

        public override void prepareGuarantee()
        {
            Console.WriteLine("Preparing extended guarantee");
        }
    }
}
