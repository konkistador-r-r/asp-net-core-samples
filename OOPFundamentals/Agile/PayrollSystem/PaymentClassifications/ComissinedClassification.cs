using System;

namespace PayrollSystem
{
    public class ComissinedClassification : PaymentClassification
    {
        private int empId;
        private double salary;
        private double comissionRate;

        public ComissinedClassification(int emp_id, double salary, double comissionRate)
        {
            this.empId = emp_id;
            this.salary = salary;
            this.comissionRate = comissionRate;
        }

        public double Salary { get { return salary; } }
        public double ComissionRate { get { return comissionRate; } }

        public void AddSalesReceipt(SalesReceipt salesReceipt)
        {
            PayrollDatabase.AddSalesReceipt(empId, salesReceipt);
        }

        public SalesReceipt GetSalesReceipt(DateTime dateTime)
        {
            return PayrollDatabase.GetSalesReceipt(empId, dateTime);
        }

        public override double CalculatePay(Paycheck paycheck)
        {
            double totalPay = 0.0;
            var salesReceipts = PayrollDatabase.GetSalesReceipts(empId);
            foreach (SalesReceipt salesReceipt in salesReceipts)
            {
                if (IsInPayPeriod(salesReceipt, paycheck.PayDate))
                    totalPay += CalculatePayForSalesReceipt(salesReceipt);
            }
            return totalPay;
        }

        private bool IsInPayPeriod(SalesReceipt card, DateTime payPeriod)
        {
            DateTime payPeriodEndDate = payPeriod;
            DateTime payPeriodStartDate = payPeriod.AddDays(-12); // Friday - 12 - 2 weeks
            return card.Date <= payPeriodEndDate && card.Date >= payPeriodStartDate;
        }
        private double CalculatePayForSalesReceipt(SalesReceipt receipt)
        {
            double commissionPay = ((receipt.Amount * ComissionRate) / 100);
            double salaryHalfPay = (Salary / 2);
            return commissionPay + salaryHalfPay;
        }
    }
}