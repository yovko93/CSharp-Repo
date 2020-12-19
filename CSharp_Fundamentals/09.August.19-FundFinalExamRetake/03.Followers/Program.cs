using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> followers = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "Log out")
            {
                var command = input.Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string username = command[1];

                if (command[0] == "New follower")
                {
                    if (!followers.ContainsKey(username))
                    {
                        followers.Add(username, new Dictionary<string, int>()
                        {
                            { "likes", 0 },
                            { "comments", 0 }
                        });
                    }
                }
                else if (command[0] == "Like")
                {
                    int count = int.Parse(command[2]);

                    if (followers.ContainsKey(username))
                    {
                        followers[username]["likes"] += count;
                    }
                    else
                    {
                        followers.Add(username, new Dictionary<string, int>()
                        {
                            { "likes", count},
                            { "comments", 0 }
                        });
                    }

                }
                else if (command[0] == "Comment")
                {
                    if (followers.ContainsKey(username))
                    {
                        followers[username]["comments"] += 1;
                    }
                    else
                    {
                        followers.Add(username, new Dictionary<string, int>()
                        {
                            { "likes", 0},
                            {"comments", 1 }
                        });
                        
                    }
                }
                else if (command[0] == "Blocked")
                {
                    if (followers.ContainsKey(username))
                    {
                        followers.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }

                input = Console.ReadLine();
            }

            var sorted = followers
                .OrderByDescending(x => x.Value["likes"])
                .ThenBy(x => x.Key)
                .ToList();

            Console.WriteLine($"{followers.Count} followers");

            foreach (var follower in sorted)
            {
                Console.WriteLine($"{follower.Key}: {follower.Value["likes"] + follower.Value["comments"]}");
            }

        }

        public class LikesAndComments
        {
            public int Likes { get; set; }

            public int Comments { get; set; }

            public LikesAndComments(int likes, int comments)
            {
                this.Likes = likes;
                this.Comments = comments;
            }
        }
    }
}
