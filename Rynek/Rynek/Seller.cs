using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rynek.Data;
using Rynek.Subscriber;
using Rynek.Publisher;
using Rynek.Visitors;

namespace Rynek {
    public class Seller {
        public List<Item> items = new List<Item> ();
        public CentralBank centralBank;
        private SellerInflationSubscriber inflationSubscriber = new SellerInflationSubscriber ();
        public PriceProvider provider = new PriceProvider ();



        public Seller(CentralBank centralBank) {
            this.centralBank = centralBank;
            inflationSubscriber.Subscribe(centralBank.provider, this);
            items.Add(new Fruit("Jabłko", 50, 2, 0.05f));
            items.Add(new Book("Krzyżacy", 100, 5, 0.1f)); ;
            provider.SetMeasurements(items);
        }

        private void SetPrices() {
            foreach (Item item in items) {
                if (item.itemsSold > 5)
                    item.margin += 0.01f;
                else
                    item.margin -= 0.01f;
                item.itemsSold = 0;
            }
            provider.SetMeasurements(items);

        }

        public void UpdatePrices() {
            foreach (Item item in items) {
                item.productionCost = item.productionCost + item.productionCost*inflationSubscriber.Data.inflation;
            }
            provider.SetMeasurements(items);
        }

        private void UpdateAmount() {
            var rand = new Random();
            foreach (Item item in items) {
                item.amount += rand.Next(10);
            }
        }

        public void SellItem(Type type, int amount) {
            foreach (Item item in items) {
                if (item.GetType().Equals(type)) {
                    item.amount -= amount;
                    centralBank.PayTax(amount * item.Accept(new ItemVisitorImpl()));
                }
            }
        }

        public void RefreshMarket() {
            SetPrices();
            UpdateAmount();
        }
    }
}
