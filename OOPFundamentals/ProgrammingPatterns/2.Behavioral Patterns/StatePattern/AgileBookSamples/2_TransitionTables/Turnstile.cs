using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.AgileBookSamples._2_TransitionTables
{
    public class Turnstile
    {
        // Private
        internal State state = State.LOCKED;
        private IList transitions = new ArrayList();
        private delegate void Action();

        // Building the turnstile transition table
        public Turnstile(ITurnstileController controller)
        {
            Action unlock = new Action(controller.Unlock);
            Action alarm = new Action(controller.Alarm);
            Action thankYou = new Action(controller.Thankyou);
            Action lockAction = new Action(controller.Lock);

            AddTransition(State.LOCKED, Event.COIN, State.UNLOCKED, unlock);
            AddTransition(State.LOCKED, Event.PASS, State.LOCKED, alarm);
            AddTransition(State.UNLOCKED, Event.COIN, State.UNLOCKED, thankYou);
            AddTransition(State.UNLOCKED, Event.PASS, State.LOCKED, lockAction);
        }

        // The transition engine
        public void HandleEvent(Event e)
        {
            foreach (Transition transition in transitions)
            {
                if (state == transition.startState && e == transition.trigger)
                {
                    state = transition.endState;
                    transition.action();
                }
            }
        }
        private void AddTransition(State start, Event e, State end, Action action)
        {
            transitions.Add(new Transition(start, e, end, action));
        }
        private class Transition
        {
            public State startState;
            public Event trigger;
            public State endState;
            public Action action;
            public Transition(State start, Event e, State end, Action a)
            {
                this.startState = start;
                this.trigger = e;
                this.endState = end;
                this.action = a;
            }
        }
    }
}
