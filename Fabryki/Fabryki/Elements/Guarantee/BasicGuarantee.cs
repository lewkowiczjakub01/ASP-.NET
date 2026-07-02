using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryki.Elements.Guarantee
{
    public class BasicGuarantee : Guarantee
    {
        public BasicGuarantee() 
        {
            this.timeInYears = 2;
            this.size = "Minimal";
        }

        public override void prepareGuarantee()
        {
            Console.WriteLine("Preparing basic guarantee");
        }
    }
}
