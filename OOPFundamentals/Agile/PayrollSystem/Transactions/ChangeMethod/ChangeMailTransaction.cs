using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollSystem
{
    public class ChangeMailTransaction : ChangeMethodTransaction
    {
        private readonly string address;
        public ChangeMailTransaction(int empId, string address) : base(empId)
        {
            this.address = address;
        }
        protected override PaymentMethod Method
        {
            get { return new MailMethod(address); }
        }
    }
}
