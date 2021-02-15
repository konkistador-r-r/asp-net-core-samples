using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingletonPattern
{
    // Пусть вашим классом станет планета Земля. 
    // Думаю, никто не сомневается в том, что она должна быть реализована в единственном экземпляре.
    internal class Earth
    {
        private static Earth _instance;

        // Конструктор объявлен так, чтобы не исключать возможность наследования
        protected Earth() { }

        public static Earth Instance()
        {
            // Используем "ленивую" инициализацию
            if (_instance == null)
            {
                _instance = new Earth();
            }
            return _instance;
        }

        public void Hello()
        {
            Console.WriteLine("Hello from Earth");
        }
    }

    // Moon cant be inherited because of sealed modifier. It is unique
    internal sealed class Moon
    {
        private static readonly Lazy<Moon> lazy = new Lazy<Moon>(() => new Moon());

        public static Moon Instance { get { return lazy.Value; } }

        private Moon()
        {
        }

        public void Hello()
        {
            Console.WriteLine("Hello from Moon");
        }
    }
}
