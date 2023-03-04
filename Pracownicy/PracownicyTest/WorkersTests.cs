global using NUnit.Framework;
using Workers;
using static Workers.Worker;
namespace WorkersTest {
    public class WorkersTests {
        private ManualWorker worker1 = new ManualWorker("Jakub", "Lewkowicz", 21, 10, new Address("Borówkowa", "5", "-", "Jankowo"), 50);
        private ManualWorker worker2 = new ManualWorker("Krzysztof", "Rudnicki", 45, 20, new Address("Jagieloñska", "44", "2", "Gdañsk"), 80);
        private OfficeWorker worker3 = new OfficeWorker("Piotr", "Tracewski", 21, 5, new Address("Niepo³omicka", "20", "4", "Olsztyn"), 120);
        private OfficeWorker worker4 = new OfficeWorker("Tomasz", "Kopyra", 43, 25, new Address("Gdzies", "25", "1", "Kraków"), 25);
        private Trader worker5 = new Trader("Tomasz", "K³uba", 72, 21, new Address("Jakas", "43", "-", "I³awa"), EFFECTIVNESS.MEDIUM, 35);
        private Trader worker6 = new Trader("Zbigniew", "Wielkonosy", 52, 15, new Address("D³uga", "5", "1", "Bia³ystok"), EFFECTIVNESS.LOW, 20);
        private Address address1 = new Address("Borówkowa", "5", "-", "Jankowo");
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void CheckIfTestWorks() {
            Assert.Pass();
        }

        [Test]
        public void CheckIfCanCreateWorker() {
            Assert.That(worker1, Is.Not.Null);
        }
        [Test]
        public void CheckIfCanCreateAdress() {
            Assert.That(address1, Is.Not.Null);
        }
        [Test]
        public void CheckIfNameIsCorrect() {
            Assert.That(worker1.name, Is.EqualTo("Jakub"));
        }
        [Test]
        public void CheckIfStrengthIsCorrect() {
            worker1 = new ManualWorker("Jakub", "Lewkowicz", 21, 10, new Address("Borówkowa", "5", "-", "Jankowo"), 50);
            Assert.That(worker1.getStrength, Is.EqualTo(50));
        }
        [Test]
        public void CheckIfCanSetStrengthHigherThan100() {
            worker1.setStrength(150);
            Assert.That(worker1.getStrength(), Is.EqualTo(null));
        }
        [Test]
        public void CheckIfCityIsCorrect() {
            Assert.That(worker1.address.getCity(), Is.EqualTo("Jankowo"));
        }
        [Test]
        public void CheckIfIqIsCorrect() {
            worker3 = new OfficeWorker("Piotr", "Tracewski", 21, 5, new Address("Niepo³omicka", "20", "4", "Olsztyn"), 120);
            Assert.That(worker3.getIQ(), Is.EqualTo(120));
        }
        [Test]
        public void CheckIfIqIsCorrect2() {
            Assert.That(worker4.getIQ(), Is.EqualTo(null));
        }
        [Test]
        public void CheckIfCanSetIqHigherThan150() {
            worker3.setIQ(200);
            Assert.That(worker4.getIQ(), Is.EqualTo(null));
        }
        [Test]
        public void CheckIfCommisionIsCorrect() {
            worker5 = new Trader("Tomasz", "K³uba", 72, 21, new Address("Jakas", "43", "-", "I³awa"), EFFECTIVNESS.MEDIUM, 35);
            Assert.That(worker5.getCommision, Is.EqualTo(35));
        }
        [Test]
        public void CheckIfCanSetCommisionHigherThan100() {
            worker5 = new Trader("Tomasz", "K³uba", 72, 21, new Address("Jakas", "43", "-", "I³awa"), EFFECTIVNESS.MEDIUM, 35);
            worker5.setCommision(101);
            Assert.That(worker5.getCommision, Is.EqualTo(null));
        }
        [Test]
        public void CheckIfEffectivnessIsCorrect() {
            Assert.That(worker5.getEffectivness, Is.EqualTo(EFFECTIVNESS.MEDIUM));
        }
        [Test]
        public void CheckIfAddingToListIsCorrect() {
            workers.Clear();
            addWorker(worker1);
            addWorker(worker2);
            addWorker(worker3);
            Assert.That(workers.Count, Is.EqualTo(3));
        }

        [Test]
        public void CheckIfRemovingFromListIsCorrect() {
            workers.Clear();
            addWorker(worker1);
            addWorker(worker2);
            addWorker(worker3);
            removeWorker(1);
            Assert.That(workers.Count(), Is.EqualTo(2));
        }
        [Test]
        public void CheckIfShowingListOfWorkersIsCorrect() {
            Assert.That(worker1.GetId(), Is.EqualTo(1));
        }
        [Test]
        public void CheckIfViewingAListIsGood() {
            workers.Clear();
            addWorker(worker1);
            addWorker(worker2);
            Assert.That(viewAllWorkers(), Is.EqualTo(worker1.ToString() + worker2.ToString()));
        }
        [Test]
        public void CheckIfSortingByExperienceIsCorrect() {
            workers.Clear();
            addWorker(worker1);
            addWorker(worker2);
            addWorker(worker3);
            Assert.That(WorkersSortByExperience(), Is.EqualTo(worker2.ToString() + worker1.ToString() + worker3.ToString()));
        }
        [Test]
        public void CheckIfFindingByCityIsCorrect() {
            workers.Clear();
            addWorker(worker1);
            addWorker(worker2);
            addWorker(worker3);
            Assert.That(WorkersCity("Jankowo"), Is.EqualTo(worker1.ToString()));
        }
        [Test]
        public void CheckIfAddingFewWorkersIsCorrect() {
            workers.Clear();
            addFewWorkers(worker1, worker2, worker3);
            Assert.That(workers.Count(), Is.EqualTo(3));
        }
        [Test]
        public void CheckIfSortingByAgeIsCorrect() {
            workers.Clear();
            addWorker(worker1);
            addWorker(worker5);
            addWorker(worker6);
            Assert.That(WorkersSortByAge(), Is.EqualTo(worker1.ToString() + worker6.ToString() + worker5.ToString()));
        }
        [Test]
        public void CheckIfSortingBySurnameIsCorrect() {
            workers.Clear();
            addWorker(worker1);
            addWorker(worker2);
            addWorker(worker3);
            Assert.That(WorkersSortBySurname(), Is.EqualTo(worker1.ToString() + worker2.ToString() + worker3.ToString()));
        }

    }
}