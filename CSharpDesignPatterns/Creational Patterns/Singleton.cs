﻿using System;
/// <summary>
/// Singleton pattern is used when only one instance is good enought and can be shared across the application.
/// Consider thread-safety for singleton instance
/// Preferrably use "sealed" modifier to prevent inheritance in other classes.
/// Constructor must be private and parameterless
/// </summary>
namespace CSharpDesignPatterns.Creational_Patterns
{
    public sealed class Singleton
    {
        private static Singleton _instance = null;
        private static readonly object _lock = new object(); // object level lock for multi-threading
        public static Singleton Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance == null ? new Singleton() : _instance;
                }
            }
        }

        private Singleton()
        {

        }

        public override string ToString()
        {
            return "Singleton is working!";
        }
    }

    // Lazy instantiation of singleton class
    public sealed class LazySingleton
    {
        private static readonly Lazy<LazySingleton> lazySingletonInstance = new Lazy<LazySingleton>(() => new LazySingleton());
        public static LazySingleton Instance
        {
            get
            {
                return lazySingletonInstance.Value;
            }
        }
        private LazySingleton()
        {

        }

        public override string ToString()
        {
            return "This is lazy singleton";
        }
    }
}
