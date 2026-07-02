using Fabryki.Store;
using Fabryki.Factory.SimpleFactory.EasySimpleFactory;
using Fabryki.Factory.FactoryWithMethod.EasyCarFactory;
using Fabryki.Factory.AbstractFactory.EasyCarAbstractFactory;
using Fabryki.Factory.SimpleFactory.MediumSimpleFactory;
using Fabryki.Factory.FactoryWithMethod.MediumCarFactory;
using Fabryki.Factory.AbstractFactory.MediumCarAbstractFactory;
using Fabryki.Factory.SimpleFactory.HardSimpleFactory;
using Fabryki.Factory.AbstractFactory.HardCarAbstractFactory;
using Fabryki.Factory.FactoryWithMethod.HardCarFactory;
using Fabryki.Factory.ReflectionFactory;
using Fabryki.Elements.Engines;
using Fabryki.Elements.Guarantee;
using Fabryki.Elements.Equipments;
using BenchmarkDotNet.Running;

public class main
{
    public static void Main(String[] args)
    {
        /*        EasyFactoryStore easyFactoryStore = new EasyFactoryStore
                    (
                        new EasyCarSimpleFactory(),
                        new EasyAudi(),
                        new Skoda(),
                        new EasyReflectionFactory()
                    );

                MediumFactoryStore mediumFactoryStore = new MediumFactoryStore
                    (
                        new MediumCarSimpleFactory(),
                        new MediumAudi(),
                        new Skoda14TSI(),
                        new MediumReflectionFactory()
                    );

                HardFactoryStore hardFactoryStore = new HardFactoryStore
                    (
                        new HardCarSimpleFactory(),
                        new HardAudi(),
                        new Skoda14TSIB(),
                        new HardReflectionFactory()
                    );


                Fabryki.Cars.Hard.Car carFromSimpleFactory = hardFactoryStore.createWithSimpleFactory("BMW", "black", new Engine2(), 2024, new ExtendedGuarantee());
                Console.WriteLine(carFromSimpleFactory.mark);
                Console.WriteLine(carFromSimpleFactory.color);
                Console.WriteLine(carFromSimpleFactory.yearOfProduction);
                carFromSimpleFactory.engine.prepareEngine();
                carFromSimpleFactory.guarantee.prepareGuarantee();
                foreach (var elem in carFromSimpleFactory.equipment)
                    Console.WriteLine(elem);

                Console.WriteLine("********************************************************************************");
                Fabryki.Cars.Hard.Car carFromAbstractFactory = hardFactoryStore.createWithAbstractFactory("black", 2024);
                Console.WriteLine(carFromAbstractFactory.mark);
                Console.WriteLine(carFromAbstractFactory.color);
                Console.WriteLine(carFromAbstractFactory.yearOfProduction);
                carFromAbstractFactory.engine.prepareEngine();
                carFromAbstractFactory.guarantee.prepareGuarantee();
                foreach (var elem in carFromAbstractFactory.equipment)
                    Console.WriteLine(elem);

                Console.WriteLine("********************************************************************************");
                List<string> equipment = new List<string> { Equipment.AC, Equipment.HeatedSeats, Equipment.AlloyWheels, Equipment.LeatherSeats };
                Fabryki.Cars.Hard.Car carFromReflectionFactory = hardFactoryStore.createWithReflectionFactory("Audi", "white", new Engine3(), 2024, equipment, new FullGuarantee());
                Console.WriteLine(carFromReflectionFactory.mark);
                Console.WriteLine(carFromReflectionFactory.color);
                Console.WriteLine(carFromReflectionFactory.yearOfProduction);
                carFromReflectionFactory.engine.prepareEngine();
                carFromReflectionFactory.guarantee.prepareGuarantee();
                foreach (var elem in carFromReflectionFactory.equipment)
                    Console.WriteLine(elem);*/


        //var easySummary = BenchmarkRunner.Run<EasyBenchmark>();
        //var mediumSummary = BenchmarkRunner.Run<MediumBenchmark>();
        var hardSummary = BenchmarkRunner.Run<HardBenchmark>();
        /*

        

        Fabryki.Cars.Easy.Car carFromReflectionFactoryEasy = easyFactoryStore.createWithReflectionFactory("Audi", "white");
        Console.WriteLine(carFromReflectionFactoryEasy.mark);
        Console.WriteLine(carFromReflectionFactoryEasy.color);

        Console.WriteLine("********************************************************************************");
        //List<string> equipment = new List<string> { Equipment.AC, Equipment.HeatedSeats, Equipment.AlloyWheels, Equipment.LeatherSeats };
        Fabryki.Cars.Medium.Car carFromReflectionFactory = mediumFactoryStore.createWithReflectionFactory("Audi", "white", new Engine2(), 2024);
        Console.WriteLine(carFromReflectionFactory.mark);
        Console.WriteLine(carFromReflectionFactory.color);
        Console.WriteLine(carFromReflectionFactory.yearOfProduction);
        carFromReflectionFactory.engine.prepareEngine();
        */
    }
}