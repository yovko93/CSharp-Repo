using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.InboxManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                var command = input.Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string username = command[1];

                if (command[0] == "Add")
                {
                    if (users.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                    else
                    {
                        users.Add(username, new List<string>());
                    }
                }
                else if (command[0] == "Send")
                {
                    string email = command[2];

                    users[username].Add(email);
                }
                else if (command[0] == "Delete")
                {
                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Users count: {users.Count}");

            var sorted = users
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToList();

            foreach (var user in sorted)
            {
                Console.WriteLine(user.Key);
                foreach (var email in user.Value)
                {
                    Console.WriteLine($"- {email}");
                }
            }

        }
    }
}
