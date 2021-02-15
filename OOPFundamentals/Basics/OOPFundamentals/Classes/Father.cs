using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OOPFundamentals.Interfaces;

namespace OOPFundamentals.Classes
{
    delegate void Feeding(); 

    class Father : Human, IWork // Inheritance, Interfaces
    {
        private Feeding _startFeed;
        public event Feeding StartFeed
        {
            add
            {
                Console.Write("Father going to feed \n");
                _startFeed += value;
            }
            remove
            {
                _startFeed -= value;
            }
        }
        
        public Father(string name, int age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.Hsex = sex;
            Busy = false;
        }

        public bool Busy { get; set; }

        public void Work()
        {
            Console.WriteLine("Father work in factory");
        }

        public override void Go() // ? why not private or protected // Polymorphism
        {
            Console.WriteLine(Name + "идет притопывая!");
        }
        
        public void Feed()
        {
            OnStartFeed();
            //Тут процесс кормления
        }

        // оборачиваем в виртуальный метод, чтобы возможные потомки могли переопределить метод, а процесс работы с событием не изменился
        protected virtual void OnStartFeed()
        {
            if (_startFeed != null)
                _startFeed();
        }
    }
}
