using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> partsOfWeapon = Console.ReadLine()
                .Split('|')
                .ToList();

            string input = Console.ReadLine();
            while (input != "Done")
            {
                string[] command = input.Split();

                if (command[0] == "Move")
                {
                    int index = int.Parse(command[2]);

                    if (command[1] == "Left")
                    {
                        if (index > 0 && index < partsOfWeapon.Count)
                        {
                            string temp = partsOfWeapon[index];
                            partsOfWeapon[index] = partsOfWeapon[index - 1];
                            partsOfWeapon[index - 1] = temp;
                        }
                    }
                    else if (command[1] == "Right")
                    {
                        if (index >= 0 && index < partsOfWeapon.Count - 1)
                        {
                            string temp = partsOfWeapon[index];
                            partsOfWeapon[index] = partsOfWeapon[index + 1];
                            partsOfWeapon[index + 1] = temp;
                        }
                    }
                }
                else if (command[0] == "Check")
                {
                    if (command[1] == "Even")
                    {
                        string evenIndexPosition = string.Empty;
                        for (int i = 0; i < partsOfWeapon.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                evenIndexPosition += partsOfWeapon[i] + " ";
                            }
                        }
                        Console.WriteLine(evenIndexPosition);
                    }
                    else if (command[1] == "Odd")
                    {
                        string oddIndexPosition = string.Empty;
                        for (int i = 0; i < partsOfWeapon.Count; i++)
                        {
                            if (i % 2 == 1)
                            {
                                oddIndexPosition += partsOfWeapon[i] + " ";
                            }
                        }
                        Console.WriteLine(oddIndexPosition);
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"You crafted {string.Join("", partsOfWeapon)}!");
        }
    }
}
