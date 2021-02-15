using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.AgileBookSamples.Modem
{
    public class LoudDialModem : ModemDecorator
    {
        public LoudDialModem(Modem m) : base(m) { }
        public new void Dial(string pno)
        {
            Modem.SpeakerVolume = 10;
            Modem.Dial(pno);
        }
    }
}
