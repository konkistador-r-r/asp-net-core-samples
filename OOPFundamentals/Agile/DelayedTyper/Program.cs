using System;

namespace DelayedTyper
{
    public class DelayedTyper : Command
    {
        private long itsDelay;
        private char itsChar;
        private static bool stop = false;
        private static ActiveObjectEngine engine = new ActiveObjectEngine();

        private class StopCommand : Command
        {
            public void Execute()
            {
                DelayedTyper.stop = true;
            }
        }

        public static void Main(string[] args)
        {
            engine.AddCommand(new DelayedTyper(100, '1'));
            engine.AddCommand(new DelayedTyper(300, '3'));
            engine.AddCommand(new DelayedTyper(500, '5'));
            engine.AddCommand(new DelayedTyper(700, '7'));
            Command stopCommand = new StopCommand();
            engine.AddCommand(
            new SleepCommand(20000, engine, stopCommand));
            engine.Run();
        }

        public DelayedTyper(long delay, char c)
        {
            itsDelay = delay;
            itsChar = c;
        }

        public void Execute()
        {
            Console.Write(itsChar);
            if (!stop)
                DelayAndRepeat();
        }

        private void DelayAndRepeat()
        {
            engine.AddCommand(
            new SleepCommand(itsDelay, engine, this));
        }
    }
}
