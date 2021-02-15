using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPLAsync
{
    public static class ChainingTasks
    {
        public async static void SingleAntecedentAsync() {
            // Execute the antecedent.
            Task<DayOfWeek> taskA = Task.Run(() => DateTime.Today.DayOfWeek);

            // Execute the continuation when the antecedent finishes.
            await taskA.ContinueWith(antecedent => Console.WriteLine("Today is {0}.", antecedent.Result));
        }

        public static void MultipleAntecedentAsync()
        {
            List<Task<int>> tasks = new List<Task<int>>();
            for (int ctr = 1; ctr <= 10; ctr++)
            {
                int baseValue = ctr;
                tasks.Add(Task.Factory.StartNew((b) => {
                    int i = (int)b;
                    return i * i;
                }, baseValue));
            }
            // wait while all finishes. No eceptions handling there 
            var continuation = Task.WhenAll(tasks);
            // gather result
            long sum = 0;
            for (int ctr = 0; ctr <= continuation.Result.Length - 1; ctr++)
            {
                Console.Write("{0} {1} ", continuation.Result[ctr], ctr == continuation.Result.Length - 1 ? "=" : "+");
                sum += continuation.Result[ctr];
            }
            Console.WriteLine(sum);
        }

        public async static void PassingDataToContinuationAsync()
        {
            var t = Task.Run(() => {
                DateTime dat = DateTime.Now;
                if (dat == DateTime.MinValue)
                    throw new ArgumentException("The clock is not working.");

                if (dat.Hour > 17)
                    return "evening";
                else if (dat.Hour > 12)
                    return "afternoon";
                else
                    return "morning";
            });

            await t.ContinueWith((antecedent) => {
                if (t.Status == TaskStatus.RanToCompletion) // If you want the continuation to run even if the antecedent did not run to successful completion
                {
                    Console.WriteLine("Good {0}!", antecedent.Result);
                    Console.WriteLine("And how are you this fine {0}?", antecedent.Result);
                }
                else if (t.Status == TaskStatus.Faulted)
                {
                    Console.WriteLine(t.Exception.GetBaseException().Message);
                }                
            }); // , TaskContinuationOptions.OnlyOnRanToCompletion
        }

        public static void CancelingContinuation() {
            Random rnd = new Random();
            var cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            Timer timer = new Timer(Elapsed, cts, 5000, Timeout.Infinite);

            var t = Task.Run(() => {
                List<int> product33 = new List<int>();
                for (int ctr = 1; ctr < Int16.MaxValue; ctr++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("\nCancellation requested in antecedent...\n");
                        token.ThrowIfCancellationRequested();
                    }
                    if (ctr % 2000 == 0)
                    {
                        int delay = rnd.Next(16, 501);
                        Thread.Sleep(delay);
                    }

                    if (ctr % 33 == 0)
                        product33.Add(ctr);
                }
                return product33.ToArray();
            }, token);

            Task continuation = t.ContinueWith(antecedent => {
                Console.WriteLine("Multiples of 33:\n");
                var arr = antecedent.Result;
                for (int ctr = 0; ctr < arr.Length; ctr++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("\nCancellation requested in continuation...\n");
                        token.ThrowIfCancellationRequested();
                    }

                    if (ctr % 100 == 0)
                    {
                        int delay = rnd.Next(16, 251);
                        Thread.Sleep(delay);
                    }
                    Console.Write("{0:N0}{1}", arr[ctr],
                                  ctr != arr.Length - 1 ? ", " : "");
                    if (Console.CursorLeft >= 74)
                        Console.WriteLine();
                }
                Console.WriteLine();
            }, token);

            try
            {
                continuation.Wait();
            }
            catch (AggregateException e)
            {
                foreach (Exception ie in e.InnerExceptions)
                    Console.WriteLine("{0}: {1}", ie.GetType().Name, ie.Message);
            }
            finally
            {
                cts.Dispose();
            }

            Console.WriteLine("\nAntecedent Status: {0}", t.Status);
            Console.WriteLine("Continuation Status: {0}", continuation.Status);
        }

        public static void CancelingContinuationNotOnCanceled() {
            var cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            cts.Cancel();

            var t = Task.FromCanceled(token);

            var continuation = t.ContinueWith((antecedent) => {
                Console.WriteLine("The continuation is running.");
            }, TaskContinuationOptions.NotOnCanceled);

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (var ie in ae.InnerExceptions)
                    Console.WriteLine("{0}: {1}", ie.GetType().Name, ie.Message);

                Console.WriteLine();
            }
            finally
            {
                cts.Dispose();
            }

            Console.WriteLine("Task {0}: {1:G}", t.Id, t.Status);
            Console.WriteLine("Task {0}: {1:G}", continuation.Id, continuation.Status);
        }

        public static void HandlingExceptions() {
            var task1 = Task<int>.Run(() => {
                Console.WriteLine("Executing task {0}", Task.CurrentId);
                return 54;
            });
            var continuation = task1.ContinueWith((antecedent) =>
            {
                Console.WriteLine("Executing continuation task {0}", Task.CurrentId);
                Console.WriteLine("Value from antecedent: {0}", antecedent.Result);
                throw new InvalidOperationException();
            });

            try
            {
                task1.Wait();
                continuation.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (var ex in ae.InnerExceptions)
                    Console.WriteLine(ex.Message);
            }
        }

        public static void HandlingExceptionsInsideContinuation() {            
            try
            {
                var t = Task.Run(() => {
                    string s = File.ReadAllText(@"C:\NonexistentFile.txt");
                    return s;
                });

                var c = t.ContinueWith((antecedent) =>
                { // Get the antecedent's exception information.
                    foreach (var ex in antecedent.Exception.InnerExceptions)
                    {
                        if (ex is FileNotFoundException)
                            Console.WriteLine(ex.Message);
                    }
                }, TaskContinuationOptions.OnlyOnFaulted);

                c.Wait();
            }
            catch (AggregateException ae)
            {
                Console.WriteLine("This block is not reachable");

                foreach (var ex in ae.InnerExceptions)
                    Console.WriteLine(ex.Message);
            }
        }

        #region Helpers
        private static void Elapsed(object state)
        {
            CancellationTokenSource cts = state as CancellationTokenSource;
            if (cts == null) return;

            cts.Cancel();
            Console.WriteLine("\nCancellation request issued...\n");
        }
        #endregion
    }
}
