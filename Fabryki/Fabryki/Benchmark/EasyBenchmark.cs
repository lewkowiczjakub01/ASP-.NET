using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Fabryki.Factory.FactoryWithMethod.EasyCarFactory;
using Fabryki.Factory.ReflectionFactory;
using Fabryki.Factory.AbstractFactory.EasyCarAbstractFactory;
using Fabryki.Factory.SimpleFactory.EasySimpleFactory;
using Fabryki.Store;


public class EasyBenchmark
{
    EasyFactoryStore easyFactoryStore = new EasyFactoryStore
        (
            new EasyCarSimpleFactory(),
            new EasyAudi(),
            new Skoda(),
            new EasyReflectionFactory()
        );

    public EasyBenchmark()
    {
        easyFactoryStore = new EasyFactoryStore(new EasyCarSimpleFactory(), new EasyAudi(), new Skoda(), new EasyReflectionFactory());
    }

    [Benchmark]
    public void CreateCarWithSimpleFactory()
    {
        var car = easyFactoryStore.createWithSimpleFactory("BMW", "black");
    }

    [Benchmark]
    public void CreateCarWithFactoryWithMethod()
    {
        var car = easyFactoryStore.createWithFactoryWithMethod("black");
    }

    [Benchmark]
    public void CreateCarWithAbstractFactory()
    {
        var car = easyFactoryStore.createWithAbstractFactory("black");
    }

    [Benchmark]
    public void CreateCarWithReflectionFactory()
    {
        var car = easyFactoryStore.createWithReflectionFactory("BMW", "black");
    }
}
