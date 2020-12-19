using System;

namespace _06.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalTickets = 0;
            double studentTicket = 0;
            double standartTicket = 0.0;
            double kidTicket = 0;

            string name = Console.ReadLine();

            while (name != "Finish")
            {
                int seats = int.Parse(Console.ReadLine());
                string typeTicket = Console.ReadLine();
                double counterSeats = 0;

                while (typeTicket != "End")
                {
                    if (typeTicket == "student")
                    {
                        studentTicket++;
                    }
                    else if (typeTicket == "standard")
                    {
                        standartTicket++;
                    }
                    else if (typeTicket == "kid")
                    { 
                        kidTicket++;
                    }
                    counterSeats++;
                    totalTickets++;
                    if (counterSeats == seats)
                    {
                        break;
                    }
                    typeTicket = Console.ReadLine();
                }
                Console.WriteLine($"{name} - {counterSeats/seats*100.0:f2}% full.");
                name = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{studentTicket/totalTickets*100.0:f2}% student tickets.");
            Console.WriteLine($"{standartTicket/totalTickets*100.0:f2}% standard tickets.");
            Console.WriteLine($"{(kidTicket/totalTickets)*100.0:f2}% kids tickets.");



        }
    }
}
