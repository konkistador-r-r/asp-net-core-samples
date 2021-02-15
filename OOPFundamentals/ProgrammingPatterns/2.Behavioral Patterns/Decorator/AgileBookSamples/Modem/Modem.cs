using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.AgileBookSamples.Modem
{
    public interface Modem
    {
        void Dial(string pno);
        int SpeakerVolume { get; set; }
        string PhoneNumber { get; }
    }
}
