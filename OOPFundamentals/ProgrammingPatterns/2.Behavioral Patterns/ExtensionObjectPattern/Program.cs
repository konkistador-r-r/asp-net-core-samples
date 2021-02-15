using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionObjectPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Agile Book ExtensionObjectPattern as part of Visitors Sample");
            AgileBookSamples.BOMReportTest.Test();
            Console.WriteLine("\r\n");

            Console.ReadLine();
        }
    }
}
