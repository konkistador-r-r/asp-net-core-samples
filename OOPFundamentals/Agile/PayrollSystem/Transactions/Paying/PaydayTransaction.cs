using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollSystem
{
    public class PaydayTransaction : ITransaction
    {
        private readonly DateTime payDate;
        private static Dictionary<int, List<Paycheck>> paychecks;
        public PaydayTransaction(DateTime payDate) {
            this.payDate = payDate;
            paychecks = new Dictionary<int, List<Paycheck>>();
        }

        public void Execute()
        {
            var employees = PayrollDatabase.GetAllEmployee();
            foreach (var e in employees)
            {
                if (e.IsPayDate(payDate))
                {
                    Paycheck pc = new Paycheck(payDate);
                    AddPaycheck(e.Id, payDate, pc);
                    e.Payday(pc);
                }
            }
        }

        public Paycheck GetPaycheck(int empId, DateTime payDate) {
            return paychecks.ContainsKey(empId) && paychecks[empId] != null 
                ? paychecks[empId].Where(pc=>pc.PayDate == payDate).FirstOrDefault() as Paycheck 
                : null;
        }

        private void AddPaycheck(int empId, DateTime payDate, Paycheck pc) {
            if (!paychecks.ContainsKey(empId) || paychecks[empId] == null)
            {
                paychecks[empId] = new List<Paycheck>();
            }

            paychecks[empId].Add(pc);
        }
    }
}
