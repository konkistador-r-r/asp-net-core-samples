using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    abstract class Mediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }

    abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    class CustomerColleague : Colleague
    {
        public CustomerColleague(Mediator mediator)
            : base(mediator)
        { }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine(string.Format("Сообщение Заказчику: {0}", message));
        }
    }
    class ProgrammerColleague : Colleague
    {
        public ProgrammerColleague(Mediator mediator)
            : base(mediator)
        { }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine(string.Format("Сообщение Программисту: {0}", message));
        }
    }
    class TesterColleague : Colleague
    {
        public TesterColleague(Mediator mediator)
            : base(mediator)
        { }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine(string.Format("Сообщение Тестеровщику: {0}", message));
        }
    }

    class ManagerMediator : Mediator
    {
        public CustomerColleague Customer { get; set; }
        public ProgrammerColleague Programmer { get; set; }
        public TesterColleague Tester { get; set; }
        public override void Send(string msg, Colleague colleague)
        {
            if (Customer == colleague)
                Programmer.Notify(msg);
            else if (Programmer == colleague)
                Tester.Notify(msg);
            else
                Customer.Notify(msg);
        }
    }

    public class SoftwareTeamSample
    {
        public static void Test() {
            Console.WriteLine(string.Format("----- {0} -----", "SoftwareTeamSample"));

            ManagerMediator mediator = new ManagerMediator();
            var customer = new CustomerColleague(mediator);
            var programmer = new ProgrammerColleague(mediator);
            var tester = new TesterColleague(mediator);
            mediator.Customer = customer;
            mediator.Programmer = programmer;
            mediator.Tester = tester;
            customer.Send("Есть заказ, надо сделать программу");
            programmer.Send("Программа готова, надо протестировать");
            tester.Send("Программа протестирована и готова к продаже");

            Console.ReadLine();
        }
    }
}
