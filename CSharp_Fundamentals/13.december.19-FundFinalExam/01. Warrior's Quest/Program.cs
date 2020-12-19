using System;
using System.Linq;
using System.Text;

namespace _01._Warrior_s_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            //// не работи

            string skill = Console.ReadLine();

            StringBuilder result = new StringBuilder(skill);

            string input = Console.ReadLine();

            while (input != "For Azeroth")
            {
                var command = input.Split().ToArray();

                if (command[0] == "GladiatorStance")
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        if (char.IsLetter(result[i]))
                        {
                            result.Replace(result[i], char.Parse(result[i].ToString().ToUpper()));
                        }
                    }
                    Console.WriteLine(result);
                }
                else if (command[0] == "DefensiveStance")
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        if (char.IsLetter(result[i]))
                        {
                            result.Replace(result[i], char.Parse(result[i].ToString().ToLower()));
                        }
                    }
                    Console.WriteLine(result);
                }
                else if (command[0] == "Dispel")
                {
                    int index = int.Parse(command[1]);
                    char letter = char.Parse(command[2]);

                    if (index < 0 || index > result.Length - 1)
                    {
                        Console.WriteLine("Dispel too weak.");
                    }
                    else
                    {
                        char oldLetter = char.Parse(result[index].ToString());
                        result.Replace(oldLetter, letter);
                        Console.WriteLine("Success!");
                    }
                }
                else if (command[0] == "Target" && command[1] == "Change")
                {
                    string substring = command[2];

                    string secondSubstring = command[3];
                    result.Replace(substring, secondSubstring);
                    Console.WriteLine(result);
                }
                else if (command[0] == "Target" && command[1] == "Remove")
                {
                    string substring = command[2];
                    int index = result.ToString().IndexOf(substring);
                    result.Remove(index, substring.Length);
                    Console.WriteLine(result);
                }
                
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }

                input = Console.ReadLine();
            }

        }
    }
}
