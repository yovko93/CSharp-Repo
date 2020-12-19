using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.EmailValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            StringBuilder sb = new StringBuilder(email);
            
            string input = Console.ReadLine();

            while (input != "Complete")
            {
                var command = input.Split().ToArray();

                if (command[0] == "Make")
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
                else if (command[0] == "GetDomain")
                {
                    int count = int.Parse(command[1]);
                    string lastChars = string.Concat(sb.ToString().TakeLast(count));

                    Console.WriteLine(lastChars);
                }
                else if (command[0] == "GetUsername")
                {
                    if (sb.ToString().Contains('@'))
                    {
                        int length = 0;
                        for (int i = 0; i < sb.Length; i++)
                        {
                            if (sb[i] == '@')
                            {
                                break;
                            }
                            length++;
                        }

                        string username = sb.ToString().Substring(0, length);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The email {sb} doesn't contain the @ symbol.");
                    }
                }
                else if (command[0] == "Replace")
                {
                    char currChar = char.Parse(command[1]);
                    sb.Replace(currChar, '-');
                    Console.WriteLine(sb);
                }
                else if (command[0] == "Encrypt")
                {
                    List<int> asciiValues = new List<int>();
                    int value = 0;
                    for (int i = 0; i < sb.Length; i++)
                    {
                        value = sb[i];
                        asciiValues.Add(value);
                    }

                    Console.WriteLine(string.Join(' ', asciiValues));
                }

                input = Console.ReadLine();
            }
        }
    }
}
