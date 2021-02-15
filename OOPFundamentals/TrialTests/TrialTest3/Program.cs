using System;
using System.Linq;

namespace TrialTest3
{
    // Spent an hour on coding SimpliestWay
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Find center element of collection. Count is unavailable so use full scan. Shift to the left if collection count is even number");

            var arr = Enumerable.Range(1, 12).ToArray();
            int centerElement = int.MinValue;
            int centerIndex = int.MinValue;

            var result = SimpliestWay(arr);
            centerIndex = result.Item1;
            centerElement = result.Item2;

            Console.WriteLine("The center element index is: " + (centerIndex != int.MinValue ? centerIndex.ToString() : "Unavailable"));
            Console.WriteLine("The center element is: " + (centerElement != int.MinValue ? centerElement.ToString() : "Unavailable"));
            Console.WriteLine("The collection: " + arr.Select(r => r.ToString()).Aggregate((s, r) => s + " " + r));
            Console.ReadLine();
        }

        public static Tuple<int, int> SimpliestWay(System.Collections.IEnumerable arr) {
            int centerElement = int.MinValue;
            int centerIndex = int.MinValue;

            // easyest way - scan two times
            // 1st to findout count
            int count = 0;
            var move = arr.GetEnumerator();
            while (move.MoveNext())
            {
                count++;
            }

            // calculate centerIndex
            centerIndex = count > 0 ? (int)(Math.Round(((decimal)count / 2), MidpointRounding.AwayFromZero)) : int.MinValue;

            // 2nd to find centerElement when centerIndex will match to current element index
            count = 0;
            move = arr.GetEnumerator();
            while (move.MoveNext())
            {
                count++;

                if (count == centerIndex)
                {
                    centerElement = (int)move.Current;
                    break;
                }
            }

            return Tuple.Create(centerIndex, centerElement);
        }
    }
}
