using System;

namespace PayrollSystem
{
    public abstract class Affiliation
    {
        // This pattern often eliminates the need to check for null, and it can help to simplify the code.
        public static readonly Affiliation NULL = new NoAffiliation();
        public double CalculateDeductions(Paycheck paycheck)
        {
            return 0;
        }
    }
}