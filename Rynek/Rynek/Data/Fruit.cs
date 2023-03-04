using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rynek.Visitors;

namespace Rynek.Data {
    public class Fruit : Item{
        public string name { get; set; }

        public Fruit(string name, int weight, float productionCost, float margin) {
            this.name = name;
            this.amount = weight;
            this.productionCost = productionCost;
            this.margin = margin;
        }

        public override float Accept(ItemVisitor visitor) => visitor.Visit(this);
    }
}
