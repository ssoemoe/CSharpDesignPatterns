using System.Collections.Generic;

namespace CSharpDesignPatterns.StructuralPatterns
{
    public class Composite
    {
        public static void TestDesign()
        {
            var company = new Company { Name = "Company Demo" };

            var CEO = new Manager { Name = "Steve Jobs", Id = 1, Responsibilities = "Creatively sell products and improve the company with visions" };
            company.employees.Add(CEO);

            var CFO = new Manager { Name = "Beth Harmon", Id = 2, Responsibilities = "Analyzes and manages the finance of the company" };
            var CIO = new Manager { Name = "Steve Wozniak", Id = 3, Responsibilities = "Research & Development" };
            CEO.Subordinates.AddRange(new Employee[] { CFO, CIO });

            var salesHead = new Manager { Name = "David Jones", Id = 4, Responsibilities = "Increase sales" };
            var marketingHead = new Manager { Name = "Nancy James", Id = 5, Responsibilities = "Promote the company brand" };
            var accountingHead = new Manager { Name = "Elizabeth Buffet", Id = 5, Responsibilities = "Calculates the payroll and taxes of the company." };
            CFO.Subordinates.AddRange(new Employee[] { salesHead, marketingHead, accountingHead });

            // and heirarchy goes on ....
        }
    }

    // Leaf class
    abstract class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Responsibilities { get; set; }
    }

    // Composite class
    class Manager : Employee
    {
        public List<Employee> Subordinates = new List<Employee>();
    }

    // Composite class
    class Company
    {
        public string Name { get; set; }
        public List<Employee> employees { get; set; } = new List<Employee>();
    }
}