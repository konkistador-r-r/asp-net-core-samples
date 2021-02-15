using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.AgileBookSamples._4_FSM
{
    //
    // class Locked
    // handles the Locked State and its events
    //
    public class Locked : State
    {
        public override string StateName()
        { return "Locked"; }
        //
        // responds to Coin event
        //
        public override void Coin(Turnstile name)
        {
            name.Unlock();
            // change the state
            name.SetState(name.GetItsUnlockedState());
        }
        //
        // responds to Pass event
        //
        public override void Pass(Turnstile name)
        {
            name.Alarm();
            // change the state
            name.SetState(name.GetItsLockedState());
        }
    }
}
