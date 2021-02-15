using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    /// <summary>
    /// State that indicates the Account is actively accruing interest.
    /// 
    /// Behaves as a ConcreteState in the State pattern.
    /// </summary>
    internal class InterestAccountState : AccountState
    {
        private new const double InterestRate = 0.05;
        private new const double LowerLimit = 1000;
        private new const double UpperLimit = 1000000;

        public InterestAccountState(AccountState accountState)
            : this(accountState.Balance, accountState.Account)
        {
        }

        public InterestAccountState(double balance, Account account)
        {
            Balance = balance;
            Account = account;
        }

        public override bool Deposit(double amount)
        {
            Balance += amount;
            TryStateChange();
            return true;
        }

        public override double? AccrueInterest()
        {
            var accruedInterest = InterestRate * Balance;
            Balance += accruedInterest;
            TryStateChange();
            return accruedInterest;
        }

        public override void TryStateChange()
        {
            if (Balance < 0.0)
            {
                Account.AccountState = new OverdrawnAccountState(this);
            }
            else if (Balance < LowerLimit)
            {
                Account.AccountState = new ZeroInterestAccountState(this);
            }
        }

        public override bool Withdraw(double amount)
        {
            Balance -= amount;
            TryStateChange();
            return true;
        }
    }
}
