using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifierExercise
{
   public class DateModifier
    {

        public int GetDaysDifference(string startDateAsString, string endDateAsString)
        {
            DateTime startDate = DateTime.Parse(startDateAsString);
            DateTime endDate = DateTime.Parse(endDateAsString);

            int totalDays = (int)(startDate - endDate).TotalDays;

            return totalDays;
        }
    }
}
