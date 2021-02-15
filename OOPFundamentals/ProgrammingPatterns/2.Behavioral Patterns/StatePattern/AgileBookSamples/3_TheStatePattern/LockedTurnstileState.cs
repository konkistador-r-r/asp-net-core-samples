using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.AgileBookSamples._3_TheStatePattern
{
    internal class LockedTurnstileState : TurnstileState
    {
        public void Coin(Turnstile t)
        {
            t.SetUnlocked();
            t.Unlock();
        }
        public void Pass(Turnstile t)
        {
            t.Alarm();
        }
    }
}
