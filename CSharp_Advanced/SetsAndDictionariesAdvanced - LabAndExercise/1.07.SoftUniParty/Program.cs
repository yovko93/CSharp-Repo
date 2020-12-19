using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {

                if (char.IsDigit(input[0]))
                {
                    vip.Add(input);
                }
                else
                {
                    regular.Add(input);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                if (vip.Contains(input))
                {
                    vip.Remove(input);
                }
                else if (regular.Contains(input))
                {
                    regular.Remove(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(vip.Count + regular.Count);
            if (vip.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, vip));
            }
            if (regular.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, regular));
            }
        }
    }
}
