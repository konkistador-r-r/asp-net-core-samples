using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollSystem
{
    public class ChangeHoldTransaction : ChangeMethodTransaction
    {
        public ChangeHoldTransaction(int empId) : base(empId) { }
        protected override PaymentMethod Method
        {
            get { return new HoldMethod(); }
        }
    }
}
