using NUnit.Framework;
using Rynek.Subscriber;
using Rynek.Publisher;
using Rynek.Data;
using Rynek;

namespace RynekTest {
    public class Tests {
        private PriceProvider provider;
        private InflationProvider provider2;
        private CentralBank cb;
        private Seller s;
        private Customer c;
        private List<Seller> sellers;
        private Dictionary<Type, CustomerDemand> demands;

        [SetUp]
        public void Setup() {
            provider = new PriceProvider();
            provider2 = new InflationProvider();
            cb = new CentralBank(0.1f, 0);
            s = new Seller(cb);
            sellers = new List<Seller> { s };
            demands = new Dictionary<Type, CustomerDemand>();
            demands.Add(s.items[0].GetType(), new CustomerDemand(6));
            demands.Add(s.items[1].GetType(), new CustomerDemand(10));
            c = new Customer(cb, sellers, demands, 0.02f);

        }

        [Test]
        public void CheckIfTestWorks() {
            Assert.Pass();
        }

        [Test]
        public void CheckIfPriceProviderAndItemSubscriberWorks() {
            ItemsSubscriber subscriber = new ItemsSubscriber(provider);
            List<Item> items = new List<Item>();
            items.Add(new Fruit("Jab³ko", 10, 2, 0.05f));
            provider.SetMeasurements(items);
            Assert.That(subscriber.Data.stuff[0].productionCost, Is.EqualTo(2));
        }

        [Test]
        public void CheckIfInflationProviderAndCustomerInflationSubscriberWorks() {
            CustomerInflationSubscriber subscriber = new CustomerInflationSubscriber(provider2);
            provider2.SetMeasurements(0.05f);
            Assert.That(subscriber.Data.inflation, Is.EqualTo(0.05f));
        }

        [Test]
        public void CheckIfInflationProviderAndSellerInflationSubscriberWorks() {
            SellerInflationSubscriber subscriber = new SellerInflationSubscriber(provider2);
            provider2.SetMeasurements(0.1f);
            Assert.That(subscriber.Data.inflation, Is.EqualTo(0.1f));
        }

        [Test]
        public void CheckIfUpdateTaxWorks() {
            cb.UpdateTax();
            Assert.That(cb.GetInflation(), Is.EqualTo(0.15f));
        }

        [Test]
        public void CheckIfCanGetCurrentInflation() {
            Assert.That(cb.GetInflation(), Is.EqualTo(0.1f));
        }

        [Test]
        public void CheckIfCanPayTaxes() {
            cb.PayTax(100);
            cb.PayTax(50);
            cb.PayTax(10);
            Assert.That(cb.GetCurrentIncome(), Is.EqualTo(160*0.23).Within(0.00001f));
        }

        [Test]
        public void CheckIfSetPricesWorks() {
            c.BuyItems();
            s.RefreshMarket();
            Assert.That(s.items[0].margin, Is.EqualTo(0.06f).Within(0.00001f));
        }

        [Test]
        public void CheckIfCostOfProductionWillAutomaticcalyUpdateAfterInflationChange() {
            c.BuyItems();
            s.RefreshMarket();
            c.RefreshMarket();
            cb.UpdateTax();
            Assert.That(s.items[0].productionCost, Is.EqualTo(2.1f).Within(0.00001f));
        }

        [Test]
        public void CheckIfRefreshingCustomerDemandsWorks() {
            c.BuyItems();
            c.RefreshMarket();
            Assert.That(c.demands[s.items[0].GetType()].amountNeeded, Is.Not.EqualTo(0));
        }

        [Test]
        public void CheckIfRefreshingSellerAmountOfItems() {
            c.BuyItems();
            s.RefreshMarket();
            Assert.That(s.items[0].amount, Is.Not.EqualTo(0));
        }

        [Test]
        public void CheckIfProductionCostIsCorrect() {
            c.BuyItems();
            s.RefreshMarket();
            c.RefreshMarket();
            cb.UpdateTax();

            Assert.That(s.items[1].productionCost, Is.Not.EqualTo(5.5f).Within(0.00001f));
        }

    }
}