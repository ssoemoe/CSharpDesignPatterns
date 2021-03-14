///
/// Prototype pattern (properties pattern) - used for cloning (both shallow and deep)
/// puporse - to make properties available in a newly created instance.
/// structure - interface -> ConcretePrototype
/// MemberwiseClone() shallow copies the reference types and copies only non-static fields
///

using System;

public class Prototype
{
    public static void TestDesign()
    {
        var address = new Address
        {
            No = 10,
            Street = "Test St.",
            Building = "APT 101",
            City = "Rocky City",
            State = "AZ",
            Zipcode = 20987
        };
        var student = new Student
        {
            Name = "Student A",
            Age = 18,
            Grade = 12,
            Address = address
        };
        var clonedStudent = (Student)student.Clone();
        clonedStudent.Address.No = 800;
        Console.WriteLine($"Cloned student's building number: {clonedStudent.Address.No}");
        Console.WriteLine($"Address ref building number: {address.No}");
        var programmer = new Programmer
        {
            Name = "Programmer",
            Age = 23,
            IsWoke = true,
            Address = address
        };
        var clonedProgrammer = (Programmer)programmer.Clone();
        clonedProgrammer.Address.State = "WA";
        Console.WriteLine($"Cloned programmer's state: {clonedProgrammer.Address.State}");
        Console.WriteLine($"Original address ref state: {address.State}");
    }

    abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
    }

    public class Address : ICloneable
    {
        public int No { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    class Student : Person, ICloneable
    {
        public int Grade { get; set; }

        // Shallow copy
        public object Clone()
        {
            return this.MemberwiseClone(); //Changes to Address of the clone will affect the original object
        }
    }

    class Programmer : Person, ICloneable
    {
        public bool IsWoke { get; set; }

        // Deep copy
        public object Clone()
        {
            var prototype = (Programmer)this.MemberwiseClone();
            prototype.Address = (Address)this.Address.Clone();
            return prototype;
        }
    }
}