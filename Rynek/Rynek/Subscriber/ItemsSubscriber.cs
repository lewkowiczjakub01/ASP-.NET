using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rynek.Publisher;

namespace Rynek.Subscriber {
    public class ItemsSubscriber : IObserver<SellerData>{
        public SellerData Data { get; set; }
        public IDisposable _unsubscriber;

        public ItemsSubscriber() { }
        public ItemsSubscriber(IObservable<SellerData> provider) {
            _unsubscriber = provider.Subscribe(this);
        }

        public void Subscribe(IObservable<SellerData> provider) {
            if (_unsubscriber == null)
                _unsubscriber = provider.Subscribe(this);
        }

        public void Unsubscribe() {
            _unsubscriber.Dispose();
        }

        public void OnCompleted() { }
        public void OnError(Exception error) { }
        public void OnNext(SellerData item) {
            this.Data = item;
        }
    }
}
