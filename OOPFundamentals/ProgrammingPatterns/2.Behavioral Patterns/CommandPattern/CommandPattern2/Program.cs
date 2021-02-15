using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern2
{
    // Commands are always in stack
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем пользователя.
            User user = new User();

            // Пусть он что-нибудь сделает.
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            // Отменяем 4 команды
            user.Undo(4);

            // Вернём 3 отменённые команды.
            user.Redo(3);
            Console.WriteLine();


            Pult pult = new Pult();
            TV tv = new TV();
            pult.SetCommand(new TVOnCommand(tv));
            pult.PressButton();
            pult.PressUndo();
            Console.WriteLine();

            Microwave microwave = new Microwave();
            // 5000 - время нагрева пищи
            pult.SetCommand(new MicrowaveCommand(microwave, 5000));
            pult.PressButton();
            Console.WriteLine();

            TV tv2 = new TV();
            Volume volume = new Volume();
            MultiPult mPult = new MultiPult();
            mPult.SetCommand(0, new TVOnCommand(tv2));
            mPult.SetCommand(1, new VolumeCommand(volume));
            // включаем телевизор
            mPult.PressButton(0); // указываем какую именно команду выполнять
            // увеличиваем громкость
            mPult.PressButton(1); // указываем какую именно команду выполнять
            mPult.PressButton(1); // указываем какую именно команду выполнять
            mPult.PressButton(1); // указываем какую именно команду выполнять
            // действия отмены
            mPult.PressUndoButton();
            mPult.PressUndoButton();
            mPult.PressUndoButton();
            mPult.PressUndoButton();

            // Ждем ввода пользователя и завершаемся.
            Console.Read();
        }
    }
}

