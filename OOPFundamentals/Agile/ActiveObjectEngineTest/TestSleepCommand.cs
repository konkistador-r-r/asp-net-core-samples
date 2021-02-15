using NUnit.Framework;
using System;

namespace ActiveObjectEngineTest
{
    [TestFixture]
    public class TestSleepCommand
    {
        private class WakeUpCommand : Command
        {
            public bool executed = false;
            public void Execute() { executed = true; }
        }

        [Test(Description = "We can draw an analogy between this program and a multithreaded program that is waiting for an event.")]
        public void TestSleep()
        {
            WakeUpCommand wakeup = new WakeUpCommand();
            ActiveObjectEngine e = new ActiveObjectEngine();

            // Building multithreaded systems using variations of this technique has been, and will continue to be, a
            // very common practice.Threads of this kind have been known as run - to - completion tasks(RTC);
            // each Command instance runs to completion before the next Command instance can run.The name RTC
            // implies that the Command instances do not block.

            // The fact that the Command instances all run to completion gives RTC threads the interesting advantage
            // that they all share the same runtime stack. Unlike the threads in a traditional multithreaded system,
            // it is not necessary to define or allocate a separate runtime stack for each RTC thread.This can be a
            // powerful advantage in memory - constrained systems with many threads.
            

                        SleepCommand c = new SleepCommand(1000, e, wakeup);
            e.AddCommand(c);
            DateTime start = DateTime.Now;
            e.Run();
            DateTime stop = DateTime.Now;
            double sleepTime = (stop - start).TotalMilliseconds;

            Assert.IsTrue(sleepTime >= 1000, "SleepTime " + sleepTime + " expected > 1000");
            Assert.IsTrue(sleepTime <= 1100, "SleepTime " + sleepTime + " expected < 1100");
            Assert.IsTrue(wakeup.executed, "Command Executed");
        }

        [Test()]
        public void TestDelayedTyper()
        {
            // These strings are different because the CPU clock and the real-time clock aren't in perfect sync. This
            // kind of nondeterministic behavior is the hallmark of multithreaded systems.
            DelayedTyper.Test();
            while (DelayedTyper.engine.CommandsCount() > 0)
            {
                continue;
            }

            Assert.AreEqual(DelayedTyper.output.ToString(), "1357113115131711315113117153111311517311131511317115311131175131113151173111531113171513111315171311153111731151311131751131115311713115131117315113111531711311513117131511311175311131151317113151131171531113115173111315113171153111311751311131511731115311131715131113151713111351117311513111317511311135117131151311173151131113517113115137");
        }
    }
}