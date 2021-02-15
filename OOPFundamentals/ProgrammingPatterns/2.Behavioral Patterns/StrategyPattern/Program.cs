using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class Program
    {
        // The strategy pattern is ideal when code should programmatically determine which algorithm, function, or method should be executed at runtime.
        // The goal of the strategy design pattern is to allow the Client to perform the core algorithm, based on the locally-selected Strategy.
        static void Main(string[] args)
        {
            CarSample.Test();

            Console.WriteLine();

            PostalServicePackaging.Test();

            Console.ReadLine();
        }
    }

    

}
