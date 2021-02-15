using System;

namespace PayrollSystem
{
    public class UnionAffiliation : Affiliation
    {
        private readonly int memberId;
        private readonly double dues;
        public UnionAffiliation(int memberId, double dues)
        {
            this.memberId = memberId;
            this.dues = dues;
        }

        public double Dues { get { return dues; } }
        public int MemberId { get { return memberId; } }

        public void AddServiceCharge(int memberId, ServiceCharge serviceCharge)
        {
            PayrollDatabase.AddServiceCharges(memberId, serviceCharge);
        }

        public ServiceCharge GetServiceCharges(int memberId, DateTime date)
        {
            return PayrollDatabase.GetServiceCharges(memberId, date);
        }
    }
}