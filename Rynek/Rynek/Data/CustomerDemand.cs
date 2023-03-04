using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rynek.Data {
    public class CustomerDemand {
        public int amountNeeded;

        public CustomerDemand(int amountNeeded) {
            this.amountNeeded = amountNeeded;
        }

        public void SetAmountNeeded(int amount) {
            amountNeeded += amount;
        }
    }
}
