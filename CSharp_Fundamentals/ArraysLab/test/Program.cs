using System;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfWagons = int.Parse(Console.ReadLine());
            int[] people = new int[countOfWagons];
            
            for (int i = 0; i < countOfWagons; i++)
            {
                people[i] = int.Parse(Console.ReadLine());
             
            }
            Console.WriteLine(string.Join(" ",people));
            Console.WriteLine(people.Sum());
        }
    }
}
