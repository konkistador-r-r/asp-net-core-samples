using System;

namespace VisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Agile Book Visitor Sample");
            AgileBookSamples.Visitor.ModemVisitorTest.Test();
            Console.WriteLine("\r\n");

            Console.WriteLine("Agile Book Acyclic Visitor Sample");
            AgileBookSamples.Visitor.ModemVisitorTest.Test();
            Console.WriteLine("\r\n");

            Console.WriteLine("Agile Book ReportGeneration via Visitors Sample");
            AgileBookSamples.ReportGenerationVisitors.BOMReportTest.Test();
            Console.WriteLine("\r\n");

            Console.ReadLine();
        }
    }
}
