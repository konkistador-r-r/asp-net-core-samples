using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveObjectEngineTest
{
    public class DelayedTyper : Command
    {
        private long itsDelay;
        private char itsChar;
        private static bool stop = false;
        public static ActiveObjectEngine engine = new ActiveObjectEngine();
        public static StringBuilder output = new StringBuilder();

        private class StopCommand : Command
        {
            public void Execute()
            {
                DelayedTyper.stop = true;
            }
        }

        public static void Test()
        {
            // each Command instance runs to completion before the next Command instance can run.
            engine.AddCommand(new DelayedTyper(100, '1'));
            engine.AddCommand(new DelayedTyper(300, '3'));
            engine.AddCommand(new DelayedTyper(500, '5'));
            engine.AddCommand(new DelayedTyper(700, '7'));

            Command stopCommand = new StopCommand();
            engine.AddCommand(new SleepCommand(20000, engine, stopCommand));
            engine.Run();
        }

        public DelayedTyper(long delay, char c)
        {
            itsDelay = delay;
            itsChar = c;
        }

        // it hangs in a loop, repeatedly typing a specified character and waiting for a specified delay.
        // It exits the loop when the stop flag is set.
        public void Execute()
        {
            output.Append(itsChar);
            if (!stop)
                DelayAndRepeat();
        }

        private void DelayAndRepeat()
        {
            engine.AddCommand(new SleepCommand(itsDelay, engine, this));
        }
    }
}
