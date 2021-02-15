using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    static class BankSample
    {
        public static void Test() {
            Stock stock = new Stock(); // Observable
            Bank bank = new Bank("ЮнитБанк", stock);
            Broker broker = new Broker("Иван Иваныч", stock);

            Console.WriteLine("Day 1");
            // имитация торгов
            stock.Market();
            // брокер прекращает наблюдать за торгами
            broker.StopTrade();
            Console.WriteLine();

            Console.WriteLine("Day 2");
            // имитация торгов
            stock.Market();
            Console.WriteLine();

            Console.WriteLine("Day 3");
            // брокер снова наблюдает за торгами
            broker.StartTrade(stock);
            // имитация торгов
            stock.Market();
            Console.WriteLine();
        }

        #region Observable

        interface IObservable
        {
            void RegisterObserver(IObserver o);
            void RemoveObserver(IObserver o);
            void NotifyObservers();
        }

        class StockInfo
        {
            public int USD { get; set; }
            public int Euro { get; set; }
        }

        class Stock : IObservable
        {
            StockInfo sInfo; // информация о торгах

            List<IObserver> observers;
            public Stock()
            {
                observers = new List<IObserver>();
                sInfo = new StockInfo();
            }
            public void RegisterObserver(IObserver o)
            {
                observers.Add(o);
            }

            public void RemoveObserver(IObserver o)
            {
                observers.Remove(o);
            }

            public void NotifyObservers()
            {
                foreach (IObserver o in observers)
                {
                    o.Update(sInfo);
                }
            }

            public void Market()
            {
                Random rnd = new Random();
                sInfo.USD = rnd.Next(20, 40);
                sInfo.Euro = rnd.Next(30, 50);
                NotifyObservers();
            }
        }

        #endregion

        #region Observer

        interface IObserver
        {
            void Update(Object ob);
        }

        class Broker : IObserver
        {
            public string Name { get; set; }
            IObservable stock;
            public Broker(string name, IObservable obs) // Observer deside to observe or not for it target
            {
                this.Name = name;
                StartTrade(obs);
            }
            public void Update(object ob)
            {
                StockInfo sInfo = (StockInfo)ob;

                if (sInfo.USD > 30)
                    Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
                else
                    Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
            }
            public void StartTrade(IObservable obs)
            {
                stock = obs;
                stock.RegisterObserver(this);
            }
            public void StopTrade()
            {
                stock.RemoveObserver(this); // Observer deside to observe or not for it target
                stock = null;
            }
        }

        class Bank : IObserver
        {
            public string Name { get; set; }
            IObservable stock;
            public Bank(string name, IObservable obs)
            {
                this.Name = name;
                stock = obs;
                stock.RegisterObserver(this);
            }
            public void Update(object ob)
            {
                StockInfo sInfo = (StockInfo)ob;

                if (sInfo.Euro > 40)
                    Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
                else
                    Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
            }
        }

        #endregion
    }
}
