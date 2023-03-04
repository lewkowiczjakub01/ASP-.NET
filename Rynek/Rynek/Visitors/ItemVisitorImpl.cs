using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rynek.Data;

namespace Rynek.Visitors {
    public class ItemVisitorImpl : ItemVisitor {
        public float Visit(Book book) => book.productionCost + book.productionCost * book.margin;
        public float Visit(Fruit fruit) => fruit.productionCost + fruit.productionCost * fruit.margin;
    }
}
