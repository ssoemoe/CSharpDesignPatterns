///
/// Prototype pattern (properties pattern) - used for cloning (both shallow and deep)
/// puporse - to make properties available in a newly created instance.
/// structure - interface -> ConcretePrototype
///

using System;

public class Prototype
{
    public static void PrototypeTest()
    {
        // Test here
    }

    abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Student : Person, ICloneable
    {
        public int Grade { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone(); //shallow copy
        }
    }

    class Programmer : Person, ICloneable
    {
        public bool IsWoke { get; set; }
        public object Clone()
        {
            return new Programmer
            {
                Name = this.Name,
                Age = this.Age,
                IsWoke = this.IsWoke
            };
        }
    }
}