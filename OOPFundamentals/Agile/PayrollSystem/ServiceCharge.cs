using System;

namespace PayrollSystem
{
    public class ServiceCharge
    {
        private DateTime date;
        private double charge;

        public ServiceCharge(DateTime date, double charge)
        {
            this.date = date;
            this.charge = charge;
        }

        public double Charge
        {
            get { return charge; }
        }
        public DateTime Date
        {
            get { return date; }
        }
    }
}