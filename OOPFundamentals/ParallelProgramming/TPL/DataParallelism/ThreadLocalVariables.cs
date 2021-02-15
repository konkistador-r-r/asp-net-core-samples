using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataParallelism
{
    public static class ThreadLocalVariables
    {
        public static void TestForLoop() {
            int[] nums = Enumerable.Range(0, 1000000).ToArray(); // 1 000 000
            long total = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Parallel.For(0, matARows, i => {}); 
            // Use type parameter to make subtotal a long, not an int https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-write-a-parallel-for-loop-with-thread-local-variables
            Parallel.For<long>(0, //The start index
                nums.Length, //The end index
                () => 0, //The function delegate that returns the initial state of the local data for each task.
                (j, loop, subtotal) => // Func<int, ParallelLoopState, long, long>
                {
                    subtotal += nums[j];
                    return subtotal;
                }, // The delegate that is invoked once per iteration.
                (x) => Interlocked.Add(ref total, x) // The delegate that performs a final action on the local state of each task.
            );
            stopwatch.Stop();
            Console.Error.WriteLine("Parallel loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("The Parallel total is {0:N0}", total);


            stopwatch.Reset();
            total = 0;

            stopwatch.Start();
            for (int i = 0; i < nums.Length; i++)
            {
                total += nums[i];
            }
            stopwatch.Stop();
            Console.Error.WriteLine("Sequential loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("The Sequential total is {0:N0}", total);


            stopwatch.Reset();
            total = 0;

            stopwatch.Start();
            total = nums.Sum(x=>(long)x);
            stopwatch.Stop();
            Console.Error.WriteLine("IEnumarable.Sum time in milliseconds: {0}", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("The Sequential total is {0:N0}", total);
        }

        public static void TestForEachLoop() {
            int[] nums = Enumerable.Range(0, 1000000).ToArray();
            long total = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Parallel.ForEach(files, (currentFile) => RotatePictures(currentFile, newDir));
            // First type parameter is the type of the source elements
            // Second type parameter is the type of the thread-local variable (partition subtotal)
            Parallel.ForEach<int, long>(nums, // source collection
                                        () => 0, // method to initialize the local variable
                                        (j, loop, subtotal) => // method invoked by the loop on each iteration
                                         {
                                                subtotal += j; //modify local variable
                                             return subtotal; // value to be passed to next iteration
                                         },
                                        // Method to be executed when each partition has completed.
                                        // finalResult is the final value of subtotal for a particular partition.
                                        (finalResult) => Interlocked.Add(ref total, finalResult)
                                    );
            stopwatch.Stop();
            Console.WriteLine("The total from Parallel.ForEach is {0:N0}", total);            
            Console.Error.WriteLine("Parallel loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds);
        }
    }
}
