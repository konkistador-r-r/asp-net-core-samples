/* Methods are extremely useful because they allow you to separate your logic into different units. 
 * The four types of paramters are value, ref, out, and params. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Lessons
{
    class Address
    {
        public string name;
        public string address;
    }

    public class Methods
    {
        public string GetChoice()
        {
            string myChoice;

            // Print A Menu
            Console.WriteLine("My Address Book\n");

            Console.WriteLine("A - Add New Address");
            Console.WriteLine("D - Delete Address");
            Console.WriteLine("M - Modify Address");
            Console.WriteLine("V - View Addresses");
            Console.WriteLine("Q - Quit\n");

            Console.WriteLine("Choice (A,D,M,V,or Q): ");

            // Retrieve the user's choice
            myChoice = Console.ReadLine();

            return myChoice;
        }

        public void MakeDecision(string myChoice) /* parameter does not have any other modifiers, 
                                                   * it is considered a value parameter. The actual value of the
                                                   * argument is copied on the stack. Variables given by value 
                                                   * parameters are local and any changes to that local variable
                                                   * do not affect the value of the variable used in the caller's 
                                                   * argument. */
        {
            Address addr = new Address();

            switch (myChoice)
            {
                case "A":
                case "a":
                    addr.name = "Joe";
                    addr.address = "C# Station";
                    this.addAddress(ref addr); /* this - mp [mp.MakeDecision(myChoice);] this is a reference to the 
                                                * current object. addAddress() method takes a ref parameter. This means
                                                * that a reference to the parameter is copied to the method. This 
                                                * reference still refers to the same object on the heap as the original
                                                * reference used in the caller's argument. This means any changes to the
                                                * local reference's object also changes the caller reference's object. 
                                                * The code can't change the reference, but it can make changes to the 
                                                * object being referenced. */
                    break;
                case "D":
                case "d":
                    addr.name = "Robert";
                    this.deleteAddress(addr.name);
                    break;
                case "M":
                case "m":
                    addr.name = "Matt";
                    this.modifyAddress(out addr); /* out parameter use to return more than one value from a method. */
                    Console.WriteLine("Name is now {0}.", addr.name);
                    break;
                case "V":
                case "v":
                    this.viewAddresses("Cheryl", "Joe", "Matt", "Robert");
                    // this.viewAddresses(new string [] {"Cheryl", "Joe", "Matt", "Robert"});
                    break;
                case "Q":
                case "q":
                    Console.WriteLine("Bye.");
                    break;
                default:
                    Console.WriteLine("{0} is not a valid choice", myChoice);
                    break;
            }
        }

        // insert an address
        void addAddress(ref Address addr)
        {
            Console.WriteLine("Name: {0}, Address: {1} added.", addr.name, addr.address);
        }

        // remove an address
        void deleteAddress(string name)
        {
            Console.WriteLine("You wish to delete {0}'s address.", name);
        }

        // change an address
        void modifyAddress(out Address addr)
        {
            //Console.WriteLine("Name: {0}.", addr.name); // causes error! because addr not exist already
            addr = new Address();
            addr.name = "Joe";
            addr.address = "C# Station";
        }

        // show addresses
        void viewAddresses(params string[] names) /* params - parameter, which lets you define a method that can 
                                                   * accept a variable number of arguments. The params parameter 
                                                   * must be a single dimension or jagged array. Therefore you can pass
                                                   * parametrs like viewAddresses("Cheryl", "Joe", "Matt", "Robert")
                                                   * insetd of viewAddresses(new string [] 
                                                   * {"Cheryl", "Joe", "Matt", "Robert"} )*/
        {
            foreach (string name in names)
            {
                Console.WriteLine("Name: {0}", name);
            }
        }

        public static void MethodsStruct()
        {
            string myChoice;

            var mp = new Methods();

            do
            {
                // show menu and get input from user
                myChoice = mp.GetChoice();

                // Make a decision based on the user's choice
                mp.MakeDecision(myChoice);

                
                
            } while (myChoice != "Q" && myChoice != "q"); // Keep going until the user wants to quit
        }

        public class ClassOutRef
        {
            /* Ref tells the compiler that the object is initialized before entering the function.
             * ref means that value is already set, method can read it and can modify it. */
            private int MethoodRef(ref int number)
            {
                number++;
                return number;
            }

            /*  while out tells the compiler that the object will be initialized inside the function.
             * out means that value isn't set and method must set it before return and couldn't read before setting value */
            private int MethoodOut(out int number)
            {
                number = 0; // initialize
                return number;
            }

            public static void MethodsCalling()
            {
                var someValue = 0;
                var someObj = new ClassOutRef();

                int resultOfOut; // it`s dont mind what value be previously if variable was initialized

                someObj.MethoodOut(out resultOfOut);

                someObj.MethoodRef(ref someValue);

                Console.WriteLine("MethoodOut: {0}, MethoodRef: {1}", resultOfOut, someValue);

            }
        }
    }

    class MethodModifiers
    {
        // and NEW, ABSTRACT, VIRTUAL or OVERRIDE
        internal int Method()
        {
            string myString;
            Console.Write("Enter your message: ");
            myString = Console.ReadLine();
            return MessageBox(0, myString, "My Message Box", 0);
        }

        public void Method1()
        {

        }

        protected void Method2()
        {

        }

        private void Method3()
        {

        }

        static void Method4()
        {

        }

        // Using the extern modifier means that the method is implemented outside the C# code(externally). Extern method cannot declare a body
        [DllImport("User32.dll")]
        private static extern int MessageBox(int h, string m, string c, int type);

        
        
    }
}
