using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.AgileBookSamples._3_TheStatePattern
{
    public class Turnstile
    {
        internal static TurnstileState lockedState = new LockedTurnstileState();
        internal static TurnstileState unlockedState = new UnlockedTurnstileState();

        private ITurnstileController turnstileController;

        internal TurnstileState state = lockedState;
        public Turnstile(ITurnstileController action)
        {
            turnstileController = action;
        }
        public void Coin()
        {
            state.Coin(this);
        }
        public void Pass()
        {
            state.Pass(this);
        }
        public void SetLocked()
        {
            state = lockedState;
        }
        public void SetUnlocked()
        {
            state = unlockedState;
        }

        public bool IsLocked()
        {
            return state == lockedState;
        }
        public bool IsUnlocked()
        {
            return state == unlockedState;
        }
        internal void Thankyou()
        {
            turnstileController.Thankyou();
        }

        internal void Alarm()
        {
            turnstileController.Alarm();
        }
        internal void Lock()
        {
            turnstileController.Lock();
        }
        internal void Unlock()
        {
            turnstileController.Unlock();
        }
    }
}
