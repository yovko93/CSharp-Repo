using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._07TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] data = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string vlogger = data[0];
                string action = data[1];
                string followedVlogger = data[2];

                if (action == "joined")
                {
                  

                }
                else if (action == "followed")
                {

                }


                input = Console.ReadLine();
            }



            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");


        }
    }
}
