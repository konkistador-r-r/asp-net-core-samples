using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern.AgileBookSamples.ReportGenerationVisitors
{
    // a bill of materials (BOM)
    public class BOMReportTest
    {
        private static PiecePart p1;
        private static PiecePart p2;
        private static Assembly a;

        public static void SetUp()
        {
            p1 = new PiecePart("997624", "MyPart", 3.20);
            p2 = new PiecePart("7734", "Hell", 666);
            a = new Assembly("5879", "MyAssembly");
        }

        public static void CreatePart()
        {
            Console.WriteLine("CreatePart");
            SetUp();
            Console.WriteLine("997624".Equals(p1.PartNumber).ToString());
            Console.WriteLine("MyPart".Equals(p1.Description).ToString());
            Console.WriteLine(3.20.Equals(p1.Cost).ToString());
            Console.WriteLine("");
        }
        
        public static void CreateAssembly()
        {
            Console.WriteLine("CreateAssembly");
            SetUp();
            Console.WriteLine("5879".Equals(a.PartNumber).ToString());
            Console.WriteLine("MyAssembly".Equals(a.Description).ToString());
            Console.WriteLine("");
        }
        
        public static void Assembly()
        {
            Console.WriteLine("Assembly");
            SetUp();
            a.Add(p1);
            a.Add(p2);
            Console.WriteLine(2.Equals(a.Parts.Count).ToString());

            PiecePart p = a.Parts[0] as PiecePart;
            Console.WriteLine(p.Equals(p1).ToString());

            p = a.Parts[1] as PiecePart;
            Console.WriteLine(p.Equals(p2).ToString());
            Console.WriteLine("");
        }
        
        public static void AssemblyOfAssemblies()
        {
            Console.WriteLine("AssemblyOfAssemblies");
            SetUp();
            Assembly subAssembly = new Assembly("1324", "SubAssembly");
            subAssembly.Add(p1);
            a.Add(subAssembly);
            Console.WriteLine(subAssembly.Equals(a.Parts[0]).ToString());
            Console.WriteLine("");
        }


        private class TestingVisitor : PartVisitor
        {
            public IList visitedParts = new ArrayList();
            public void Visit(PiecePart p)
            {
                visitedParts.Add(p);
            }
            public void Visit(Assembly assy)
            {
                visitedParts.Add(assy);
            }
        }        
        public static void VisitorCoverage()
        {
            Console.WriteLine("VisitorCoverage");
            SetUp();
            a.Add(p1);
            a.Add(p2);
            TestingVisitor visitor = new TestingVisitor();
            a.Accept(visitor);

            Console.WriteLine(visitor.visitedParts.Contains(p1).ToString());
            Console.WriteLine(visitor.visitedParts.Contains(p2).ToString());
            Console.WriteLine(visitor.visitedParts.Contains(a).ToString());
            Console.WriteLine("");
        }


        private static Assembly cellphone;
        private static void SetUpReportDatabase()
        {
            PiecePart display = new PiecePart("DS-1428", "LCD Display", 14.37);
            PiecePart speaker = new PiecePart("SP-92", "Speaker", 3.50);
            PiecePart microphone = new PiecePart("MC-28", "Microphone", 5.30);
            PiecePart cellRadio = new PiecePart("CR-56", "Cell Radio", 30);
            PiecePart frontCover = new PiecePart("FC-77", "Front Cover", 1.4);
            PiecePart backCover = new PiecePart("RC-77", "RearCover", 1.2);

            Assembly keypad = new Assembly("KP-62", "Keypad");
            Assembly button = new Assembly("B52", "Button");
            PiecePart buttonCover = new PiecePart("CV-15", "Cover", .5);
            PiecePart buttonContact = new PiecePart("CN-2", "Contact", 1.2);
            button.Add(buttonCover);
            button.Add(buttonContact);
            for (int i = 0; i < 15; i++)
                keypad.Add(button);

            cellphone = new Assembly("CP-7734", "Cell Phone");
            cellphone.Add(display);
            cellphone.Add(speaker);
            cellphone.Add(microphone);
            cellphone.Add(cellRadio);
            cellphone.Add(frontCover);
            cellphone.Add(backCover);
            cellphone.Add(keypad);
        }
        
        public static void ExplodedCost()
        {
            Console.WriteLine("ExplodedCost");
            SetUpReportDatabase();
            ExplodedCostVisitor v = new ExplodedCostVisitor();
            cellphone.Accept(v);
            
            Console.WriteLine(81.27.Equals(Math.Round(v.Cost, 2)).ToString());
            Console.WriteLine("");
        }

        public static void PartCount()
        {
            Console.WriteLine("PartCount");
            SetUpReportDatabase();
            PartCountVisitor v = new PartCountVisitor();
            cellphone.Accept(v);

            Console.WriteLine(36.Equals(v.PieceCount).ToString());
            Console.WriteLine(8.Equals(v.PartNumberCount).ToString());
            Console.WriteLine(1.Equals(v.GetCountForPart("DS-1428")).ToString());
            Console.WriteLine(1.Equals(v.GetCountForPart("SP-92")).ToString());
            Console.WriteLine(1.Equals(v.GetCountForPart("MC-28")).ToString());
            Console.WriteLine(1.Equals(v.GetCountForPart("CR-56")).ToString());
            Console.WriteLine(1.Equals(v.GetCountForPart("RC-77")).ToString());
            Console.WriteLine(15.Equals(v.GetCountForPart("CV-15")).ToString());
            Console.WriteLine(15.Equals(v.GetCountForPart("CN-2")).ToString());
            Console.WriteLine(0.Equals(v.GetCountForPart("Bob")).ToString());
            Console.WriteLine("");
        }

        public static void TestReportParts() {
            CreatePart();
            VisitorCoverage();
            CreateAssembly();
            Assembly();
            AssemblyOfAssemblies();
        }

        public static void TestReportFunctionality()
        {
            SetUpReportDatabase();
            ExplodedCost();
            PartCount();
        }

        public static void Test()
        {
            TestReportParts();
            TestReportFunctionality();
        }
    }
}
