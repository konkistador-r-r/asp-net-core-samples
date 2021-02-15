using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollSystem
{
    public class SalesReceiptTransaction : ITransaction
    {
        private readonly DateTime date;
        private readonly double amount;
        private readonly int empId;
        public SalesReceiptTransaction(DateTime date, double amount, int empId)
        {
            this.date = date;
            this.amount = amount;
            this.empId = empId;
        }
        public void Execute()
        {
            // Note the use of InvalidOperationExceptions.This is not particularly good long-term practice but suffices this early in development.
            // After we get some idea of what the exceptions ought to be, we can come back and create meaningful exception classes.

            Employee e = PayrollDatabase.GetEmployee(empId);
            if (e != null)
            {
                ComissinedClassification hc = e.Classification as ComissinedClassification;
                if (hc != null)
                    hc.AddSalesReceipt(new SalesReceipt(date, amount));
                else
                    throw new InvalidOperationException("Tried to add sales receipt to" + "non-comissined employee");
            }
            else
                throw new InvalidOperationException("No such employee.");
        }
    }
}
