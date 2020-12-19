using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();

            string input = Console.ReadLine();
            string resource = string.Empty;
            int count = 1;

            // може и с while(true) и да чета 2 реда
            while (input != "stop")
            {
                if (count % 2 == 1)
                {
                    resource = input;
                    if (!resources.ContainsKey(input))
                    {
                        resources.Add(resource, 0);
                    }
                }
                else if (count % 2 == 0)
                {
                    int quantity = int.Parse(input);
                    resources[resource] += quantity;
                }

                input = Console.ReadLine();
                count++;
            }

            foreach (var pair in resources)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value);
            }
        }
    }
}
