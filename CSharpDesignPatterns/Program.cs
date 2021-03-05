using CSharpDesignPatterns.Creational_Patterns;
using System;

namespace CSharpDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder.BuildGetRequest();
            Builder.BuildPostRequest();
            Console.ReadKey();
        }
    }
}
