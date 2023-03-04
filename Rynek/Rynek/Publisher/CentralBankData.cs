using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rynek.Publisher {
    public class CentralBankData {
        public float inflation { get; set; }
        public CentralBankData(float inflation) {
            this.inflation = inflation;
        }
    }
}
