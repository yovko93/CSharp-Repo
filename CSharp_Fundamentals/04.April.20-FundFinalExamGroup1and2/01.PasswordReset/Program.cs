using System;
using System.Linq;
using System.Text;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder password = new StringBuilder(text);

            string input = Console.ReadLine();

            while (input != "Done")
            {
                var command = input.Split().ToArray();

                if (command[0] == "TakeOdd")
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 == 1)
                        {
                            sb.Append((char)password[i]);
                        }
                    }
                    password = sb;
                    Console.WriteLine(password);
                }
                else if (command[0] == "Cut")
                {
                    int index = int.Parse(command[1]);
                    int length = int.Parse(command[2]);

                    password.Remove(index, length);
                    Console.WriteLine(password);
                }
                else if (command[0] == "Substitute")
                {
                    string substring = command[1];
                    string substitute = command[2];

                    if (password.ToString().Contains(substring))
                    {
                        password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                input = Console.ReadLine();
            }
            
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
