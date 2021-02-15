using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.AgileBookSamples._4_FSM
{
    //
    // class Turnstile
    // This is the Finite State Machine class
    //
    public class Turnstile : TurnstileActions
    {
        private State itsState;
        private static string itsVersion = " ";
        // instance variables for each state
        private Unlocked itsUnlockedState;
        private Locked itsLockedState;
        // constructor
        public Turnstile()
        {
            itsUnlockedState = new Unlocked();
            itsLockedState = new Locked();
            itsState = itsLockedState;
            // Entry functions for: Locked
        }
        // accessor functions
        public string GetVersion()
        {
            return itsVersion;
        }
        public string GetCurrentStateName()
        {
            return itsState.StateName();
        }
        public State GetCurrentState()
        {
            return itsState;
        }
        public State GetItsUnlockedState()
        {
            return itsUnlockedState;
        }
        public State GetItsLockedState()
        {
            return itsLockedState;
        }
        // Mutator functions
        public void SetState(State value)
        {
            itsState = value;
        }
        // event functions - forward to the current State
        public void Pass()
        {
            itsState.Pass(this);
        }
        public void Coin()
        {
            itsState.Coin(this);
        }
    }
}
