using System;

namespace ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int countProject = int.Parse(Console.ReadLine());

            Console.WriteLine($"The architect {name} will need {countProject * 3} hours to complete {countProject} project/s.");
        }
    }
}
