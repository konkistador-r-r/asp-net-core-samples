using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.AgileBookSamples._3_TheStatePattern
{
    internal class UnlockedTurnstileState : TurnstileState
    {
        public void Coin(Turnstile t)
        {
            t.Thankyou();
        }
        public void Pass(Turnstile t)
        {
            t.SetLocked();
            t.Lock();
        }
    }
}
