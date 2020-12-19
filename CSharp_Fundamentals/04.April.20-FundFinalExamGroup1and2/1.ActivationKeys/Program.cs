using System;
using System.Linq;
using System.Text;

namespace _1.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            StringBuilder result = new StringBuilder(activationKey);

            string input = Console.ReadLine();

            while (input != "Generate")
            {
                var command = input
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Contains")
                {
                    string substring = command[1];

                    if (result.ToString().Contains(substring))
                    {
                        Console.WriteLine($"{result} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!"); 
                    }

                }
                else if (command[0] == "Flip")
                {
                    int startIndex = int.Parse(command[2]);
                    int endIndex = int.Parse(command[3]);

                    string text = result.ToString().Substring(startIndex, endIndex - startIndex);

                    if (command[1] == "Upper")
                    {
                        result.Replace(text, text.ToUpper());

                        Console.WriteLine(result);
                    }
                    else if (command[1] == "Lower")
                    {
                        result.Replace(text, text.ToLower());

                        Console.WriteLine(result);
                    }

                }
                else if (command[0] == "Slice")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    result.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(result);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {result}");
        }
    }
}
