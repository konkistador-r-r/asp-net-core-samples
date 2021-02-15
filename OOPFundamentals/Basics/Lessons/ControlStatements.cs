using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons
{
    class ControlStatements
    {
        public static void ifStatement()
        {

            string myInput;
            int myInt;

            Console.Write("Please enter a number: ");
            myInput = Console.ReadLine() == "" ? "0" : Console.ReadLine();
            myInt = Int32.Parse(myInput);

            // Single Decision and Action with braces
            if (myInt > 0)
            {
                Console.WriteLine("Your number {0} is greater than zero.", myInt);
            }

            // Single Decision and Action without brackets
            if (myInt < 0)
                Console.WriteLine("Your number {0} is less than zero.", myInt);

            // Either/Or Decision
            if (myInt != 0)
            {
                Console.WriteLine("Your number {0} is not equal to zero.", myInt);
            }
            else
            {
                Console.WriteLine("Your number {0} is equal to zero.", myInt);
            }

            // Multiple Case Decision
            if (myInt < 0 || myInt == 0)
            {
                Console.WriteLine("Your number {0} is less than or equal to zero.", myInt);
            }
            else if (myInt > 0 && myInt <= 10)
            {
                Console.WriteLine("Your number {0} is in the range from 1 to 10.", myInt);
            }
            else if (myInt > 10 && myInt <= 20)
            {
                Console.WriteLine("Your number {0} is in the range from 11 to 20.", myInt);
            }
            else if (myInt > 20 && myInt <= 30)
            {
                Console.WriteLine("Your number {0} is in the range from 21 to 30.", myInt);
            }
            else
            {
                Console.WriteLine("Your number {0} is greater than 30.", myInt);
            }
        }


        public static void SwitchSelect()
        {
            string myInput;
            int myInt;

            begin:

            Console.Write("Please enter a number between 1 and 3: ");
            myInput = Console.ReadLine() ?? "0";    //  myInput = Console.ReadLine() == null ? "0" : Console.ReadLine(); // String.IsNullOrEmpty(Console.ReadLine()) ? ...
            myInt = Int32.TryParse(myInput, out myInt) ? Int32.Parse(myInput) : 0;

            // switch with integer type
            switch (myInt)
            {
                case 1:
                    Console.WriteLine("Your number is {0}.", myInt);
                    break;
                case 2:
                    Console.WriteLine("Your number is {0}.", myInt);
                    break;
                case 3:
                    Console.WriteLine("Your number is {0}.", myInt);
                    break;
                default:
                    Console.WriteLine("Your number {0} is not between 1 and 3.", myInt);
                    break;
            }
            
            decide:

            

            Console.Write("Type \"continue\" to go on or \"quit\" to stop: ");
            myInput = Console.ReadLine();

            // switch with string type
            switch (myInput)
            {
                case "continue":
                    goto begin;
                case "quit":
                    Console.WriteLine("Bye.");
                    break;
                default:
                    Console.WriteLine("Your input {0} is incorrect.", myInput);
                    goto decide;
                
            }
        }
    }
}
