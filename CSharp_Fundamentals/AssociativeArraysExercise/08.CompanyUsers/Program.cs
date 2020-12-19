using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> companyInfo = new SortedDictionary<string, List<string>>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                var data = command.Split(" -> ").ToArray();
                string companyName = data[0];
                string employeeId = data[1];

                if (companyInfo.ContainsKey(companyName))
                {
                    if (!companyInfo[companyName].Contains(employeeId))
                    {
                        companyInfo[companyName].Add(employeeId);
                    }
                }
                else
                {
                    companyInfo.Add(companyName, new List<string>());
                    companyInfo[companyName].Add(employeeId);
                }

                command = Console.ReadLine();
            }

            foreach (var pair in companyInfo)
            {
                Console.WriteLine(pair.Key);
                foreach (var id in pair.Value)
                {
                    Console.WriteLine("-- " + id);
                }
            }

        }
    }
}
