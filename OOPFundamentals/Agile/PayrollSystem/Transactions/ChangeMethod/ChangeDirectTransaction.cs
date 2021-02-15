using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollSystem
{
    public class ChangeDirectTransaction : ChangeMethodTransaction
    {
        private readonly string bank;
        private readonly string account;
        public ChangeDirectTransaction(int empId, string bank, string account) : base(empId)
        {
            this.bank = bank;
            this.account = account;
        }
        protected override PaymentMethod Method
        {
            get { return new DirectMethod(bank, account); }
        }
    }
}
