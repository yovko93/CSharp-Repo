using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;
            int count = 0;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();
                if (command[0] == "Add" || command[0] == "Remove" || command[0] == "RemoveAt" || command[0] == "Insert")
                {
                    count++;
                }
                if (command[0] == "Add")
                {
                    int n = int.Parse(command[1]);
                    numbers.Add(n);
                }
                else if (command[0] == "Remove")
                {
                    int n = int.Parse(command[1]);
                    numbers.Remove(n);
                }
                else if (command[0] == "RemoveAt")
                {
                    int n = int.Parse(command[1]);
                    numbers.RemoveAt(n);
                }
                else if (command[0] == "Insert")
                {
                    int n = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    numbers.Insert(index, n);
                }
                else if (command[0] == "Contains")
                {
                    int num = int.Parse(command[1]);

                    if (numbers.Contains(num))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (command[0] == "PrintEven")
                {
                    PrintEven(numbers);
                }
                else if (command[0] == "PrintOdd")
                {
                    PrintOdd(numbers);
                }
                else if (command[0] == "GetSum")
                {
                    //Console.WriteLine(numbers.Sum());
                    Console.WriteLine(GetSum(numbers));
                }
                else if (command[0] == "Filter")
                {
                    List<int> filter = new List<int>(numbers);
                    string condition = command[1];
                    int n = int.Parse(command[2]);

                    PrintFilter(filter, condition, n);
                    
                }
            }

            if (count > 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
        
        static void PrintEven(List<int> nums)
        {
            List<int> evenNums = new List<int>();

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    evenNums.Add(nums[i]);
                }
            }

            Console.WriteLine(string.Join(" ", evenNums));
        }

        static void PrintOdd(List<int> nums)
        {
            List<int> oddNums = new List<int>();

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 != 0)
                {
                    oddNums.Add(nums[i]);
                }
            }

            Console.WriteLine(string.Join(" ", oddNums));
        }

        static int GetSum(List<int> nums)
        {
            int sum = 0;

            for (int i = 0; i < nums.Count; i++)
            {
                sum += nums[i];
            }

            return sum;
        }

        static void PrintFilter(List<int> nums, string condition, int n)
        {
            List<int> finalList = new List<int>();

            if (condition == "<")
            {
               finalList = nums.FindAll(items => items < n);
            }
            else if (condition == ">")
            {
                finalList = nums.FindAll(items => items > n);
            }
            else if (condition == ">=")
            {
                finalList = nums.FindAll(items => items >= n);
            }
            else if (condition == "<=")
            {
                finalList = nums.FindAll(items => items <= n);
            }

            Console.WriteLine(string.Join(" ", finalList));
        }
    }
}
