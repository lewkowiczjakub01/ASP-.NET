using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rynek.Data;

namespace Rynek.Visitors {
    public interface ItemVisitor {
        float Visit(Book book);
        float Visit(Fruit fruit);

    }
}
