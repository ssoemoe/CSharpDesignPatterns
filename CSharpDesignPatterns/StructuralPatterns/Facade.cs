using System.Threading.Tasks;
using System;

namespace CSharpDesignPatterns.StructuralPatterns
{
    public class Facade
    {
        public static void TestDesign()
        {
            var executor = new Executor();
            executor.Execute();
        }
    }

    // Facade class
    class Executor
    {
        public void Execute()
        {
            var s1 = new SubSystem1();
            var s2 = new SubSystem2();
            var s3 = new SubSystem3();
            Parallel.Invoke(() => s1.Method(), () => s2.Method(), () => s3.Method());
        }
    }

    class SubSystem1
    {
        public void Method() { Console.WriteLine($"Executing {nameof(SubSystem1)}"); }
    }

    class SubSystem2
    {
        public void Method() { Console.WriteLine($"Executing {nameof(SubSystem2)}"); }
    }

    class SubSystem3
    {
        public void Method() { Console.WriteLine($"Executing {nameof(SubSystem3)}"); }
    }
}