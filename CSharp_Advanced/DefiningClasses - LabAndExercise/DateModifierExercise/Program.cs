using System;

namespace DateModifierExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            int totalDays = dateModifier.GetDaysDifference(startDate, endDate);

            Console.WriteLine(Math.Abs(totalDays));

        }
    }
}
