using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.AgileBookSamples.Modem
{
    public class ModemDecoratorTest
    {
        private static void CreateHayes()
        {
            Console.WriteLine("CreateHayes");
            Modem m = new HayesModem();
            Console.WriteLine((null == m.PhoneNumber));
            m.Dial("5551212");
            
            Console.WriteLine("5551212".Equals(m.PhoneNumber));
            Console.WriteLine(0.Equals(m.SpeakerVolume));

            m.SpeakerVolume = 10;
            Console.WriteLine(10.Equals(m.SpeakerVolume));
            Console.WriteLine("");
        }

        private static void LoudDialModem()
        {
            Console.WriteLine("LoudDialModem");
            Modem m = new HayesModem();
            Modem d = new LoudDialModem(m);
            Console.WriteLine((null == d.PhoneNumber));
            Console.WriteLine(0.Equals(d.SpeakerVolume));

            d.Dial("5551212");
            Console.WriteLine("5551212".Equals(d.PhoneNumber));
            Console.WriteLine(10.Equals(d.SpeakerVolume));
            Console.WriteLine("");
        }

        public static void Test()
        {
            CreateHayes();
            LoudDialModem();
        }
    }
}
