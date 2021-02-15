using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollSystem
{
    public abstract class ChangeClassificationTransaction : ChangeEmployeeTransaction
    {
        protected abstract PaymentClassification Classification { get; }
        protected abstract PaymentSchedule Schedule { get; }

        public ChangeClassificationTransaction(int empId) : base(empId) { }

        protected override void Change(Employee e)
        {
            e.Classification = Classification;
            e.Schedule = Schedule;
        }
    }
}
