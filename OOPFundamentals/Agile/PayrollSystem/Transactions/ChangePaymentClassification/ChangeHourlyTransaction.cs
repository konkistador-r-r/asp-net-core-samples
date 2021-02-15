using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollSystem
{
    public class ChangeHourlyTransaction : ChangeClassificationTransaction
    {
        private readonly int empId;
        private readonly double hourlyRate;
        public ChangeHourlyTransaction(int empId, double hourlyRate) : base(empId)
        {
            this.empId = empId;
            this.hourlyRate = hourlyRate;
        }
        protected override PaymentClassification Classification
        {
            get { return new HourlyClassification(empId, hourlyRate); }
        }
        protected override PaymentSchedule Schedule
        {
            get { return new WeeklySchedule(); }
        }
    }
}
