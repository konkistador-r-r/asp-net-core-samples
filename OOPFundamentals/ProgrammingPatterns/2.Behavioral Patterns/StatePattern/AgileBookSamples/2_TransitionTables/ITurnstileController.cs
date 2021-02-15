using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.AgileBookSamples._2_TransitionTables
{
    public interface ITurnstileController
    {
        void Lock();
        void Unlock();
        void Thankyou();
        void Alarm();
    }
}
