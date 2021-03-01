/// <summary>
/// Abstract Factory is a derivative of Factory Method design pattern. The difference between two patterns is that
/// Abstract Factory includes multiple factory methods in the abstract class/interface.
/// </summary>

using System;

namespace CSharpDesignPatterns.Creational_Patterns
{
    class AbstractFactory
    {
        public static void TestAbstractFactory()
        {
            var factoryA = new FactoryA();
            var cup = factoryA.GetCup("coffee");
            Console.WriteLine($"Coffee mug is produced: {cup.GetType() == typeof(Mug)}");
            var glass = factoryA.GetGlass("wine");
            Console.WriteLine($"Wine glass is produced: {glass.GetType() == typeof(WineGlass)}");
        }
    }

    interface Cup { 
        // properties and/or methods of a cup 
    }

    interface Glass
    {
        //properties and/or methods of a glass
    }

    class Mug : Cup { }
    class TeaCup : Cup { }

    class WineGlass : Glass { }
    class ChampagneFlute : Glass { }

    /// <summary>
    /// Abstract Factory class with two Factory Methods
    /// </summary>
    abstract class LiquidContainerFactory
    {
        public abstract Cup GetCup(string cupType);
        public abstract Glass GetGlass(string glassType);
    }

    /// <summary>
    /// Abstract Factory class implmentation
    /// </summary>
    class FactoryA : LiquidContainerFactory
    {
        public override Cup GetCup(string cupType)
        {
            switch(cupType.ToLower())
            {
                case "tea": return new TeaCup();
                case "coffee": return new Mug();
                default: return null;
            }
        }

        public override Glass GetGlass(string glassType)
        {
            switch (glassType.ToLower())
            {
                case "wine": return new WineGlass();
                case "champagne": return new ChampagneFlute();
                default: return null;
            }
        }
    }

}
