using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataParallelism
{
    public static class ForEachLoop
    {
        public static void TestRotatePictures() {
            // A simple source for demonstration purposes. Modify this path as necessary.
            String[] files = System.IO.Directory.GetFiles(@"D:\Dropbox\DEVELOPER\Research for a job\OOPFundamentals\ParallelProgramming\TPL\Samples\OriginalPictures", "*.jpg");
            String newDir = @"D:\Dropbox\DEVELOPER\Research for a job\OOPFundamentals\ParallelProgramming\TPL\Samples\ModifiedPicrues";

            DeleteAllFiles(newDir);
            Stopwatch stopwatch = new Stopwatch();


            #region Sequential loop
            stopwatch.Start();

            foreach (var currentFile in files)
            {
                RotatePictures(currentFile, newDir);
            }

            stopwatch.Stop();
            Console.Error.WriteLine("Sequential loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds);
            #endregion

            DeleteAllFiles(newDir);
            stopwatch.Reset();

            #region Parallel loop

            stopwatch.Start();
            // Method signature: Parallel.ForEach(IEnumerable<TSource> source, Action<TSource> body)
            // Be sure to add a reference to System.Drawing.dll.
            Parallel.ForEach(files, (currentFile) => RotatePictures(currentFile, newDir));

            stopwatch.Stop();
            Console.Error.WriteLine("Parallel loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds);

            #endregion
        }

        private static void DeleteAllFiles(string dirPath) {
            System.IO.DirectoryInfo di = new DirectoryInfo(dirPath);
            foreach (FileInfo file in di.EnumerateFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.EnumerateDirectories())
            {
                dir.Delete(true);
            }
        }

        public static void RotatePictures(string currentFile, string newDir) {
            // The more computational work you do here, the greater 
            // the speedup compared to a sequential foreach loop.
            String filename = System.IO.Path.GetFileName(currentFile);
            var bitmap = new Bitmap(currentFile);

            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            bitmap.Save(Path.Combine(newDir, filename));

            // Peek behind the scenes to see how work is parallelized.
            // But be aware: Thread contention for the Console slows down parallel loops!!!

            //Console.WriteLine("Processing {0} on thread {1}", filename, Thread.CurrentThread.ManagedThreadId);
            //close lambda expression and method invocation
        }
    }
}
