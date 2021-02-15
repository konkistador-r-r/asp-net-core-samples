using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollSystem
{
    public abstract class ChangeAffiliationTransaction : ChangeEmployeeTransaction
    {
        protected abstract Affiliation Affiliation { get; }
        protected abstract void RecordMembership(Employee e);

        public ChangeAffiliationTransaction(int empId) : base(empId) { }

        protected override void Change(Employee e)
        {
            RecordMembership(e);
            e.Affiliation = Affiliation;
        }
    }
}
