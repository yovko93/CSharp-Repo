using System;
using System.Linq;
using System.Text;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double sum = 0;
            
            for (int i = 0; i < input.Length; i++)
            {
                string currentText = input[i];

                char letterBefore = currentText[0];
                char letterAfter = currentText[currentText.Length - 1];
                double number = double.Parse(currentText.Substring(1, currentText.Length - 2));

                int letterBeforePosition = char.Parse(letterBefore.ToString().ToUpper()) - 64;
                int letterAfterPosition = char.Parse(letterAfter.ToString().ToUpper()) - 64;
                
                if (letterBefore >= 65 && letterBefore <= 90)
                {
                   number /= letterBeforePosition;
                }
                else
                {
                    number *= letterBeforePosition;
                }

                if (letterAfter >= 65 && letterAfter <= 90)
                {
                    number -= letterAfterPosition;
                }
                else
                {
                    number += letterAfterPosition;
                }

                sum += number;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
