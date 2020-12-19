using System;

namespace _01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string dataType = string.Empty;

            while (input != "END")
            {
                bool isBoolean = bool.TryParse(input, out bool boolean);
                bool isInteger = int.TryParse(input, out int integer);
                bool isChar = char.TryParse(input, out char character);
                bool isDouble = double.TryParse(input, out double floating);

                if (isBoolean)
                {
                    dataType = "boolean";
                }
                else if (isInteger)
                {
                    dataType = "integer";
                }
                else if (isChar)
                {
                    dataType = "character";
                }
                else if (isDouble)
                {
                    dataType = "floating point";
                }
                else
                {
                    dataType = "string";
                }

                Console.WriteLine($"{input} is {dataType} type");
                input = Console.ReadLine();
            }
        }
    }
}
