using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> furnitureNames = new List<string>();

            string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";

            double spendMoney = 0;

            string input = Console.ReadLine();

            while (input != "Purchase")
            {
                Regex regex = new Regex(pattern);
                Match match = regex.Match(input);

                if (match.Success)
                {
                    furnitureNames.Add(match.Groups["name"].Value);

                    spendMoney += double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["quantity"].Value);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            if (furnitureNames.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, furnitureNames));
            }
            Console.WriteLine($"Total money spend: {spendMoney:f2}");
        }
    }
}
