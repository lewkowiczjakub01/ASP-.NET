using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rynek.Data;

namespace Rynek.Publisher {
    public class SellerData {
        public List<Item> stuff = new List<Item>();
        public SellerData(List<Item> stuff) {
            this.stuff = stuff;
        }
    }
}
