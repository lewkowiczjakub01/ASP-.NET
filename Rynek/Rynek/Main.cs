using Rynek.Data;
namespace Rynek {
    class main {
        public static void Main() {
            CentralBank cb = new CentralBank(0.15f, 0f);
            Seller s1 = new Seller(cb);
            List<Seller> l1 = new List<Seller> {s1};


            Dictionary<Type, CustomerDemand> d1 = new Dictionary<Type,CustomerDemand>();
            d1.Add(s1.items[0].GetType(), new CustomerDemand(6));
            d1.Add(s1.items[1].GetType(), new CustomerDemand(10));

            Customer c1 = new Customer(cb, l1, d1, 0.02f);
            //Console.WriteLine(c1.demands[s1.items[0].GetType()].amountNeeded);
            //c1.BuyItems();
            //Console.WriteLine(c1.demands[s1.items[0].GetType()].amountNeeded);
            //Console.WriteLine(s1.items[0].amount);
            //Console.WriteLine(s1.items[1].amount);
            //Console.WriteLine(cb.currentIncome);
            //Console.WriteLine(cb.previousIncome);
            //Console.WriteLine(s1.items[0].productionCost);
            //Console.WriteLine(s1.items[0].margin);
            //Console.WriteLine(s1.items[0].itemsSold);
            Console.WriteLine(cb.GetInflation());
            Console.WriteLine(s1.items[0].productionCost);
            c1.BuyItems();
            cb.UpdateTax();
            //s1.RefreshMarket();
            //c1.RefreshMarket();
            Console.WriteLine(cb.GetInflation());
            Console.WriteLine(s1.items[0].productionCost);
            //Console.WriteLine(s1.items[0].margin);
            //Console.WriteLine(s1.items[0].itemsSold);
            //c1.BuyItems();
            //Console.WriteLine(c1.demands[s1.items[0].GetType()].amountNeeded);
            //Console.WriteLine(s1.items[0].amount);
            //Console.WriteLine(s1.items[1].amount);
            //Console.WriteLine(cb.currentIncome);
            //Console.WriteLine(cb.previousIncome);
            //Console.WriteLine(s1.items[0].productionCost);

        }
    }
}