using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ExtensionObjectPattern.AgileBookSamples
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

        private static string ChildText(XmlElement element, string childName)
        {
            return Child(element, childName).InnerText;
        }
        private static XmlElement Child(XmlElement element, string childName)
        {
            XmlNodeList children =
            element.GetElementsByTagName(childName);
            return children.Item(0) as XmlElement;
        }
        
        public static void PiecePart1XML()
        {
            Console.WriteLine("PiecePart1XML");
            SetUp();

            IPartExtension e = p1.GetExtension("XML");
            XmlPartExtension xe = e as XmlPartExtension;
            XmlElement xml = xe.XmlElement;

            Console.WriteLine("PiecePart".Equals(xml.Name));
            Console.WriteLine("997624".Equals(ChildText(xml, "PartNumber")));
            Console.WriteLine("MyPart".Equals(ChildText(xml, "Description")));
            Console.WriteLine(3.2.Equals(Double.Parse(ChildText(xml, "Cost"))));
            Console.WriteLine("");
        }
        
        public static void PiecePart2XML()
        {
            Console.WriteLine("PiecePart2XML");
            SetUp();

            IPartExtension e = p2.GetExtension("XML");
            XmlPartExtension xe = e as XmlPartExtension;
            XmlElement xml = xe.XmlElement;

            Console.WriteLine("PiecePart".Equals(xml.Name));
            Console.WriteLine("7734".Equals(ChildText(xml, "PartNumber")));
            Console.WriteLine("Hell".Equals(ChildText(xml, "Description")));
            Console.WriteLine(666.0.Equals(Double.Parse(ChildText(xml, "Cost"))));
            Console.WriteLine("");
        }
        
        public static void SimpleAssemblyXML()
        {
            Console.WriteLine("SimpleAssemblyXML");
            SetUp();

            IPartExtension e = a.GetExtension("XML");
            XmlPartExtension xe = e as XmlPartExtension;
            XmlElement xml = xe.XmlElement;

            Console.WriteLine("Assembly".Equals(xml.Name));
            Console.WriteLine("5879".Equals(ChildText(xml, "PartNumber")));
            Console.WriteLine("MyAssembly".Equals(ChildText(xml, "Description")));

            XmlElement parts = Child(xml, "Parts");
            XmlNodeList partList = parts.ChildNodes;
            Console.WriteLine(0.Equals(partList.Count));
            Console.WriteLine("");
        }
        
        public static void AssemblyWithPartsXML()
        {
            Console.WriteLine("AssemblyWithPartsXML");
            SetUp();
            a.Add(p1);
            a.Add(p2);

            IPartExtension e = a.GetExtension("XML");
            XmlPartExtension xe = e as XmlPartExtension;
            XmlElement xml = xe.XmlElement;

            Console.WriteLine("Assembly".Equals(xml.Name));
            Console.WriteLine("5879".Equals(ChildText(xml, "PartNumber")));
            Console.WriteLine("MyAssembly".Equals(ChildText(xml, "Description")));

            XmlElement parts = Child(xml, "Parts");
            XmlNodeList partList = parts.ChildNodes;
            Console.WriteLine(2.Equals(partList.Count));

            XmlElement partElement = partList.Item(0) as XmlElement;
            Console.WriteLine("PiecePart".Equals(partElement.Name));
            Console.WriteLine("997624".Equals(ChildText(partElement, "PartNumber")));

            partElement = partList.Item(1) as XmlElement;
            Console.WriteLine("PiecePart".Equals(partElement.Name));
            Console.WriteLine("7734".Equals(ChildText(partElement, "PartNumber")));
            Console.WriteLine("");
        }
        
        public static void PiecePart1toCSV()
        {
            Console.WriteLine("PiecePart1toCSV");
            SetUp();

            IPartExtension e = p1.GetExtension("CSV");
            ICsvPartExtension ce = e as ICsvPartExtension;
            String csv = ce.CsvText;
            Console.WriteLine("PiecePart,997624,MyPart,3,2".Equals(csv));
            Console.WriteLine("");
        }
        
        public static void PiecePart2toCSV()
        {
            Console.WriteLine("PiecePart2toCSV");
            SetUp();

            IPartExtension e = p2.GetExtension("CSV");
            ICsvPartExtension ce = e as ICsvPartExtension;
            String csv = ce.CsvText;
            Console.WriteLine("PiecePart,7734,Hell,666".Equals(csv));
            Console.WriteLine("");
        }
        
        public static void SimpleAssemblyCSV()
        {
            Console.WriteLine("SimpleAssemblyCSV");
            SetUp();

            IPartExtension e = a.GetExtension("CSV");
            ICsvPartExtension ce = e as ICsvPartExtension;
            String csv = ce.CsvText;
            Console.WriteLine("Assembly,5879,MyAssembly".Equals(csv));
            Console.WriteLine("");
        }
        
        public static void AssemblyWithPartsCSV()
        {
            Console.WriteLine("AssemblyWithPartsCSV");
            SetUp();
            a.Add(p1);
            a.Add(p2);

            IPartExtension e = a.GetExtension("CSV");
            ICsvPartExtension ce = e as ICsvPartExtension;
            String csv = ce.CsvText;
            Console.WriteLine(("Assembly,5879,MyAssembly," 
                                + "{PiecePart,997624,MyPart,3,2}," 
                                + "{PiecePart,7734,Hell,666}")
                            .Equals(csv));
            Console.WriteLine("");
        }
        
        public static void BadExtension()
        {
            Console.WriteLine("BadExtension");
            SetUp();
            IPartExtension pe = p1.GetExtension("ThisStringDoesn'tMatchAnyException");
            Console.WriteLine((pe is BadPartExtension).ToString());
            Console.WriteLine("");
        }

        public static void TestReportParts() {
            CreatePart();
            CreateAssembly();
            Assembly();
            AssemblyOfAssemblies();
        }

        public static void TestReportFunctionality()
        {
            PiecePart1XML();
            PiecePart2XML();
            SimpleAssemblyXML();
            AssemblyWithPartsXML();
            PiecePart1toCSV();
            PiecePart2toCSV();
            SimpleAssemblyCSV();
            AssemblyWithPartsCSV();
            BadExtension();
        }

        public static void Test()
        {
            TestReportParts();
            TestReportFunctionality();
        }
    }
}
