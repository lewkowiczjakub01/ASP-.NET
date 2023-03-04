using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rynek.Publisher;

namespace Rynek {
    public class CentralBank {
        private float currentIncome=0;
        private float previousIncome;
        private float inflation = 0.1f;
        private float tax = 0.23f;
        public InflationProvider provider { get; set; }

        public CentralBank(float inflation, float previousIncome) {
            this.inflation = inflation;
            this.previousIncome = previousIncome;
            currentIncome = 0;
            provider = new InflationProvider();
            provider.SetMeasurements(inflation);
        }

        public void PayTax(float tax) {
            currentIncome += tax*this.tax;
        }

        public void UpdateTax() {
            if (currentIncome > previousIncome)
                inflation -= 0.05f;
            else
                inflation += 0.05f;
            provider.SetMeasurements(inflation);
            previousIncome = currentIncome;
            currentIncome = 0;
        }

        public float GetCurrentIncome() {
            return currentIncome;
        }

        public float GetPreviousIncome() {
            return previousIncome;
        }

        public float GetInflation() {
            return inflation;
        }
    }
}
