using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rynek.Publisher;

namespace Rynek.Subscriber {
    public class SellerInflationSubscriber : IObserver<CentralBankData> {
        public CentralBankData Data { get; set; }
        public IDisposable unsubscriber;
        private Seller seller;
        private Customer customer;

        public SellerInflationSubscriber() { }
        public SellerInflationSubscriber(IObservable<CentralBankData> provider) {
            unsubscriber = provider.Subscribe(this);
        }

        public void Subscribe(IObservable<CentralBankData> provider, Seller s) {
            if (unsubscriber == null)
                unsubscriber = provider.Subscribe(this);
            seller = s;
        }

        public void Unsubscribe() {
            unsubscriber.Dispose();
        }

        public void OnCompleted() { }
        public void OnError(Exception error) { }
        public void OnNext(CentralBankData inflation) {
            this.Data = inflation;
            if (seller != null)
                seller.UpdatePrices();
        }
    }
}
