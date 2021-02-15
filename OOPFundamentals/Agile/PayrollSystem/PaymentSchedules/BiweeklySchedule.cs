using System;
using System.Globalization;

namespace PayrollSystem
{
    public class BiweeklySchedule : PaymentSchedule
    {
        public override DateTime GetPayPeriodStartDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public override bool IsPayDate(DateTime date)
        {
            return IsFriday(date) && BiWeekly(date);
        }

        private bool IsFriday(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Friday;
        }

        private bool BiWeekly(DateTime date)
        {
            var weekNumber = GetIso8601WeekOfYear(date);
            return weekNumber % 2 > 0;
        }

        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        private static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}