using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rynek.Publisher {
    internal class PriceUnSubscriber : IDisposable {
        private List<IObserver<SellerData>> lstObservers;
        private IObserver<SellerData> observer;

        internal PriceUnSubscriber(List<IObserver<SellerData>> observersCollection, IObserver<SellerData> observer) {
            this.lstObservers = observersCollection;
            this.observer = observer;
        }

        public void Dispose() {
            if (this.observer != null) 
                lstObservers.Remove(this.observer);
        }
    }
}
