using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> registeredCars = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                string username = command[1];

                if (command[0] == "register")
                {
                    string licensePlateNumber = command[2];

                    if (registeredCars.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {registeredCars[username]}");
                    }
                    else
                    {
                        registeredCars.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }

                }
                else if (command[0] == "unregister")
                {
                    if (registeredCars.ContainsKey(username))
                    {
                        registeredCars.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }

                }
            }

            foreach (var pair in registeredCars)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
        }
    }
}
