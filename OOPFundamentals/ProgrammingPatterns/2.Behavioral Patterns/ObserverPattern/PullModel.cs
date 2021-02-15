using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    static class PullModel
    {
        public static void Test() {
            var source = new MockTimeSource();
            var sink = new MockTimeSink(source);
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
            void Update();
        }

        public class Subject
        {
            private ArrayList itsObservers = new ArrayList();

            protected void NotifyObservers()
            {
                foreach (Observer observer in itsObservers)
                    observer.Update();

            }
            public void RegisterObserver(Observer observer)
            {
                itsObservers.Add(observer);
            }
        }

        public interface TimeSource
        {
            int GetHours();
            int GetMinutes();
            int GetSeconds();
        }

        public class MockTimeSource : Subject, TimeSource
        {
            private int itsHours;
            private int itsMinutes;
            private int itsSeconds;

            public void SetTime(int hours, int mins, int secs)
            {
                itsHours = hours;
                itsMinutes = mins;
                itsSeconds = secs;
                NotifyObservers();
            }

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
        }

        public class MockTimeSink : Observer
        {
            private int itsHours;
            private int itsMinutes;
            private int itsSeconds;
            private TimeSource itsSource;

            public MockTimeSink(TimeSource source)
            {
                itsSource = source;
            }

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

            public void Update()
            {
                itsHours = itsSource.GetHours();
                itsMinutes = itsSource.GetMinutes();
                itsSeconds = itsSource.GetSeconds();
            }
        }
    }
}
