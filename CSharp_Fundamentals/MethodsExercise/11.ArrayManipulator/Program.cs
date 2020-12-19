using System;
using System.Linq;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split(); //["exchange", "1"]

                if (command[0] == "exchange")
                {
                    int index = int.Parse(command[1]);

                    if (index < 0 || index > arr.Length - 1)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    Exchange(arr, index);
                }
                else if (command[0] == "max")
                {
                    if (command[1] == "even")
                    {
                        if (MaxEven(arr) == - 1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        Console.WriteLine(MaxEven(arr));
                    }
                    else if (command[1] == "odd")
                    {
                        if (MaxOdd(arr) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        Console.WriteLine(MaxOdd(arr));
                    }
                }
                else if (command[0] == "min")
                {
                    if (command[1] == "even")
                    {
                        if (MinEven(arr) == - 1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        Console.WriteLine(MinEven(arr));
                    }
                    else if (command[1] == "odd")
                    {
                        if (MinOdd(arr) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        Console.WriteLine(MinOdd(arr));
                    }
                }
                else if (command[0] == "first")
                {
                    int count = int.Parse(command[1]);
                    if (count > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    if (command[2] == "even")
                    {
                        ReturnFirstCountEven(arr, count);
                    }
                    else if (command[2] == "odd")
                    {
                        ReturnFirstCountOdd(arr, count);
                    }
                }
                else if (command[0] == "last")
                {
                    int count = int.Parse(command[1]);
                    if (count > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    if (command[2] == "even")
                    {
                        ReturnLastEven(arr, count);
                    }
                    else if (command[2] == "odd")
                    {
                        ReturnLastOdd(arr, count);
                    }
                }
            }

            Console.WriteLine("[" + string.Join(", ", arr) + "]");
        }
        
        static void Exchange(int[] array, int index)
        {
            //1 3 5 7 9  -- exchange 1
            // firstArr = 5 7 9
            // secondArr = 1 3
            // array = 5 7 9 1 3
            int[] firstArr = new int[array.Length - 1 - index]; //lenght 3
            int[] secondArr = new int[index + 1]; //length 2 /// 1 3 

            int firstArrCounter = 0;
            for (int i = index + 1; i < array.Length; i++)
            {
                firstArr[firstArrCounter] = array[i];
                firstArrCounter++;
            }

            for (int i = 0; i < index + 1; i++)
            {
                secondArr[i] = array[i];
            }

            for (int i = 0; i < firstArr.Length; i++)
            {
                array[i] = firstArr[i];
            }

            for (int i = 0; i < secondArr.Length; i++)
            {
                array[firstArr.Length + i] = secondArr[i];
            }
        }
        
        static int MaxEven(int[] array)
        {
            int index = -1;
            int maxEven = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (array[i] >= maxEven)
                    {
                        maxEven = array[i];
                        index = i;
                    }
                }
            }
            return index;
        }

        static int MaxOdd(int[] array)
        {
            int index = -1;
            int maxOdd = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    if (array[i] >= maxOdd)
                    {
                        maxOdd = array[i];
                        index = i;
                    }
                }
            }
            return index;
        }

        static int MinEven(int[] array)
        {
            int index = -1;
            int minEven = int.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (array[i] <= minEven)
                    {
                        minEven = array[i];
                        index = i;
                    }
                }
            }
            return index;
        }

        static int MinOdd(int[] array)
        {
            int index = -1;
            int minOdd = int.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    if (array[i] <= minOdd)
                    {
                        minOdd = array[i];
                        index = i;
                    }
                }
            }
            return index;
        }

        static void ReturnFirstCountEven(int[] array, int count)
        {
            string numbers = string.Empty;
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }

                if (counter == count)
                {
                    break;
                }
            }

            var result = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + string.Join(", ", result) + "]");
            }
        }

        static void ReturnFirstCountOdd(int[] array, int count)
        {
            string numbers = string.Empty;
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }

                if (counter == count)
                {
                    break;
                }
            }

            var result = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + string.Join(", ", result) + "]");
            }
        }

        static void ReturnLastEven(int[] array, int count)
        {
            string numbers = string.Empty;
            int counter = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 == 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }
                if (counter == count)
                {
                    break;
                }
            }

            var result = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse();

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + string.Join(", ", result) + "]");
            }
        }

        static void ReturnLastOdd(int[] array, int count)
        {
            string numbers = string.Empty;
            int counter = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 != 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }
                if (counter == count)
                {
                    break;
                }
            }

            var result = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse();

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + string.Join(", ", result) + "]");
            }
        }
    }
}
