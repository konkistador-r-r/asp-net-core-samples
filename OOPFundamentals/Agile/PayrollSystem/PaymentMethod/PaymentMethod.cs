using System;

namespace PayrollSystem
{
    public abstract class PaymentMethod
    {
        public abstract void Pay(Paycheck paycheck);
    }
}