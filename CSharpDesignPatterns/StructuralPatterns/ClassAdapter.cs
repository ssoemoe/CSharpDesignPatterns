using System;

///<summary>
/// Class adpater pattern just inherits the Adaptee class and implmenets the target interface at the same time.
///</summary>
namespace CSharpDesignPatterns.StructuralPatterns
{
    public class ClassAdapter
    {
        public static void TestDesign()
        {
            var carAdapter = new CarClassAdapter();
            carAdapter.MakeSound();
        }
    }
    // Class adapater 
    // Target interface and Adaptee class are in ObjectAdapter.cs file
    class CarClassAdapter : ToyotaCar, IToyCar
    {
        public void MakeSound()
        {
            this.Drive();
        }
    }
}