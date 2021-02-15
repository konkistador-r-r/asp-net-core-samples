using System;

namespace PayrollSystem
{
    public class Paycheck
    {
        private readonly DateTime payDate;
        public Paycheck(DateTime payDate)
        {
            this.payDate = payDate;
        }
        public double GrossPay { get; internal set; }
        public double Deductions { get; internal set; }
        public double NetPay { get; internal set; }
        public DateTime PayDate { get { return payDate; } }

        public string GetField(string v)
        {
            return "Hold";
        }
    }
}