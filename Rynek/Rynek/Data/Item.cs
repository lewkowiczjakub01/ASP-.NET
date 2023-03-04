using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rynek.Visitors;

namespace Rynek.Data {
    public abstract class Item {
        public int amount;
        public float productionCost;
        public float margin;
        public int itemsSold;
        public abstract float Accept(ItemVisitor visitor);
    }
}
