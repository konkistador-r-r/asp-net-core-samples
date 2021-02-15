using System;

namespace VisitorPattern.AgileBookSamples.AcyclicVisitor
{
    
    class ModemVisitorTest
    {
        private static UnixModemConfigurator v;
        private static IOSModemConfigurator i;
        private static HayesModem h;
        private static ZoomModem z;
        private static ErnieModem e;
        private static NewModem n;


        private static void SetUp()
        {
            v = new UnixModemConfigurator();
            i = new IOSModemConfigurator();
            h = new HayesModem();
            z = new ZoomModem();
            e = new ErnieModem();
            n = new NewModem();
        }


        private static void HayesForUnix()
        {
            h.Accept(v);
            Console.WriteLine(h.Configuration.Equals(0.45).ToString());

            h.Accept(i);
            Console.WriteLine(h.Configuration.Equals(1.45).ToString());
        }


        private static void ZoomForUnix()
        {
            z.Accept(v);
            Console.WriteLine(z.Configuration.Equals(2).ToString());

            z.Accept(i);
            Console.WriteLine(z.Configuration.Equals(22).ToString());
        }

        
        private static void ErnieForUnix()
        {
            e.Accept(v);
            Console.WriteLine(e.Configuration.Equals("&s1=4&D=3").ToString());

            e.Accept(i);
            Console.WriteLine(e.Configuration.Equals("&s4=4&D=8").ToString());
        }

        private static void NewForUnixAndIOS()
        {
            dynamic obj = new System.Dynamic.ExpandoObject();
            obj.Data = "5";

            n.Accept(v);
            Console.WriteLine(((dynamic)n.Configuration).Data.Equals("5").ToString());

            n.Accept(i);
            Console.WriteLine(((dynamic)n.Configuration).Data.Equals(10).ToString());
        }

        public static void Test() {
            SetUp();
            HayesForUnix();
            ZoomForUnix();
            ErnieForUnix();
            NewForUnixAndIOS();
        }
    }
}
