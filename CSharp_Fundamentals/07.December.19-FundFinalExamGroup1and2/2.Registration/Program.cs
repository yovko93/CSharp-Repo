using System;
using System.Text.RegularExpressions;

namespace _2.Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"^[U][$](?<username>[A-Z][a-z]{2,})[U][$].*?[P][@][$](?<password>[A-Za-z]{5,}[A-Za-z0-9]*?\d)[P][@][$]$";
            
            int successfulReg = 0;
           
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                var match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    successfulReg++;
                    Console.WriteLine("Registration was successful");

                    string username = match.Groups["username"].Value;
                    string pass = match.Groups["password"].Value;

                    Console.WriteLine($"Username: {username}, Password: {pass}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {successfulReg}");
        }
    }
}
