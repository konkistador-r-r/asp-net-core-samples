using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons
{
    class Loops
    {
        public static void WhileLoop()
        {

            int myInt = 0;

            while (myInt < 0)
            {
                Console.Write("WhileLoop result: {0} ", myInt);
                myInt++;
            }
            Console.WriteLine("\n");
        }

        public static void DoWhileLoop()
        {

            int myInt = 0;

            do
            {
                Console.Write("DoWhileLoop result: {0} ", myInt);
                myInt++;
            } while (myInt < 0);

            Console.WriteLine();

        }

        public static void ForLoop()
        {
            for (int i = 0; i < 20; i++)
            {
                if (i == 10)
                    break;

                if (i % 2 == 0)
                    continue;

                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }

        public static void ForEachLoop()
        {
             string[] names = { "Cherry", "Joe", "Matt", "Robert" };

             foreach (string name in names)
             {
                 Console.WriteLine("{0} ", name);
             }
        }


       
    }
}
