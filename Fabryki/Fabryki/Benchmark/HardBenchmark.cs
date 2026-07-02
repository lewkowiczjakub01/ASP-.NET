using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Fabryki.Factory.FactoryWithMethod.HardCarFactory;
using Fabryki.Factory.ReflectionFactory;
using Fabryki.Factory.AbstractFactory.HardCarAbstractFactory;
using Fabryki.Factory.SimpleFactory.HardSimpleFactory;
using Fabryki.Store;
using Fabryki.Elements.Engines;
using Fabryki.Elements.Guarantee;
using Fabryki.Elements.Equipments;


public class HardBenchmark
{
    HardFactoryStore hardFactoryStore = new HardFactoryStore
        (
            new HardCarSimpleFactory(),
            new HardAudi(),
            new Skoda14TSIB(),
            new HardReflectionFactory()
        );

    public HardBenchmark()
    {
        hardFactoryStore = new HardFactoryStore(new HardCarSimpleFactory(), new HardAudi(), new Skoda14TSIB(), new HardReflectionFactory());
    }

    [Benchmark]
    public void CreateCarWithSimpleFactory()
    {
        var car = hardFactoryStore.createWithSimpleFactory("BMW", "black", new Engine2(), 2024, new FullGuarantee());
    }

    [Benchmark]
    public void CreateCarWithFactoryWithMethod()
    {
        List<string> equipment = new List<string> { Equipment.AC, Equipment.HeatedSeats, Equipment.AlloyWheels, Equipment.LeatherSeats };
        var car = hardFactoryStore.createWithFactoryWithMethod("black", new Engine2(), 2024, equipment, new FullGuarantee());
    }

    [Benchmark]
    public void CreateCarWithAbstractFactory()
    {
        var car = hardFactoryStore.createWithAbstractFactory("black", 2024);
    }

    [Benchmark]
    public void CreateCarWithReflectionFactory()
    {
        List<string> equipment = new List<string> { Equipment.AC, Equipment.HeatedSeats, Equipment.AlloyWheels, Equipment.LeatherSeats };
        var car = hardFactoryStore.createWithReflectionFactory("BMW", "black", new Engine2(), 2024, equipment, new FullGuarantee());
    }
}
