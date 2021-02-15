using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.AgileBookSamples._4_FSM
{
    //
    // public class State
    // This is the base State class
    //
    public abstract class State
    {
        public abstract string StateName();
        // default event functions
        public virtual void Pass(Turnstile name)
        {
            throw new FSMError("Pass", name.GetCurrentState());
        }
        public virtual void Coin(Turnstile name)
        {
            throw new FSMError("Coin", name.GetCurrentState());
        }
    }

    public class FSMError : ApplicationException
    {
        private static string message = "Undefined transition from state: {0} with event: {1}.";
        public FSMError(string theEvent, State state) : base(string.Format(message, state.StateName(), theEvent))
        {
        }
    }
}
