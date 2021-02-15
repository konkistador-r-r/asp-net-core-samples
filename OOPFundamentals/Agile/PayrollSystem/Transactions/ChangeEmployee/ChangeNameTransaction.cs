using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollSystem
{
    public class ChangeNameTransaction : ChangeEmployeeTransaction
    {
        private readonly string newName;
        public ChangeNameTransaction(int empId, string newName) : base(empId)
        {
            this.newName = newName;
        }
        protected override void Change(Employee e)
        {
            e.Name = newName;
        }
    }
}
