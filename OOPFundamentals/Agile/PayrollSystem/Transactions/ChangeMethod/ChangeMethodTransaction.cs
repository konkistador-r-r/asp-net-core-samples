using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollSystem
{
    public abstract class ChangeMethodTransaction : ChangeEmployeeTransaction
    {
        protected abstract PaymentMethod Method { get; }

        public ChangeMethodTransaction(int empId) : base(empId) { }

        protected override void Change(Employee e)
        {
            e.Method = Method;
        }
    }
}
