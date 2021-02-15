using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    static class PushModel
    {
        public static void Test()
        {
            MockTimeSource source = new MockTimeSource();
            MockTimeSink sink = new MockTimeSink();
            source.RegisterObserver(sink);
            
            // changes in object - source
            source.SetTime(3, 4, 5);
            // affects in object - sink
            AssertSinkEquals(sink, 3, 4, 5);
            Console.WriteLine();
            source.SetTime(7, 8, 9);
            AssertSinkEquals(sink, 7, 8, 9);
        }

        private static void AssertSinkEquals(MockTimeSink sink, int hours, int mins, int secs)
        {
            Console.WriteLine("Hours equal {0}", hours.Equals(sink.GetHours()).ToString());
            Console.WriteLine("Minutes equal {0}", mins.Equals(sink.GetMinutes()).ToString());
            Console.WriteLine("Seconds equal {0}", secs.Equals(sink.GetSeconds()).ToString());
        }

        public interface Observer
        {
            void Update(int hours, int minutes, int secs);
        }

        public interface TimeSource
        {
            void RegisterObserver(Observer observer);
        }

        public interface TimeSink
        {
            void SetTime(int hours, int minutes, int seconds);
        }

        public class MockTimeSource : TimeSource
        {
            private Observer itsObserver;
            public void SetTime(int hours, int minutes, int seconds)
            {
                itsObserver.Update(hours, minutes, seconds);
            }
            public void RegisterObserver(Observer observer)
            {
                itsObserver = observer;
            }
        }

        public class MockTimeSink : Observer
        {
            private int itsHours;
            private int itsMinutes;
            private int itsSeconds;
            public int GetHours()
            {
                return itsHours;
            }
            public int GetMinutes()
            {
                return itsMinutes;
            }
            public int GetSeconds()
            {
                return itsSeconds;
            }
            public void Update(int hours, int minutes, int secs)
            {
                itsHours = hours;
                itsMinutes = minutes;
                itsSeconds = secs;
            }
        }
    }
}
