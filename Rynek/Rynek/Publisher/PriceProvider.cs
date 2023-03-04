using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rynek.Data;

namespace Rynek.Publisher {
    public class PriceProvider : IObservable<SellerData>{
        List<IObserver<SellerData>> observers;

        public PriceProvider() {
            observers = new List<IObserver<SellerData>>();
        }

        public IDisposable Subscribe(IObserver<SellerData> observer) {
            if (!observers.Contains(observer)) {
                observers.Add(observer);
            }
            return new PriceUnSubscriber(observers, observer);
        }

        private void MeasurementsChanged(List<Item> stuff) {
            foreach (var obs in observers) {
                obs.OnNext(new SellerData(stuff));
            }
        }

        public void SetMeasurements(List<Item> stuff) {
            MeasurementsChanged(stuff);
        }
    }
}
