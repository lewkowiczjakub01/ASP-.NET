using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Fabryki.Factory.FactoryWithMethod.MediumCarFactory;
using Fabryki.Factory.ReflectionFactory;
using Fabryki.Factory.AbstractFactory.MediumCarAbstractFactory;
using Fabryki.Factory.SimpleFactory.MediumSimpleFactory;
using Fabryki.Store;
using Fabryki.Elements.Engines;


public class MediumBenchmark
{
    MediumFactoryStore mediumFactoryStore = new MediumFactoryStore
        (
            new MediumCarSimpleFactory(),
            new MediumAudi(),
            new Skoda14TSI(),
            new MediumReflectionFactory()
        );

    public MediumBenchmark()
    {
        mediumFactoryStore = new MediumFactoryStore(new MediumCarSimpleFactory(), new MediumAudi(), new Skoda14TSI(), new MediumReflectionFactory());
    }

    [Benchmark]
    public void CreateCarWithSimpleFactory()
    {
        var car = mediumFactoryStore.createWithSimpleFactory("BMW", "black", new Engine2(), 2024);
    }

    [Benchmark]
    public void CreateCarWithFactoryWithMethod()
    {
        var car = mediumFactoryStore.createWithFactoryWithMethod("black", new Engine2(), 2024);
    }

    [Benchmark]
    public void CreateCarWithAbstractFactory()
    {
        var car = mediumFactoryStore.createWithAbstractFactory("black", 2024);
    }

    [Benchmark]
    public void CreateCarWithReflectionFactory()
    {
        var car = mediumFactoryStore.createWithReflectionFactory("BMW", "black", new Engine2(), 2024);
    }
}
