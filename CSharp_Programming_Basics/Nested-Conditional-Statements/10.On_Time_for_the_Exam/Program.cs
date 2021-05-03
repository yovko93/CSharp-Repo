using System;

namespace _10.On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinute = int.Parse(Console.ReadLine());
            int arrivedHour = int.Parse(Console.ReadLine());
            int arrivedMinute = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMinute;
            int arrivedTime = arrivedHour * 60 + arrivedMinute;
            int diffEarly = examTime - arrivedTime;
            int diff = 0;

            if (examTime < arrivedTime)
            {
                Console.WriteLine("Late");
                diff = arrivedTime - examTime;
                if (diff < 60)
                {
                    Console.WriteLine($"{diff} minutes after the start");
                }
                else if (diff >= 60)
                {
                    int hour = diff / 60;
                    int min = diff % 60;
                    Console.WriteLine($"{hour}:{min:00} hours after the start");
                }
            }
            else if (examTime == arrivedTime || diffEarly <= 30)
            {
                Console.WriteLine("On Time");
                diff = examTime - arrivedTime;
                if (diff > 0)
                {
                    Console.WriteLine($"{diff} minutes before the start");
                }
            }
            else if (examTime > arrivedTime && diffEarly > 30)
            {
                Console.WriteLine("Early");
                if (diffEarly >= 60)
                {
                    int hour = diffEarly / 60;
                    int min = diffEarly % 60;
                    Console.WriteLine($"{hour}:{min:00} hours before the start");
                }
                else
                {
                    Console.WriteLine($"{diffEarly} minutes before the start");
                }
            }
        }
    }
}
