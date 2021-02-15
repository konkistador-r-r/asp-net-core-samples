using System;

namespace PayrollSystem
{
    public class MonthlySchedule : PaymentSchedule
    {
        public override DateTime GetPayPeriodStartDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return true only if the argument date is the last day of the month.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public override bool IsPayDate(DateTime date)
        {
            return IsLastDayOfMonth(date);
        }

        private bool IsLastDayOfMonth(DateTime date)
        {
            int m1 = date.Month;
            int m2 = date.AddDays(1).Month;
            return (m1 != m2);
        }
    }
}