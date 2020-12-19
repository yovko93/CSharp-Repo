using System;

namespace _1.Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string aniBook = Console.ReadLine();
            int capacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            int counter = 0;

            while (command != aniBook && counter < capacity)
            {
                counter++;
                if (counter == capacity)
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    break;
                }
                command = Console.ReadLine();
            }

            if (aniBook == command)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }

        }
    }
}
