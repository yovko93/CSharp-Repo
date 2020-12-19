using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.FriendlistMaintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friendsList = Console.ReadLine()
                .Split(", ")
                .ToList();

            string input = Console.ReadLine();
            int blacklistedNamesCount = 0;
            int lostNamesCount = 0;

            while (input != "Report")
            {
                string[] command = input.Split();

                if (command[0] == "Blacklist")
                {
                    string name = command[1];
                    if (friendsList.Contains(name))
                    {
                        blacklistedNamesCount++;
                        int index = friendsList.IndexOf(name);
                        friendsList[index] = "Blacklisted";
                        Console.WriteLine($"{name} was blacklisted.");
                    }
                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                }
                else if (command[0] == "Error")
                {
                    int index = int.Parse(command[1]);
                    string username = friendsList[index];

                    if (username != "Blacklisted" && username != "Lost")
                    {
                        friendsList[index] = "Lost";
                        Console.WriteLine($"{username} was lost due to an error.");
                        lostNamesCount++;
                    }
                }
                else if (command[0] == "Change")
                {
                    int index = int.Parse(command[1]);
                    string newName = command[2];

                    if (index >= 0 && index < friendsList.Count)
                    {
                        string currentName = friendsList[index];
                        friendsList[index] = newName;
                        Console.WriteLine($"{currentName} changed his username to {newName}.");
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Blacklisted names: {blacklistedNamesCount}");
            Console.WriteLine($"Lost names: {lostNamesCount}");
            Console.WriteLine(string.Join(' ', friendsList));
        }
    }
}
