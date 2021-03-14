using System;

namespace CSharpDesignPatterns.Misc
{
    public class FluentInterfaceDesign
    {
        public static void TestDesign()
        {
            var person = new Person();
            person.SetAddress("Testing address").SetAge(10).SetName("Shane Moe");
            Console.WriteLine(person.ToString());
        }
    }

    // Method chaining and can set properties in any order
    class Person
    {
        private string _name, _address;
        private int _age;
        public Person SetName(string name)
        {
            _name = name;
            return this;
        }

        public Person SetAge(int age)
        {
            _age = age;
            return this;
        }

        public Person SetAddress(string address)
        {
            _address = address;
            return this;
        }

        public override string ToString()
        {
            return $"Name: {_name}{Environment.NewLine}Age: {_age}{Environment.NewLine}Address: {_address}{Environment.NewLine}";
        }
    }
}