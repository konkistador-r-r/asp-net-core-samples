using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.AgileBookSamples._4_FSM
{
    public class SMCTurnstileTest
    {
        private static Turnstile turnstile;
        private static TurnstileControllerSpoof controllerSpoof;
        private class TurnstileControllerSpoof : ITurnstileController
        {
            public bool lockCalled = false;
            public bool unlockCalled = false;
            public bool thankyouCalled = false;
            public bool alarmCalled = false;
            public void Lock() { lockCalled = true; }
            public void Unlock() { unlockCalled = true; }
            public void Thankyou() { thankyouCalled = true; }
            public void Alarm() { alarmCalled = true; }
        }

        public static void SetUp()
        {
            controllerSpoof = new TurnstileControllerSpoof();
            turnstile = new TurnstileFSM(controllerSpoof);
        }

        public static void InitialConditions()
        {
            Console.WriteLine("InitialConditions");
            SetUp();

            Console.WriteLine(turnstile.GetCurrentState() is Locked);
            Console.WriteLine("");
        }

        public static void CoinInLockedState()
        {
            Console.WriteLine("CoinInLockedState");
            SetUp();

            turnstile.SetState(new Locked());
            turnstile.Coin();
            Console.WriteLine(turnstile.GetCurrentState() is Unlocked);
            Console.WriteLine(controllerSpoof.unlockCalled);
            Console.WriteLine("");
        }

        public static void CoinInUnlockedState()
        {
            Console.WriteLine("CoinInUnlockedState");
            SetUp();

            turnstile.SetState(new Unlocked());
            turnstile.Coin();
            Console.WriteLine(turnstile.GetCurrentState() is Unlocked);
            Console.WriteLine(controllerSpoof.thankyouCalled);
            Console.WriteLine("");
        }

        public static void PassInLockedState()
        {
            Console.WriteLine("PassInLockedState");
            SetUp();

            turnstile.SetState(new Locked());
            turnstile.Pass();
            Console.WriteLine(turnstile.GetCurrentState() is Locked);
            Console.WriteLine(controllerSpoof.alarmCalled);
            Console.WriteLine("");
        }

        public static void PassInUnlockedState()
        {
            Console.WriteLine("PassInUnlockedState");
            SetUp();

            turnstile.SetState(new Unlocked());
            turnstile.Pass();
            Console.WriteLine(turnstile.GetCurrentState() is Locked);
            Console.WriteLine(controllerSpoof.lockCalled);
            Console.WriteLine("");
        }

        public static void Test()
        {
            InitialConditions();
            CoinInLockedState();
            CoinInUnlockedState();
            PassInLockedState();
            PassInUnlockedState();
        }
    }
}
