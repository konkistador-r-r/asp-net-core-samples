using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollSystem
{
    public class TimeCardTransaction : ITransaction
    {
        private readonly DateTime date;
        private readonly double hours;
        private readonly int empId;
        public TimeCardTransaction(DateTime date, double hours, int empId)
        {
            this.date = date;
            this.hours = hours;
            this.empId = empId;
        }
        public void Execute()
        {
            // Note the use of InvalidOperationExceptions.This is not particularly good long-term practice but suffices this early in development.
            // After we get some idea of what the exceptions ought to be, we can come back and create meaningful exception classes.

            Employee e = PayrollDatabase.GetEmployee(empId);
            if (e != null)
            {
                HourlyClassification hc = e.Classification as HourlyClassification;
                if (hc != null)
                    hc.AddTimeCard(new TimeCard(date, hours));
                else
                    throw new InvalidOperationException("Tried to add timecard to" + "non-hourly employee");
            }
            else
                throw new InvalidOperationException("No such employee.");
        }
    }
}
