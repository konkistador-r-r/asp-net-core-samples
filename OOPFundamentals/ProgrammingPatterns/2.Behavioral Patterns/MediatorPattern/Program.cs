using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Обеспечивает взаимодействие множества объектов без необходимости ссылаться друг на друга
// Когда имеется множество взаимосвязаных объектов, связи между которыми сложны и запутаны.
// Когда необходимо повторно использовать объект, однако повторное использование затруднено в силу сильных связей с другими объектами.

// a mediator object encapsulates how other types of objects interact, without the need for those objects to be aware the implementation of other objects.
// Mediator – Coordinates communication between all colleague objects.
// Colleague – through an associated mediator object, Sends message to and receives messages from other colleagues.
// Client – Creates colleagues and associates an appropriate mediator with each.
namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            //SoftwareTeamSample.Test();

            TelephonicCommunicationSample.Test();
        }
    }
}
