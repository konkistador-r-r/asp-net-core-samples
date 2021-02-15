using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.AgileBookSamples.Modem
{
    public class ModemDecorator : Modem
	{
        private Modem modem;
        public ModemDecorator(Modem m)
        {
            modem = m;
        }
        public void Dial(string pno)
        {
            modem.Dial(pno);
        }
        public int SpeakerVolume
        {
            get { return modem.SpeakerVolume; }
            set { modem.SpeakerVolume = value; }
        }
        public string PhoneNumber
        {
            get { return modem.PhoneNumber; }
        }
        protected Modem Modem
        {
            get { return modem; }
        }
    }
}
