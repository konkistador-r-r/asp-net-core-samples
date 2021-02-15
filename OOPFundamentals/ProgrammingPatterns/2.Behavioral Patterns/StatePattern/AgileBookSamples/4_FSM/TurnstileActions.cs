using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.AgileBookSamples._4_FSM
{
    public abstract class TurnstileActions
    {
        public virtual void Lock() { }
        public virtual void Unlock() { }
        public virtual void Thankyou() { }
        public virtual void Alarm() { }
    }
}
