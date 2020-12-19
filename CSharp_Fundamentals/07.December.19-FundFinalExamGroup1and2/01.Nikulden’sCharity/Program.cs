using System;
using System.Linq;
using System.Text;

namespace _01.Nikulden_sCharity
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            StringBuilder sb = new StringBuilder(message);

            string input = Console.ReadLine();

            while (input != "Finish")
            {
                var command = input.Split().ToArray();

                if (command[0] == "Replace")
                {
                    string currentChar = command[1];
                    string newChar = command[2];

                    sb.Replace(currentChar, newChar);
                    Console.WriteLine(sb);
                }
                else if (command[0] == "Cut")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (startIndex >= 0 && endIndex >= startIndex && endIndex < sb.Length)
                    {
                        sb.Remove(startIndex, endIndex - startIndex + 1);
                        Console.WriteLine(sb);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
                else if (command[0] == "Make")
                {
                    if (command[1] == "Upper")
                    {
                        for (int i = 0; i < sb.Length; i++)
                        {
                            if (char.IsLetter(sb[i]))
                            {
                                sb[i] = char.Parse(sb[i].ToString().ToUpper());
                            }
                        }
                        Console.WriteLine(sb);
                    }
                    else if (command[1] == "Lower")
                    {
                        for (int i = 0; i < sb.Length; i++)
                        {
                            if (char.IsLetter(sb[i]))
                            {
                                sb[i] = char.Parse(sb[i].ToString().ToLower());
                            }
                        }
                        Console.WriteLine(sb);
                    }
                }
                else if (command[0] == "Check")
                {
                    string text = command[1];

                    if (sb.ToString().Contains(text))
                    {
                        Console.WriteLine($"Message contains {text}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {text}");
                    }
                }
                else if (command[0] == "Sum")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (startIndex >= 0 && endIndex >= startIndex && endIndex < sb.Length)
                    {
                        int sum = 0;
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            sum += sb[i];
                        }
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
