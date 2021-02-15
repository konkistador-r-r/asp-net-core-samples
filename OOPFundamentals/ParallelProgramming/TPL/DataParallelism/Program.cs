using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DataParallelism
{
    class Program
    {
        static void Main(string[] args)
        {
            //ForLoop.TestTotalFilesSize();
            ForLoop.TestMultiplyMatrices();

            //ForEachLoop.TestRotatePictures();

            //ThreadLocalVariables.TestForLoop();
            //ThreadLocalVariables.TestForEachLoop();

            //CancelLoop.TestForLoop();
            //CancelLoop.TestForEachLoop();

            //HandleExceptions.TestAggregateException();

            //UseRangePartitioner.Test();

            //IterateFileDirectories.Test();

            // Keep the console window open in debug mode.
            Console.Error.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
