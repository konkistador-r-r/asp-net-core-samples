using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollSystem
{
    public class ChangeCommissionedTransaction : ChangeClassificationTransaction
    {
        private readonly int empid;
        private readonly double salary;
        private readonly double comissionRate;
        public ChangeCommissionedTransaction(int emp_id, double salary, double comissionRate) : base(emp_id)
        {
            this.empid = emp_id;
            this.salary = salary;
            this.comissionRate = comissionRate;
        }
        protected override PaymentClassification Classification
        {
            get { return new ComissinedClassification(empid, salary, comissionRate); }
        }
        protected override PaymentSchedule Schedule
        {
            get { return new BiweeklySchedule(); }
        }
    }
}
