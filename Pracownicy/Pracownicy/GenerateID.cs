using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public class GenerateID
    {
        private static int count = 0;
        public static int GeneratedID() {
            count ++;
            return count;
        }
        public override string ToString() {
            return "ID: " + count;
        }
    }
}
