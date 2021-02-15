using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.AgileBookSamples._4_FSM
{
    //
    // class Unlocked
    // handles the Unlocked State and its events
    //
    public class Unlocked : State
    {
        public override string StateName() { return "Unlocked"; }
        //
        // responds to Coin event
        //
        public override void Coin(Turnstile name)
        {
            name.Thankyou();
            // change the state
            name.SetState(name.GetItsUnlockedState());
        }
        //
        // responds to Pass event
        //
        public override void Pass(Turnstile name)
        {
            name.Lock();
            // change the state
            name.SetState(name.GetItsLockedState());
        }
    }
}
