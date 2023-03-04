using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rynek.Publisher {
    public class InflationProvider : IObservable<CentralBankData> {
        List<IObserver<CentralBankData>> observers;
        public InflationProvider() {
            observers = new List<IObserver<CentralBankData>>();
        }

        public IDisposable Subscribe(IObserver<CentralBankData> observer) {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new InflationUnSubscriber(observers, observer);
        }
        
        private void MeasurementsChanged(float inflation) {
            foreach (var obs in observers) {
                obs.OnNext(new CentralBankData(inflation));
            }
        }

        public void SetMeasurements(float inflation) {
            MeasurementsChanged(inflation);
        }

    }
}
