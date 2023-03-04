using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rynek.Publisher {
    internal class InflationUnSubscriber : IDisposable{
		private List<IObserver<CentralBankData>> lstObservers;
		private IObserver<CentralBankData> observer;

		internal InflationUnSubscriber(List<IObserver<CentralBankData>> observersCollection, IObserver<CentralBankData> observer) {
			this.lstObservers = observersCollection;
			this.observer = observer;
		}

		public void Dispose() {
			if (this.observer != null) 
				lstObservers.Remove(this.observer);
		}
	}
}
