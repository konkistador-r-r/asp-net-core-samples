using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.AgileBookSamples._1_SwitchCaseStatements
{
    public class Turnstile
    {
        // Private
        internal State state = State.LOCKED;
        private ITurnstileController turnstileController;
        public Turnstile(ITurnstileController action)
        {
            turnstileController = action;
        }
        public void HandleEvent(Event e)
        {
            switch (state)
            {
                case State.LOCKED:
                    switch (e)
                    {
                        case Event.COIN:
                            state = State.UNLOCKED;
                            turnstileController.Unlock();
                            break;
                        case Event.PASS:
                            turnstileController.Alarm();
                            break;
                    }
                    break;
                case State.UNLOCKED:
                    switch (e)
                    {
                        case Event.COIN:
                            turnstileController.Thankyou();
                            break;
                        case Event.PASS:
                            state = State.LOCKED;
                            turnstileController.Lock();
                            break;
                    }
                    break;
            }
        }
    }
}