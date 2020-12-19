using System;

namespace _7.Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= n; i++)
            {
                string command = Console.ReadLine();
                if (command == "Facebook")
                {
                    salary -= 150;
                }
                else if (command == "Instagram")
                {
                    salary -= 100;
                }
                else if (command == "Reddit")
                {
                    salary -= 50;
                }
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    return;
                }
            }       
                Console.WriteLine(salary);         
        }
    }
}
