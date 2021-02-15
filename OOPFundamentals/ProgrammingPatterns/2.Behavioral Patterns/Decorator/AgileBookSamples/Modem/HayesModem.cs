using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.AgileBookSamples.Modem
{
    public class HayesModem : Modem
    {
        private string phoneNumber;
        private int speakerVolume;
        public void Dial(string pno)
        {
            phoneNumber = pno;
        }
        public int SpeakerVolume
        {
            get { return speakerVolume; }
            set { speakerVolume = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
        }
    }
}
