namespace PayrollSystem
{
    public class DirectMethod : PaymentMethod
    {
        private readonly string bank;
        private readonly string account;
        public DirectMethod(string bank, string account)
        {
            this.bank = bank;
            this.account = account;
        }

        public override void Pay(Paycheck paycheck)
        {
            
        }
    }
}