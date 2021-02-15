using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingletonPattern
{
    // Потокобезопасная реализация c использования lock и Lazy
    abstract class Singleton<T> where T : Singleton<T>
    {
        static T _mInstance;
        private static object syncRoot = new Object();

        public static T Instance
        {
            get
            {
                if (_mInstance == null)
                {
                    // Чтобы избежать одновременного доступа к коду из разных потоков критическая секция заключается в блок lock.
                    lock (syncRoot)
                    {
                        if (_mInstance == null)
                        {
                            _mInstance = (T)Activator.CreateInstance(typeof(T), true);
                        }
                    }
                }
                return _mInstance;
            }
        }
    }

    // Потокобезопасная реализация без использования lock но и без Lazy
    public class SingletonNoLock
    {
        // Без Lazy
        private static readonly SingletonNoLock instance = new SingletonNoLock();

        public string Name { get; private set; }

        private SingletonNoLock()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static SingletonNoLock GetInstance()
        {
            return instance;
        }
    }

    // Lazy-реализация через Nested class
    // Реализация через класс Lazy<T>


    class ASingleton : Singleton<ASingleton>
    {
        private ASingleton() { } // to avoid calling asingle.Hello() contructor is private

        public void Hello()
        {
            Console.WriteLine("Hello from ASingleton");
        }
    }
}
