using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string group = Console.ReadLine();
            string day = Console.ReadLine();

            decimal price = 0;

            if (group == "Students")
            {
                if (day == "Friday")
                {
                    price = people * 8.45m;
                }
                else if (day == "Saturday")
                {
                    price = people * 9.8m;
                }
                else if (day == "Sunday")
                {
                    price = people * 10.46m;
                }
                if (people >= 30)
                {
                    price = price * 0.85m;
                }
            }
            else if (group == "Business")
            {
                if (day == "Friday")
                {
                    price = people * 10.9m;
                    if (people >= 100)
                    {
                        price -= 10 * 10.9m;
                    }
                }
                else if (day == "Saturday")
                {
                    price = people * 15.6m;
                    if (people >= 100)
                    {
                        price -= 10 * 15.6m;
                    }
                }
                else if (day == "Sunday")
                {
                    price = people * 16.0m;
                    if (people >= 100)
                    {
                        price -= 10 * 16;
                    }
                }
            }
            else if (group == "Regular")
            {
                if (day == "Friday")
                {
                    price = people * 15.0m;
                }
                else if (day == "Saturday")
                {
                    price = people * 20.0m;
                }
                else if (day == "Sunday")
                {
                    price = people * 22.5m;
                }
                if (people >= 10 && people <= 20)
                {
                    price = price * 0.95m;
                }
            }
            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
