using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rynek.Visitors;

namespace Rynek.Data {
    public class Book : Item {
        public string title { get; set; }

        public Book(string title, int amount, float productionCost, float margin) {
            this.title = title;
            this.amount = amount;
            this.productionCost = productionCost;
            this.margin = margin;
        }

        public override float Accept(ItemVisitor visitor) => visitor.Visit(this);
    }
}
