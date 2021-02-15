using System;

namespace PayrollSystem
{
    public class SalesReceipt
    {
        private DateTime date;
        private double amount;

        public SalesReceipt(DateTime date, double amount)
        {
            this.date = date;
            this.amount = amount;
        }

        public double Amount
        {
            get { return amount; }
        }
        public DateTime Date
        {
            get { return date; }
        }
    }
}