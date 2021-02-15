using System;

namespace PayrollSystem
{
    public abstract class PaymentSchedule
    {
        public abstract DateTime GetPayPeriodStartDate(DateTime date);

        public abstract bool IsPayDate(DateTime date);
    }
}