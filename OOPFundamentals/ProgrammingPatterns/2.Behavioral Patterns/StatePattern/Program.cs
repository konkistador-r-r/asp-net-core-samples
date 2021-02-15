using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new account.
            var account = new Account("Alice Smith");

            // Make a few deposits.
            account.Deposit(450);
            account.Deposit(500);
            // This deposit should increase balance 
            // enough to begin accruing interest.
            account.Deposit(550);
            account.Deposit(805);

            // Accrue interest.
            account.AccrueInterest();

            // Make a few withdrawals.
            account.Withdraw(2500);
            account.Withdraw(1500);

            Console.WriteLine();

            WaterCodeSmell.WaterCodeSmell.Test();

            Console.WriteLine();

            WaterState.WaterState.Test();
            Console.WriteLine("");

            Console.WriteLine("Agile Book 1.SwitchCaseStatements of State pattern Sample");
            AgileBookSamples._1_SwitchCaseStatements.TurnstileTest.Test();
            Console.WriteLine("");

            Console.WriteLine("Agile Book 2.TransitionTables of State pattern Sample");
            AgileBookSamples._2_TransitionTables.TurnstileTest.Test();
            Console.WriteLine("");

            Console.WriteLine("Agile Book 3.TheStatePattern of State pattern Sample");
            AgileBookSamples._3_TheStatePattern.TurnstileTest.Test();
            Console.WriteLine("");

            Console.WriteLine("Agile Book 4.FSM of State pattern Sample");
            AgileBookSamples._4_FSM.SMCTurnstileTest.Test();
            Console.WriteLine("");

            Console.Read();
        }
    }
}
