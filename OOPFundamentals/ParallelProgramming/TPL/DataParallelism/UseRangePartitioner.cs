using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataParallelism
{
    public static class UseRangePartitioner
    {
        public static void Test() {
            // Source must be array or IList.
            var source = Enumerable.Range(0, 10000000).ToArray();
            //   1 000 000 - sequential faster than parallel
            //  10 000 000 - parallel faster than sequential
            // 100 000 000 - parallel faster than sequential
            TestSequentialLoop(source);
            TestForEachLoop(source);
        }

        public static void TestSequentialLoop(int[] source)
        {
            Console.WriteLine("Press any key to start. Press 'c' to cancel.");
            Console.ReadKey();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            double[] results = new double[source.Length];
            CancellationTokenSource cts = new CancellationTokenSource();

            // Run a task so that we can cancel from another thread.
            Task.Factory.StartNew(() =>
            {
                if (Console.ReadKey().KeyChar == 'c')
                    cts.Cancel();
                Console.WriteLine("press any key to exit");
            });

            try
            {
                for (int i = 0; i < source.Length; i++)
                {
                    results[i] = source[i] * Math.PI;
                    cts.Token.ThrowIfCancellationRequested();
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cts.Dispose();
            }


            stopwatch.Stop();
            Console.Error.WriteLine("Sequential loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds);
        }

        public static void TestForEachLoop(int[] source)
        {
            Console.WriteLine("Press any key to start. Press 'c' to cancel.");
            Console.ReadKey();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Partition the entire source array.
            var rangePartitioner = Partitioner.Create(0, source.Length);

            double[] results = new double[source.Length];
            CancellationTokenSource cts = new CancellationTokenSource();

            // Use ParallelOptions instance to store the CancellationToken
            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = cts.Token;
            po.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            // Run a task so that we can cancel from another thread.
            Task.Factory.StartNew(() =>
            {
                if (Console.ReadKey().KeyChar == 'c')
                    cts.Cancel();
                Console.WriteLine("press any key to exit");
            });

            try
            {
                // Loop over the partitions in parallel.
                Parallel.ForEach(rangePartitioner, po, (range, loopState) =>
                {
                // Loop over each range element without a delegate invocation.
                for (int i = range.Item1; i < range.Item2; i++)
                    {
                        results[i] = source[i] * Math.PI;
                        cts.Token.ThrowIfCancellationRequested();
                    }
                });
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cts.Dispose();
            }

            stopwatch.Stop();
            Console.Error.WriteLine("Parallel loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds);
        }
    }
}
