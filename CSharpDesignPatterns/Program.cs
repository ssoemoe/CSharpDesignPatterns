using CSharpDesignPatterns.Creational_Patterns;
using System;

namespace CSharpDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var singleton = Singleton.Instance;
            Console.WriteLine(singleton);
            Console.ReadKey();
        }
    }
}
