using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lessons
{
    class ExceptionHandling
    {
        public static void MainMethod()
        {
            FileStream outStream = null;
            FileStream inStream = null;
            try
            {
                outStream = File.OpenWrite("DestinationFile.txt");
                inStream = File.OpenRead("BogusInputFile.txt");
            }
            //  all exceptions will be caught there because the type is of the base exception type "Exception"
            // In exception handling, more specific exceptions will be caught before their more general parent exceptions.
            // and specific will be thrown and caught by the first catch block
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("FileNotFoundException ex:");
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (outStream != null)
                {
                    outStream.Close();
                    Console.WriteLine("outStream closed.");
                }
                if (inStream != null)
                {
                    inStream.Close();
                    Console.WriteLine("inStream closed.");
                }
            }
        }
    }
}
