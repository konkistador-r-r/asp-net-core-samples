namespace PayrollSystem
{
    public class SalariedClassification : PaymentClassification
    {
        private double salary;

        public SalariedClassification(double salary)
        {
            this.salary = salary;
        }

        public double Salary { get { return salary; } }

        public override double CalculatePay(Paycheck paycheck)
        {
            return salary;
        }
    }
}