using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    /// <summary>
    /// Customer account, which retains an ongoing balance and state.
    /// 
    /// Behaves as a Context object in the State pattern.
    /// Context: представляет объект, поведение которого должно динамически изменяться в соответствии с состоянием. Выполнение же конкретных действий делегируется объекту состояния
    /// </summary>
    internal class Account
    {
        private readonly string _owner;

        public double Balance => AccountState.Balance;
        public AccountState AccountState { get; set; }

        public Account(string owner)
        {
            _owner = owner;
            AccountState = new ZeroInterestAccountState(0, this);
        }

        public void Deposit(double amount)
        {
            // Ensure deposit was successful.
            if (!AccountState.Deposit(amount)) return;
            Console.WriteLine($"Deposited: {amount:C}");
            Console.WriteLine(ToString());
        }

        public double? AccrueInterest()
        {
            var interest = AccountState.AccrueInterest();
            Console.WriteLine($"Interest Earned: {interest:C}");
            Console.WriteLine(ToString());

            return interest;
        }

        public void Withdraw(double amount)
        {
            // Ensure withdrawal was successful.
            if (!AccountState.Withdraw(amount)) return;
            Console.WriteLine($"Withdrew: {amount:C}.");
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            var output = $"{"ACCOUNT OWNER",-20}{"BALANCE",-20}STATE\n";
            output += $"{_owner,-20}{Balance,-20:C}{AccountState.GetType().Name}";

            return output;
        }
    }
}
