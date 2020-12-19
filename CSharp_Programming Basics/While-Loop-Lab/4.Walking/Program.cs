using System;

namespace _4.Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int totalSteps = 0;

            //while (totalSteps <= 10000)
            //{
            //    if (command == "Going home")
            //    {
            //        int moreSteps = int.Parse(Console.ReadLine());
            //        int neededSteps = 10000 - totalSteps - moreSteps;
            //        if (neededSteps > 0)
            //        {
            //            Console.WriteLine($"{neededSteps} more steps to reach goal.");                      
            //        }
            //        else
            //        {
            //            Console.WriteLine("Goal reached! Good job!");
            //        }
            //        break;
            //    }
            //    int currentSteps = int.Parse(command);
            //    totalSteps += currentSteps;
            //    if (totalSteps >= 10000)
            //    {
            //        Console.WriteLine("Goal reached! Good job!");
            //        break;
            //    }           
            //    command = Console.ReadLine();
            //}

            while (command != "Going home")
            {
                int currentSteps = int.Parse(command);
                totalSteps += currentSteps;
                if (totalSteps >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    break;
                }
                command = Console.ReadLine();
            }
            if (command == "Going home")
            {
                int newSteps = int.Parse(Console.ReadLine());
                totalSteps += newSteps;
                if (totalSteps >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                }
                else
                {
                    int diff = 10000 - totalSteps;
                    Console.WriteLine($"{diff} more steps to reach goal.");
                }
            }

        }
    }
}
