using System;
/// <summary>
/// Four components in the adapter design pattern - Client, Target Interface, Adapter and Adaptee
/// One of the two adapter design patterns. 
///Used when Adapter class cannot inherit the Adaptee class
/// </summary>

namespace CSharpDesignPatterns.StructuralPatterns
{
    public class ObjectAdapter
    {
        // Client
        public static void TestDesign()
        {
            var bmwToyCar = new CarAdapter(new BMWCar());
            var toyotaToyCar = new CarAdapter(new ToyotaCar());
            bmwToyCar.MakeSound();
            toyotaToyCar.MakeSound();
        }
    }

    // Adaptee - has the original methods/properties which we want to adapt
    class Car
    {
        public virtual void Drive()
        {
            Console.WriteLine("Vroom Vroom");
        }
    }

    class ToyotaCar : Car
    {
        public override void Drive()
        {
            Console.WriteLine("Vroom Vroom but Toyota");
        }
    }

    class BMWCar : Car
    {
        public override void Drive()
        {
            Console.WriteLine("Vroom Vroom but BMW");
        }
    }

    // Target - we are trying to make this work. Can also have an interface and implement it too
    interface IToyCar
    {
        public void MakeSound();
    }

    // Adapter implements target interface and uses the adaptee's methods/properties
    class CarAdapter : IToyCar
    {
        private Car _car;
        public CarAdapter(Car car)
        {
            _car = car;
        }
        public void MakeSound()
        {
            _car.Drive();
        }
    }
}