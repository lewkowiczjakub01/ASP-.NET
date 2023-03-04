using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rynek.Publisher;

namespace Rynek.Subscriber {
    public class CustomerInflationSubscriber : IObserver<CentralBankData> {
        public CentralBankData Data { get; set; }
        public IDisposable unsubscriber;
        private Customer customer;

        public CustomerInflationSubscriber() { }
        public CustomerInflationSubscriber(IObservable<CentralBankData> provider) {
            unsubscriber = provider.Subscribe(this);
        }

        public void Subscribe(IObservable<CentralBankData> provider, Customer c) {
            if (unsubscriber == null)
                unsubscriber = provider.Subscribe(this);
            customer = c;
        }

        public void Unsubscribe() {
            unsubscriber.Dispose();
        }

        public void OnCompleted() { }
        public void OnError(Exception error) { }
        public void OnNext(CentralBankData inflation) {
            this.Data = inflation;
        }
    }
}
