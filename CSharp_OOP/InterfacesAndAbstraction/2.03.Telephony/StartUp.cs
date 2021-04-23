using System;
using System.Linq;

using _2._03.Telephony.Models;
using _2._03.Telephony.Exceptions;

namespace _2._03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split()
                .ToArray();

            string[] sites = Console.ReadLine()
                .Split()
                .ToArray();

            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartPhone = new Smartphone();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                string currentPhoneNumber = phoneNumbers[i];

                try
                {
                    if (currentPhoneNumber.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(currentPhoneNumber));
                    }
                    else if (currentPhoneNumber.Length == 10)
                    {
                        Console.WriteLine(smartPhone.Call(currentPhoneNumber));
                    }
                    else
                    {
                        throw new InvalidPhoneNumberException();
                    }
                }
                catch (InvalidPhoneNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            for (int j = 0; j < sites.Length; j++)
            {
                string url = sites[j];
                try
                {
                    Console.WriteLine(smartPhone.Browse(url));

                }
                catch (InvalidURLException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}

