using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataParallelism
{
    public static class ForLoop
    {
        public static void TestTotalFilesSize() {
            long totalSize = 0;
            var dir = @"D:\Dropbox\DEVELOPER\Research for a job\OOPFundamentals";
            if (!Directory.Exists(dir))
            {
                Console.WriteLine("The directory does not exist.");
                return;
            }

            String[] files = Directory.GetFiles(dir);
            Parallel.For(0, files.Length,
                   index => {
                       FileInfo fi = new FileInfo(files[index]);
                       long size = fi.Length;
                       Interlocked.Add(ref totalSize, size);
                   });

            Console.WriteLine("Directory '{0}':", dir);
            Console.WriteLine("{0:N0} files, {1:N0} bytes", files.Length, totalSize);
        }

        public static void TestMultiplyMatrices() {
            // Set up matrices. Use small values to better view 
            // result matrix. Increase the counts to see greater 
            // speedup in the parallel loop vs. the sequential loop.
            int colCount = 180; // 180
            int rowCount = 2000; // 2000
            int colCount2 = 270; // 270

            double[,] m1 = MultiplyMatrices.InitializeMatrix(rowCount, colCount);
            double[,] m2 = MultiplyMatrices.InitializeMatrix(colCount, colCount2);
            double[,] result = new double[rowCount, colCount2];

            #region Sequential loop
            // First do the sequential version.
            Console.Error.WriteLine("Executing sequential loop...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            MultiplyMatrices.MultiplyMatricesSequential(m1, m2, result);
            stopwatch.Stop();
            Console.Error.WriteLine("Sequential loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds);
            // For the skeptics.
            MultiplyMatrices.OfferToPrint(rowCount, colCount2, result);
            #endregion

            // Reset timer and results matrix. 
            stopwatch.Reset();
            result = new double[rowCount, colCount2];

            #region Parallel loop
            // Do the parallel loop.
            Console.Error.WriteLine("Executing parallel loop...");
            stopwatch.Start();
            MultiplyMatrices.MultiplyMatricesParallel(m1, m2, result);
            stopwatch.Stop();
            Console.Error.WriteLine("Parallel loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds);
            MultiplyMatrices.OfferToPrint(rowCount, colCount2, result);
            #endregion
        }
    }
}
