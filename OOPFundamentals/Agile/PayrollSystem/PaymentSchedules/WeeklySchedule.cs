using System;

namespace PayrollSystem
{
    public class WeeklySchedule : PaymentSchedule
    {
        public override DateTime GetPayPeriodStartDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// If they work more than 8 hours per day, they are paid 1.5 times their normal rate for those extra hours. 
        /// Daily time card: the date and number of hours worked.
        /// They are paid every Friday.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public override bool IsPayDate(DateTime date)
        {
            return IsFriday(date);
        }

        private bool IsFriday(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Friday;
        }
    }
}