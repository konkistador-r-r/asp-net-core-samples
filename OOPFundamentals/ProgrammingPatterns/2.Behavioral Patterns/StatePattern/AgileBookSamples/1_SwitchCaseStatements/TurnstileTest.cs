using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.AgileBookSamples._1_SwitchCaseStatements
{
    public class TurnstileTest
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
            turnstile = new Turnstile(controllerSpoof);
        }
        
        public static void InitialConditions()
        {
            Console.WriteLine("InitialConditions");
            SetUp();

            Console.WriteLine(State.LOCKED.Equals(turnstile.state));
            Console.WriteLine("");
        }
        
        public static void CoinInLockedState()
        {
            Console.WriteLine("CoinInLockedState");
            SetUp();

            turnstile.state = State.LOCKED;
            turnstile.HandleEvent(Event.COIN);
            Console.WriteLine(State.UNLOCKED.Equals(turnstile.state));
            Console.WriteLine(controllerSpoof.unlockCalled);
            Console.WriteLine("");
        }
        
        public static void CoinInUnlockedState()
        {
            Console.WriteLine("CoinInUnlockedState");
            SetUp();

            turnstile.state = State.UNLOCKED;
            turnstile.HandleEvent(Event.COIN);
            Console.WriteLine(State.UNLOCKED.Equals(turnstile.state));
            Console.WriteLine(controllerSpoof.thankyouCalled);
            Console.WriteLine("");
        }
        
        public static void PassInLockedState()
        {
            Console.WriteLine("PassInLockedState");
            SetUp();

            turnstile.state = State.LOCKED;
            turnstile.HandleEvent(Event.PASS);
            Console.WriteLine(State.LOCKED.Equals(turnstile.state));
            Console.WriteLine(controllerSpoof.alarmCalled);
            Console.WriteLine("");
        }
        
        public static void PassInUnlockedState()
        {
            Console.WriteLine("PassInUnlockedState");
            SetUp();

            turnstile.state = State.UNLOCKED;
            turnstile.HandleEvent(Event.PASS);
            Console.WriteLine(State.LOCKED.Equals(turnstile.state));
            Console.WriteLine(controllerSpoof.lockCalled);
            Console.WriteLine("");
        }

        public static void Test() {
            InitialConditions();
            CoinInLockedState();
            CoinInUnlockedState();
            PassInLockedState();
            PassInUnlockedState();
        }
    }
}
