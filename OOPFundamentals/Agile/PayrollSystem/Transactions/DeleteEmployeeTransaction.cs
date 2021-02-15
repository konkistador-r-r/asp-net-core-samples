using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollSystem
{
    public class DeleteEmployeeTransaction : ITransaction
    {
        private readonly int id;
        public DeleteEmployeeTransaction(int id)
        {
            this.id = id;
        }
        public void Execute()
        {
            PayrollDatabase.DeleteEmployee(id);
        }
    }
}
