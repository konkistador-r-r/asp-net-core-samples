using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollSystem
{
    public class HourlyClassification : PaymentClassification
    {
        private int empId;
        private double hourlyRate;

        public HourlyClassification(int emp_id, double hourlyRate)
        {
            this.empId = emp_id;
            this.hourlyRate = hourlyRate;
        }

        public double HourlyRate { get { return hourlyRate; } set { hourlyRate = value; } }

        public void AddTimeCard(TimeCard timeCard)
        {
            PayrollDatabase.AddTimeCard(empId, timeCard);
        }

        public TimeCard GetTimeCard(DateTime dateTime)
        {
            return PayrollDatabase.GetTimeCard(empId, dateTime);
        }

        public override double CalculatePay(Paycheck paycheck)
        {
            double totalPay = 0.0;
            var timecards = PayrollDatabase.GetTimeCards(empId);
            foreach (TimeCard timeCard in timecards)
            {
                if (IsInPayPeriod(timeCard, paycheck.PayDate))
                    totalPay += CalculatePayForTimeCard(timeCard);
            }
            return totalPay;
        }

        private bool IsInPayPeriod(TimeCard card, DateTime payPeriod)
        {
            DateTime payPeriodEndDate = payPeriod;
            DateTime payPeriodStartDate = payPeriod.AddDays(-5);
            return card.Date <= payPeriodEndDate && card.Date >= payPeriodStartDate;
        }
        private double CalculatePayForTimeCard(TimeCard card)
        {
            double overtimeHours = Math.Max(0.0, card.Hours - 8);
            double normalHours = card.Hours - overtimeHours;
            return (hourlyRate * normalHours) + (hourlyRate * 1.5 * overtimeHours);
        }
    }
}
