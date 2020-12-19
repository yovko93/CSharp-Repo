using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split().ToArray();
                string name = info[0];
                decimal salary = decimal.Parse(info[1]);
                string department = info[2];

                Employee employee = new Employee(name, salary, department);

                employees.Add(employee);
            }


        }

        public class Employee
        {
            public string Name { get; set; }

            public decimal Salary { get; set; }

            public string Department { get; set; }

            public Employee(string name, decimal salary, string department)
            {
                this.Name = name;
                this.Salary = salary;
                this.Department = department;
            }

        }
    }
}
