using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int totalCarPassed = 0;

            string input = Console.ReadLine();

            while (input != "END")
            {
                int greenLight = greenLightDuration;
                int extraWindow = freeWindow;

                if (input == "green")
                {
                    while (cars.Any() && greenLight > 0)
                    {
                        string firstCarInQueue = cars.Dequeue();
                        greenLight -= firstCarInQueue.Length;

                        if (greenLight >= 0)
                        {
                            totalCarPassed++;
                        }
                        else
                        {
                            extraWindow += greenLight;

                            if (extraWindow < 0)
                            {
                                int index = firstCarInQueue.Length + extraWindow;
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{firstCarInQueue} was hit at {firstCarInQueue[index]}.");
                                return;
                            }

                            totalCarPassed++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarPassed} total cars passed the crossroads.");
        }
    }
}
