using System;

///<summary>
/// Main components are - 
/// abstract class, refined abstract classes (if required), and
/// interface, classes which implement the interface
///</summary>
namespace CSharpDesignPatterns.StructuralPatterns
{
    public class Bridge
    {
        public static void TestDesign()
        {
            var rawMaterialFactory = new RawMaterialFactory();
            var assemblyFactory = new AssemblyFactory();

            var toyotaCarToy = new CarToy(new Factory[] { rawMaterialFactory, assemblyFactory })
            {
                Brand = "Toyota",
                Name = "Car model"
            };
            var birdToy = new BirdToy(new Factory[] { assemblyFactory })
            {
                Brand = "Quack Quack",
                Name = "Owl"
            };

            toyotaCarToy.PrepareForMarket();
            birdToy.PrepareForMarket();
        }
    }

    // Interface
    interface Factory
    {
        public void Produce();
    }

    // Implementations
    class RawMaterialFactory : Factory
    {
        public void Produce()
        {
            Console.WriteLine("Producing Raw Materials");
        }
    }

    class AssemblyFactory : Factory
    {
        public void Produce()
        {
            Console.WriteLine("Assembling toys is complete");
        }
    }

    //Abstract class
    abstract class Toy
    {
        private Factory[] _factories;
        public Toy(Factory[] factories)
        {
            _factories = factories;
        }
        public string Brand { get; set; }
        public string Name { get; set; }
        public void PrepareForMarket()
        {
            foreach (var factory in _factories)
            {
                Console.WriteLine($"{Brand}, {Name}");
                factory.Produce();
            }
        }
    }

    // Abstractions
    class CarToy : Toy
    {
        public CarToy(Factory[] factories) : base(factories)
        {
        }
    }
    class BirdToy : Toy
    {
        public BirdToy(Factory[] factories) : base(factories)
        {
        }
    }
}