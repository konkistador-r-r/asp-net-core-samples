using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons
{
    class OperationsTypes
    {
        public static void Operations()
        {
            int unary = 0; //  unary variable is initialized to zero
            int preIncrement;
            int preDecrement;
            int postIncrement;
            int postDecrement;
            int positive;
            int negative;
            sbyte bitNot;
            bool logNot;

            // result = ++variable -> result = 1 + variable;                           preIncrement = 1 + 0 = 1;variable =  1
            preIncrement = ++unary; // When the pre-increment (++x) operator is used, unary is incremented to 1 and the value 1 is assigned to the preIncrement variable.
            Console.WriteLine("pre-Increment: {0}", preIncrement);
            Console.WriteLine("unary: {0}", unary);
            // result = --variable ->  result = -1 +variable                           preDecrement = -1 + 1 = 0;variable =  0
            preDecrement = --unary;
            Console.WriteLine("pre-Decrement: {0}", preDecrement);
            Console.WriteLine("unary: {0}", unary);
            // result = variable-- -> result = variable; variable = variable-1         postDecrement = 0-- = 0;variable =  -1
            postDecrement = unary--; // When the post-decrement (x--) operator is used, the value of unary, 0, is placed into the postDecrement variable and then unary is decremented to -1. 
            Console.WriteLine("Post-Decrement: {0}", postDecrement);
            Console.WriteLine("unary: {0}", unary);
            // result = variable++ -> result = variable; variable = variable+1         postIncrement = -1++ = -1;variable =  0
            postIncrement = unary++;
            Console.WriteLine("Post-Increment: {0}", postIncrement);
            Console.WriteLine("unary: {0}", unary);

            Console.WriteLine("Final Value of Unary: {0}", unary);
            // postIncrement = -1 * -1 = 1
            positive = -postIncrement;
            Console.WriteLine("Positive: {0}", positive);
            // postIncrement = 1 * -1 = -1
            negative = +postIncrement;
            Console.WriteLine("Negative: {0}", negative);

            bitNot = 0;
            bitNot = (sbyte) (~bitNot);
            Console.WriteLine("Bitwise Not: {0}", bitNot);

            logNot = false;
            logNot = !logNot;
            Console.WriteLine("Logical Not: {0}", logNot);


            Console.WriteLine("\n\n\n");


            int x, y, result;
            float floatresult;

            x = 7;
            y = 5;

            result = x + y;
            Console.WriteLine("x+y: {0}", result);

            result = x - y;
            Console.WriteLine("x-y: {0}", result);

            result = x*y;
            Console.WriteLine("x*y: {0}", result);

            result = x/y;
            Console.WriteLine("x/y: {0}", result);

            floatresult = (float) x/(float) y;
            Console.WriteLine("x/y: {0}", floatresult);

            result = x%y;
            Console.WriteLine("x%y: {0}", result);

            result = 2;
            result += x;
            Console.WriteLine("result+=x: {0}", result);


            Console.WriteLine("\n\n\n");
        }

        public void Func(int a, int b)
        {
            if (a != 0 && b == 0) // if (a == 0 || b != 0) return; // rule of de-morgana
            {
                Console.WriteLine("\n\n\n");
                Console.WriteLine("\n\n\n"); Console.WriteLine("\n\n\n");
                Console.WriteLine("\n\n\n");
                Console.WriteLine("\n\n\n");
                Console.WriteLine("\n\n\n");
            }
        }

        public static void Massives()
        {

            // одномерный массив инициализтрованный при создании
            int[] myInts = {5, 10, 15};

            // многомерный c размером 2*бесконечность, 0 = 2, 1 = 1
            bool[][] myBools = new bool[2][];
            myBools[0] = new bool[2];
            myBools[1] = new bool[1];

            // многомерный c размером 3 2*3
            double[,] myDoubles = new double[2,3];


            // многомерный c размером 3 2*3
            decimal[,] myDecimal = new decimal[3,3];


            // одномерный c размером 3
            string[] myStrings = new string[3];

            Console.WriteLine("myInts[0]: {0}, myInts[1]: {1}, myInts[2]: {2}", myInts[0], myInts[1], myInts[2]);

            myBools[0][0] = true;
            myBools[0][1] = false;
            myBools[1][0] = true;
            Console.WriteLine("myBools[0][0]: {0}, myBools[1][0]: {1}", myBools[0][0], myBools[1][0]);

            myDoubles[0, 0] = 3.147;
            myDoubles[0, 1] = 7.157;
            myDoubles[1, 1] = 2.117;
            myDoubles[1, 0] = 56.00138917;
            myDoubles[1, 2] = 16.0013;
            Console.WriteLine("myDoubles[0, 0]: {0}, myDoubles[1, 0]: {1}", myDoubles[0, 0], myDoubles[1, 0]);


            //
            // Round double type in three ways.
            //
            double before1 = 123.467;
            double after1 = Math.Round(before1, 2, MidpointRounding.AwayFromZero); // Rounds "up"
            double after2 = Math.Round(before1, 2, MidpointRounding.ToEven); // Rounds to even
            double after3 = Math.Round(before1);

            Console.WriteLine(before1); // Original
            Console.WriteLine(after1);
            Console.WriteLine(after2);
            Console.WriteLine(after3);

            myStrings[0] = "Joe";
            myStrings[1] = "Matt";
            myStrings[2] = "Robert";
            Console.WriteLine("myStrings[0]: {0}, myStrings[1]: {1}, myStrings[2]: {2}", myStrings[0], myStrings[1],
                              myStrings[2]);

        }

        public static void Or()
        {
            // Example #1 uses Method1 and Method2 to demonstrate 
            // short-circuit evaluation.

            Console.WriteLine("Regular OR:");
            // The | operator evaluates both operands, even though after 
            // Method1 returns true, you know that the OR expression is
            // true.
            Console.WriteLine("Result is {0}.\n", ConditionalOr.Method1() | ConditionalOr.Method2());
            /*Output:
              Regular OR:
              Method1 called.
              Method2 called.
              Result is True.*/

            Console.WriteLine("Short-circuit OR:");
            // Method2 is not called, because Method1 returns true.
            Console.WriteLine("Result is {0}.\n", ConditionalOr.Method1() || ConditionalOr.Method2());
            /*Output:
              Regular OR:
              Short-circuit OR:
              Method1 called.
              Result is True.*/

            // In Example #2, method Divisible returns True if the
            // first argument is evenly divisible by the second, and False
            // otherwise. Using the | operator instead of the || operator
            // causes a divide-by-zero exception.

            // The following line displays True, because 42 is evenly 
            // divisible by 7.
            Console.WriteLine("Divisible returns {0}.", ConditionalOr.Divisible(42, 7));
            /*Output:
              Divisible returns True.*/

            // The following line displays False, because 42 is not evenly
            // divisible by 5.
            Console.WriteLine("Divisible returns {0}.", ConditionalOr.Divisible(42, 5));
            /*Output:
              Divisible returns False.*/

            // The following line displays False when method Divisible 
            // uses ||, because you cannot divide by 0.
            // If method Divisible uses | instead of ||, this line
            // causes an exception.
            Console.WriteLine("Divisible returns {0}.", ConditionalOr.Divisible(42, 0));
            /*Output:
              Divisible returns False.*/
            if (ConditionalOr.Method2() || ConditionalOr.Method1())
            {
                Console.WriteLine("OR: if (false; true), both func exec cond => true");
            }
            /* Output:
             * Method2 called.
             * Method1 called.
             * OR: if (false; true), both func exec
             */
            if (ConditionalOr.Method1() || ConditionalOr.Method2())
            {
                Console.WriteLine("OR: if (false; true), first func exec cond => true");
            }
            /* Output:
             * Method1 called.
             * OR: if (true; false), fist func exec
             */
            if (ConditionalOr.Method2() && ConditionalOr.Method1())
            {
                Console.WriteLine("AND: if (false; true), first func exec cond => false");
            }
            /* Output:
             * Method2 called.
             */
            if (ConditionalOr.Method1() && ConditionalOr.Method2())
            {
                Console.WriteLine("AND: if (true; false), both func exec cond => true");
            }
            /* Output:
             * Method1 called.
             * Method2 called.
             */



        }

        class ConditionalOr
        {
            // Method1 returns true.
            public static bool Method1()
            {
                Console.WriteLine("Method1 called.");
                return true;
            }

            // Method2 returns false.
            public static bool Method2()
            {
                Console.WriteLine("Method2 called.");
                return false;
            }


            public static bool Divisible(int number, int divisor)
            {
                // If the OR expression uses ||, the division is not attempted
                // when the divisor equals 0.
                return !(divisor == 0 || number % divisor != 0);

                // If the OR expression uses |, the division is attempted when
                // the divisor equals 0, and causes a divide-by-zero exception.
                // Replace the return statement with the following line to
                // see the exception.
                //return !(divisor == 0 | number % divisor != 0);
            }
        }


        // http://msdn.microsoft.com/en-us/library/6a71f45d.aspx
    }
}
