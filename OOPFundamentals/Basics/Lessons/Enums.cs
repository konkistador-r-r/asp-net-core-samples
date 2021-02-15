/* Enums are strongly typed constants. They are essentially unique types that allow you to assign symbolic names to integral values. 
 * In the C# tradition, they are strongly typed, meaning that an enum of one type may not be implicitly assigned to an enum of another type even though 
 * the underlying value of their members are the same. Along the same lines, integral types and enums are not implicitly interchangable. 
 * All assignments between different enum types and integral types require an explicit cast. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* Enums are value types, which means they contain their own value, can't inherit or be inherited from, and assignment copies the value of one enum to another.*/

// Whenever there are situations where you are using a set of related numbers in a program, consider replacing those numbers with enums. 
// It will make a program more readable and type safe.
namespace Lessons
{
    class Enums
    {
        // declares the enum
        // <modifier> enum <name> : <type>
        // the first member of an enum defaults to 0 and the following members default to one more than their predecessor
        private enum Volume : byte 
        {
            // <member> = <value>
            Low = 1,
            Medium,
            High
        }
        // You are restricted from creating forward references, circular references, and duplicate references in enum members.

        class Enumtricks
        {
            public static void MainMethod()
            {
                // instantiate type
                Enumtricks enumtricks = new Enumtricks();

                // demonstrates explicit cast
                // of int to Volume
               enumtricks.GetEnumFromUser();

                // iterate through Volume enum by name
                enumtricks.ListEnumMembersByName();

                // iterate through Volume enum by value
                enumtricks.ListEnumMembersByValue();
            }

            /* An enum is typically specified as shown in Listing 17-1, but may be customized by changing its base type and member values. 
         * By default, the underlying type of an enum is int. This default may be changed by specifying a specific base when declaring the enum.
         * It`s useful for space savings by selecting a smaller type or for underlying type of the enum to correspond to another type to explicitly
         * cast between the two without loss of precision.*/

            /* Enum types implicitly inherit the System.Enum type in the Base Class Library (BCL). 
             * This also means that you can use the members of System.Enum to operate on enum types. This section does just that, showing some useful tips and tricks to use with enums in your programs. */
            public void GetEnumFromUser()
            {
                Console.WriteLine("\n----------------");
                Console.WriteLine("Volume Settings:");
                Console.WriteLine("----------------\n");

                Console.Write(@"
1 - Low
2 - Medium
3 - High

Please select one (1, 2, or 3): ");

                // get value user provided
                string volString = Console.ReadLine();
                int volInt = Int32.Parse(volString);

                // perform explicit cast from
                // int to Volume enum type
                Volume myVolume = (Volume) volInt;

                Console.WriteLine();

                // make decision based
                // on enum value
                switch (myVolume)
                {
                    case Volume.Low:
                        Console.WriteLine("The volume has been turned Down.");
                        break;
                    case Volume.Medium:
                        Console.WriteLine("The volume is in the middle.");
                        break;
                    case Volume.High:
                        Console.WriteLine("The volume has been turned up.");
                        break;
                    default:
                        Console.WriteLine("You have been entered incorrect value");
                        break;
                }

                Console.WriteLine();
            }

            // iterate through Volume enum by name: num.GetNames(typeof(Volume))
            public void ListEnumMembersByName()
            {
                Console.WriteLine("\n---------------------------- ");
                Console.WriteLine("Volume Enum Members by Name:");
                Console.WriteLine("----------------------------\n");

                Console.WriteLine("Values of {0} enum", typeof(Volume).ToString().Split('+').LastOrDefault());
                // get a list of member names from Volume enum,
                // figure out the numeric value, and display
                foreach (string volume in Enum.GetNames(typeof(Volume)))
                {
                    Console.WriteLine("Volume Member: {0}\n Value: {1}",
                        volume, (byte)Enum.Parse(typeof(Volume), volume));
                }
               
            }

            // iterate through Volume enum by value : num.GetName(typeof(Volume), value)
            public void ListEnumMembersByValue()
            {
                Console.WriteLine("\n----------------------------- ");
                Console.WriteLine("Volume Enum Members by Value:");
                Console.WriteLine("-----------------------------\n");

                // get all values (numeric values) from the Volume
                // enum type, figure out member name, and display
                foreach (byte val in Enum.GetValues(typeof(Volume)))
                {
                    Console.WriteLine("Volume Value: {0}\n Member: {1}",
                        val, Enum.GetName(typeof(Volume), val));
                }
            }
        }


        public static void MainMethod()
        {
            // create and initialize 
            // instance of enum type
            Volume myVolume = Volume.Low;

            // make decision based
            // on enum value
            switch (myVolume)
            {
                case Volume.Low:
                    Console.WriteLine("The volume has been turned Down.");
                    break;
                case Volume.Medium:
                    Console.WriteLine("The volume is in the middle.");
                    break;
                case Volume.High:
                    Console.WriteLine("The volume has been turned up.");
                    break;
            }

            Enumtricks.MainMethod();
        }

        
        
    }
}
