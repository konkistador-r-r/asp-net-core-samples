using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveObjectEngineTest
{
    public class SleepCommand : Command
    {
        private Command wakeupCommand = null;
        private ActiveObjectEngine engine = null;
        private long sleepTime = 0;
        private DateTime startTime;
        private bool started = false;

        public SleepCommand(long milliseconds, ActiveObjectEngine e, Command wakeupCommand)
        {
            sleepTime = milliseconds;
            engine = e;
            this.wakeupCommand = wakeupCommand;
        }
        public void Execute()
        {
            DateTime currentTime = DateTime.Now;
            if (!started)
            {
                started = true;
                startTime = currentTime;
                engine.AddCommand(this);
            }
            else
            {
                // When a thread in a multithreaded program waits for an event, the thread usually invokes an
                // operating system call that blocks the thread until the event has occurred. 
                // This program does not block. Instead, if the event it is waiting for (elapsedTime.TotalMilliseconds<sleepTime)
                // has not occurred, the thread simply puts itself back into the ActiveObjectEngine.
               TimeSpan elapsedTime = currentTime - startTime;
                if (elapsedTime.TotalMilliseconds < sleepTime)
                {
                    engine.AddCommand(this);
                }
                else
                {
                    engine.AddCommand(wakeupCommand);
                }
            }
        }
    }
}
