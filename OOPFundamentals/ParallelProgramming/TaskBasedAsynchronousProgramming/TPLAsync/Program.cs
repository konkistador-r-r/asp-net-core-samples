using System;

namespace TPLAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            //ChainingTasks.SingleAntecedentAsync();

            //ChainingTasks.MultipleAntecedentAsync();

            //ChainingTasks.PassingDataToContinuationAsync();

            //ChainingTasks.CancelingContinuation();

            //ChainingTasks.CancelingContinuationNotOnCanceled();

            //ChainingTasks.HandlingExceptions();

            //ChainingTasks.HandlingExceptionsInsideContinuation();

            //ParallelInvoke.Run();

            //CreatePreComputedTasks.CachedDownloads();

            UnwrapNestedTask.StartTask();

            UnwrapNestedTask.DemonstrateUnwrapExtension();

            // Keep the console window open in debug mode.
            Console.Error.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
