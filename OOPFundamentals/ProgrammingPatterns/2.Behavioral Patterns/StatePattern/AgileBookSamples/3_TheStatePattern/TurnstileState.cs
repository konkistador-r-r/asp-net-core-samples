using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.AgileBookSamples._3_TheStatePattern
{
    public interface TurnstileState
    {
        void Coin(Turnstile t);
        void Pass(Turnstile t);
    }
}
