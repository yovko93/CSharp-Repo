using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            StringBuilder sb = new StringBuilder(message);

            string input = Console.ReadLine();

            while (input != "Decode")
            {
                var command = input.Split('|').ToArray();

                if (command[0] == "Move")
                {
                    int numOfLetters = int.Parse(command[1]);
                    string text = sb.ToString().Substring(0, numOfLetters);

                    sb.Remove(0, numOfLetters);
                    sb.Append(text);

                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[1]);
                    string value = command[2];

                    sb.Insert(index, value);
                }
                else if (command[0] == "ChangeAll")
                {
                    string substring = command[1];
                    string replacement = command[2];

                    sb.Replace(substring, replacement);
                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {sb}");
        }
    }
}
