using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollSystem
{
    public interface ITransaction
    {
        void Execute();
    }

    public abstract class Transaction
    {
        protected readonly PayrollDatabase database;
        public Transaction(PayrollDatabase database)
        {
            this.database = database;
        }
        public abstract void Execute();
    }
}
