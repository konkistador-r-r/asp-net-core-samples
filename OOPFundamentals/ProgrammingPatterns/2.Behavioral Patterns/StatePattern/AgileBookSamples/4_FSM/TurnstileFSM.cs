using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.AgileBookSamples._4_FSM
{
    public class TurnstileFSM : Turnstile
    {
        private readonly ITurnstileController controller;
        public TurnstileFSM(ITurnstileController controller)
        {
            this.controller = controller;
        }
        public override void Lock()
        {
            controller.Lock();
        }
        public override void Unlock()
        {
            controller.Unlock();
        }
        public override void Thankyou()
        {
            controller.Thankyou();
        }
        public override void Alarm()
        {
            controller.Alarm();
        }
    }
}
