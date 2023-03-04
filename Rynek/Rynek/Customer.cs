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
    public class Customer {
        private CustomerInflationSubscriber inflationSubscriber = new CustomerInflationSubscriber();
        private List<ItemsSubscriber> itemsSubscriber = new List<ItemsSubscriber>();
        private Dictionary<int, Seller> sellers = new Dictionary<int, Seller>();
        public int customerDemands;
        public Dictionary<Type, CustomerDemand> demands = new Dictionary<Type, CustomerDemand>();
        public float maxPrice;
        public Customer(CentralBank centralBank, List<Seller> seller, Dictionary<Type, CustomerDemand> demands, float maxPrice) {
            inflationSubscriber.Subscribe(centralBank.provider, this);
            for (int i=0; i < seller.Count(); i++)
                sellers.Add(i, seller[i]);
            for (int i=0; i<sellers.Count(); i++) {
                itemsSubscriber.Add(new ItemsSubscriber());
                itemsSubscriber[i].Subscribe(sellers[i].provider);
            }
            this.demands = demands;
            this.maxPrice = maxPrice;
        }

        private void RefreshDemands() {
            var rand = new Random();
                foreach (Item item in sellers[0].items) {
                    if (demands.Keys.Contains(item.GetType()))
                    demands[item.GetType()].SetAmountNeeded(rand.Next(10));
            }
        }
        int counter = 0;
        public void BuyItems() {
            foreach (Seller s in sellers.Values) {
                foreach(Item item in s.items) {
                    if (demands.Keys.Contains(item.GetType())){
                        if (s.centralBank.GetInflation()* s.items[counter].margin < maxPrice) {
                            if (demands[item.GetType()].amountNeeded > s.items[counter].amount) {
                                s.items[counter].itemsSold = s.items[counter].amount;
                                s.SellItem(item.GetType(), demands[item.GetType()].amountNeeded - s.items[counter].amount);
                                demands[item.GetType()].amountNeeded -= s.items[counter].amount;
                                s.items[counter].amount = 0;
                                counter++;
                            } else {
                                s.items[counter].itemsSold = demands[item.GetType()].amountNeeded;
                                s.SellItem(item.GetType(), demands[item.GetType()].amountNeeded);
                                demands[item.GetType()].amountNeeded = 0;
                                s.items[counter].amount -= demands[item.GetType()].amountNeeded;
                                counter++;
                            }
                        }
                    }
                }
            }
        }

        public void RefreshMarket() {
            RefreshDemands();
        }
    }
}
