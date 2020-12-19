using System;
using System.Linq;
using System.Text;

namespace _01.Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            StringBuilder sb = new StringBuilder(username);

            string input = Console.ReadLine();

            while (input != "Sign up")
            {
                var command = input.Split().ToArray();

                switch (command[0])
                {
                    case "Case":
                        if (command[1] == "lower")
                        {
                            for (int i = 0; i < sb.Length; i++)
                            {
                                if (char.IsLetter(sb[i]))
                                {
                                    sb[i] = char.Parse(sb[i].ToString().ToLower());
                                }
                            }
                        }
                        else if (command[1] == "upper")
                        {
                            for (int i = 0; i < sb.Length; i++)
                            {
                                if (char.IsLetter(sb[i]))
                                {
                                    sb[i] = char.Parse(sb[i].ToString().ToUpper());
                                }
                            }
                        }
                        Console.WriteLine(sb);
                        break;

                    case "Reverse":
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);

                        if (startIndex >= 0 
                            && endIndex > startIndex 
                            && endIndex < sb.Length)
                        {
                            string text = sb.ToString().Substring(startIndex, endIndex - startIndex + 1);

                            string reversed = "";

                            for (int i = text.Length - 1; i >= 0; i--)
                            {
                                reversed += text[i];
                            }
                            Console.WriteLine(reversed);
                        }
                        break;
                    case "Cut":
                        string substring = command[1];

                        if (sb.ToString().Contains(substring))
                        {
                            int index = sb.ToString().IndexOf(substring);

                            sb.Remove(index, substring.Length);
                            Console.WriteLine(sb);
                        }
                        else
                        {
                            Console.WriteLine($"The word {sb} doesn't contain {substring}.");
                        }
                        break;
                    case "Replace":
                        char oldChar = char.Parse(command[1]);

                        sb.Replace(oldChar, '*');

                        Console.WriteLine(sb);
                        break;
                    case "Check":
                        char currentChar = char.Parse(command[1]);

                        if (sb.ToString().Contains(currentChar))
                        {
                            Console.WriteLine("Valid");
                        }
                        else
                        {
                            Console.WriteLine($"Your username must contain {currentChar}.");
                        }

                        break;

                }


                input = Console.ReadLine();
            }
        }
    }
}
