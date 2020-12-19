using System;
using System.Linq;

namespace _02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] command = input.Split();
                
                if (command[0] == "swap")
                {
                    int firstIndex = int.Parse(command[1]);
                    int secondIndex = int.Parse(command[2]);
                    int temp = array[firstIndex];
                    array[firstIndex] = array[secondIndex];
                    array[secondIndex] = temp;
                }
                else if (command[0] == "multiply")
                {
                    int firstIndex = int.Parse(command[1]);
                    int secondIndex = int.Parse(command[2]);
                    int firstElement = array[firstIndex];
                    int secondElement = array[secondIndex];
                    array[firstIndex] = firstElement * secondElement;
                }
                else if (input == "decrease")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] -= 1;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", array));
        }
    }
}
