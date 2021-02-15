/*
 * Summary
 * 
 * Encapsulation is an object-oriented principle of hiding the internal state and behavior of an object, making your code more maintainable. 
 * In C#, you can manage encapsulation with access modifiers. 
 * For example, the public access modifier allows access to any code but the private access modifier restricts access to only members of a type. 
 * Other access modifiers restrict access in the range somewhere between public and private. While you can use any of the access modifiers on type members, 
 * the only two access modifiers you can use on types are the public and internal.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons
{
    // An object's state is the data or information it contains. 
    // When designing an object, you must think about how others could use it. 
    // Encapsulation allowing you to hide internal state and abstract access to object though 
    // type members such as methods, properties, and indexers. 
    // Encapsulation helps you reduce coupling between objects and increases the maintainability of your code.
    class Encapsulation
    {
        // An access modifier allows you to specify the visibility of code outside a type or assembly
        public static void MainMethod()
        {
            Console.WriteLine("Encapsulation");

            var bankAcctPub = new BankAccountPublic();
            // call a public method
            decimal amount = bankAcctPub.GetAmount();

            var bankAcctPriv = new BankAccountPrivate();
            bankAcctPriv.CustomerName = "John Depp";
            string customerName = bankAcctPriv.CustomerName;

            BankAccountProtected[] bankAccts = new BankAccountProtected[2];
            bankAccts[0] = new SavingsAccount();
            bankAccts[1] = new CheckingAccount();

            foreach (BankAccountProtected acct in bankAccts)
            {
                // call public method, which invokes protected virtual methods
                acct.CloseAccount();
            }
        }

        // Access modifiers can be applied to either types or type members.
        // Generally, you should hide the internal state of your object from direct access from outside code.
        // The first step in encapsulating object state is to determine what type of access that outside code 
        // should have to the members of your type. This is performed with access modifiers.


        // types contain several types of members, including constructors, properties, indexers, methods,


        //////////////////////////////////
        //
        // Type member access modifiers
        //
        //////////////////////////////////


        // private            -	 Only members within the same type.             (default for type members)
        // protected          -	 Only derived types or members of the same type.
        // internal           -	 Only code within the same assembly. Can also be code external to object as long as it is in 
        //                       the same assembly.                             (default for types)
        // protected internal -	 Either code from derived type or code in the same assembly. Combination of protected OR internal.(see Polymorphism str.71)
        // public	          -  Any code. No inheritance, external type, or external assembly restrictions.

        // is public meaning that it can be called by code that is external to this class. Following code, elsewhere in program.
        class BankAccountPublic
        {
            public decimal GetAmount()
            {
                return 1000.00m;
            }
        }

        // Remember that the default access for a type member is private
        class BankAccountPrivate
        {
            // Now you can change the implementation of m_name in any way you want. 
            private string m_name;

            // It's common to encapsulate the state of your type with properties. In fact, I always wrap my type state in a property.(wrapped (encapsulated)) 
            public string CustomerName
            {
                get { return m_name; }
                set { m_name = value; }
            }
        }

        // Protected type members can only be accessed by either members within the same type or members of derived types.
        // In the case of closing an account, there are several things that need to be done like calculating interest that is due, 
        // applying penalties for early withdrawal, and doing the work to remove the account from the database. 
        class BankAccountProtected
        {
            // The most important that the CloseAccount method is public and the other methods are protected.
            public void CloseAccount()
            {
                // Any calling code can instantiate BankAccountProtected, but it can only call the CloseAccount method. 
                // This gives you protection from someone invoking the behavior of your object in inappropriate ways.
                ApplyPenalties();
                CalculateFinalInterest();
                DeleteAccountFromDB();
            }

            protected virtual void ApplyPenalties()
            {
                // deduct from account
            }

            protected virtual void CalculateFinalInterest()
            {
                // add to account
            }

            // Remember that the only reason the methods of SavingsAccount and CheckingAccount can call their virtual base class methods, 
            // as in the case of DeleteAccountFromDB, is because the virtual base class methods are marked with the protected access modifier.
            // private method cannot be polymorphic
            protected virtual void DeleteAccountFromDB()
            {
                // send notification to data entry personnel
            }
        }

        // Derived SavingsAccount Class Using protected Members of its Base Class
        class SavingsAccount : BankAccountProtected
        {
            protected override void ApplyPenalties()
            {
                Console.WriteLine("Savings Account Applying Penalties");
            }

            protected override void CalculateFinalInterest()
            {
                Console.WriteLine("Savings Account Calculating Final Interest");
            }

            protected override void DeleteAccountFromDB()
            {
                base.DeleteAccountFromDB();
                Console.WriteLine("Savings Account Deleting Account from DB");
            }
        }
        // The CheckingAccount class is implemented similar to SavingsAccount.
        // The difference of that the methods of each class have unique implementations. 
        // For example, the business rules associated with the final interest calculation would differ,
        // depending on whether the account type was checking or savings.
        class CheckingAccount : BankAccountProtected
        {
            protected override void ApplyPenalties()
            {
                Console.WriteLine("Checking Account Applying Penalties");
            }

            protected override void CalculateFinalInterest()
            {
                Console.WriteLine("Checking Account Calculating Final Interest");
            }

            protected override void DeleteAccountFromDB()
            {
                // SavingsAccount, CheckingAccount has access to BankAccountProtected's protected method because it is a derived class. 
                base.DeleteAccountFromDB();
                Console.WriteLine("Checking Account Deleting Account from DB");
            }
        }

        /* In practice, most of the code you write will involve the public, private, and protected access modifiers. 
         * However, there are two more access modifiers that you can use in more sophisticated scenarios: internal and protected internal.
         * 
         * You would use internal whenever you created a separate class library and you don't want any code outside of the library to access 
         * the code with internal access. 
         * 
         * The protected internal is a combination of the two access modifiers it is named after, which means either protected or internal.
         */

        //////////////////////////////////
        //
        // Access Modifiers for Types
        //
        //////////////////////////////////


        // When talking about types, I'm referring to all of the C# types, including classes, structs, interfaces, delegates, and enums. 
        // Nested types, such as a class defined within the scope of a class, are considered type members.

        // Types can have only two access modifiers: public or internal. The default, if you don't specify the access modifier, is internal.
        internal class InternalInterestCalculator
        {
            // members go here
            // Perhaps the InternalInterestCalculator, shown above, has special business rules that you don't want other code to use. 
            // Now, it is in a class library of its own and can only be accessed by other code inside of that same class library (DLL).
        }

        public class BankAccountExternal
        {
            // members go here
            // If you declared a class inside of a class library that you wanted other code to use, you would give it a public access modifier.  
            // Clearly, a bank account is something you would want to access from outside of a class library. Therefore, it only makes sense 
            // to give it a public access modifier as shown in the BankAccountExternal class above.
        }
    }
}
