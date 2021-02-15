using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollSystem
{
    public class ChangeMemberTransaction : ChangeAffiliationTransaction
    {
        private readonly int memberId;
        private double dues;
        public ChangeMemberTransaction(int empId, int memberId, double dues) : base(empId) {
            this.memberId = memberId;
            this.dues = dues;
        }
        protected override Affiliation Affiliation
        {
            get { return new UnionAffiliation(memberId, dues); }
        }

        protected override void RecordMembership(Employee e) {
            PayrollDatabase.AddUnionMember(memberId, e);
        }
    }
}
