using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WorkingWithThreads
{
    class Program
    {
        #region создания дополнительных потоков
        //static void Main(string[] args)
        //{
        //    // В главном потоке создается новый поток t, исполняющий метод, который непрерывно печатает символ ‘y’.
        //    Thread t = new Thread(WriteY);
        //    t.Start();

        //    // Одновременно главный поток непрерывно печатает символ ‘x’.
        //    while (true)
        //        Console.Write("x"); // Все время печатать 'x'
        //}

        //static void WriteY()
        //{
        //    while (true)
        //        Console.Write("y"); // Все время печатать 'y'
        //}
        #endregion

        #region локальные переменные хранятся раздельно
        //static void Main()
        //{
        //    new Thread(Go).Start();      // Выполнить Go() в новом потоке
        //    Go();                         // Выполнить Go() в главном потоке

        //    Console.ReadLine();
        //}

        //// CLR назначает каждому потоку свой стек, так что локальные переменные хранятся раздельно.
        //static void Go()
        //{
        //    // Определяем и используем локальную переменную 'cycles'
        //    for (int cycles = 0; cycles < 5; cycles++)
        //        Console.WriteLine("{0}-?", cycles);
        //}
        #endregion

        #region C# обеспечивает потоковую безопасность при помощи оператора lock:
        // Проблема состоит в том, что один поток может выполнить оператор if, пока другой поток выполняет 
        // WriteLine, т.е. до того как done будет установлено в true.
        // Лекарство состоит в получении эксклюзивной блокировки на время чтения и записи разделяемых полей. 
        static bool done;    
        static object locker = new object();

        static void Main()
        {
            new Thread(Go).Start();
            Go();

            Console.ReadLine();
        }

        // Go сейчас – экземплярный метод
        static void Go()
        {
            // Когда два потока одновременно борются за блокировку (в нашем случае объекта locker),
            // один поток переходит к ожиданию (блокируется), пока блокировка не освобождается. 
            lock (locker)
            {
                if (!done) { Console.WriteLine("Done"); done = true; }
            }
            // В данном случае это гарантирует, что только один поток может одновременно 
            // исполнять критическую секцию кода, и "Done" будет напечатано только один раз. 
            // Код, защищенный таким образом от неопределённости в плане многопоточного исполнения, называется 
            // потокобезопасным.
        }
        #endregion
    }
}
