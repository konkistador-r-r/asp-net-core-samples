using System;
using System.Collections.Generic;
using System.Text;

namespace NullObjectPatterntTest
{
    public abstract class Employee
    {
        public abstract bool IsTimeToPay(DateTime time);
        public abstract void Pay();

        // This pattern often eliminates the need to check for null, and it can help to simplify the code.        public static readonly Employee NULL = new NullEmployee();

        private class NullEmployee : Employee
        {
            public override bool IsTimeToPay(DateTime time)
            {
                return false;
            }
            public override void Pay() { }
        }
    }
}
