using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers {
    public class GenerateOfficeID {
        private static int count = 1;
        private int id = count;


        public GenerateOfficeID() {
            count++;
        }


        public override string ToString() {
            return "\nOffice ID: " + id;
        }
    }
}