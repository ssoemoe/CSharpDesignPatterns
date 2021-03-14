﻿using CSharpDesignPatterns.Creational_Patterns;
using CSharpDesignPatterns.StructuralPatterns;
using System;

namespace CSharpDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var singleton = Singleton.Instance;
            Console.WriteLine(singleton.ToString());
            var lazySingleton = LazySingleton.Instance;
            Console.WriteLine(lazySingleton.ToString());
            Console.ReadKey();
        }
    }
}
