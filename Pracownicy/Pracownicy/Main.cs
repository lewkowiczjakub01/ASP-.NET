using static Workers.Worker;
namespace Workers
{
    class main
    {
        public static void Main(String[] args)
        {
            addWorker(new ManualWorker("Jakub", "Lewkowicz", 21, 10, new Address("Borówkowa", "5", "-", "Jankowo"), 50));
            addWorker(new ManualWorker("Krzysztof", "Rudnicki", 45, 20, new Address("Jagielońska", "44", "2", "Gdańsk"), 80));
            addWorker(new Trader("Tomasz", "Kłuba", 72, 21, new Address("Jakas", "43", "-", "Iława"), EFFECTIVNESS.MEDIUM, 35));
            addWorker(new Trader("Tomasz", "Kłuba", 72, 21, new Address("Jakas", "43", "-", "Iława"), EFFECTIVNESS.MEDIUM, 35));
            addFewWorkers(
                new ManualWorker("Bogdan", "Kowalski", 71, 40, new Address("Wielkopolska", "15", "-", "Poznań"), 35),
                new ManualWorker("Ryszard", "Terlecki", 81, 60, new Address("Wielkopolska", "15", "-", "Poznań"), 25),
                new OfficeWorker("Tomasz", "Kopyra", 43, 25, new Address("Gdzies", "25", "1", "Kraków"), 25),
                new Trader("Zbigniew", "Wielkonosy", 52, 15, new Address("Długa", "5", "1", "Białystok"), EFFECTIVNESS.LOW, 20)
                );
            Console.WriteLine(viewAllWorkers());
        }
    }
}