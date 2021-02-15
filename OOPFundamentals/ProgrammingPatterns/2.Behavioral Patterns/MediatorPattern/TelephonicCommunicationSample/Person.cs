using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    /// <summary>
    /// Declares members for Crier.
    /// </summary>
    internal interface IPerson
    {
        void Listen(string message, Person source);
        void Say(string message);
    }

    /// <summary>
    /// Sends and receives messages via the passed Crier.
    /// 
    /// Acts as 'Colleague' within mediator pattern.
    /// </summary>
    internal class Person : IPerson
    {
        public string Name { get; }
        public Crier Crier { get; }

        public Person(string name, Crier crier)
        {
            Crier = crier;
            // Listen method subscribes to MessageReceived event handler.
            Crier.MessageReceived += Listen;

            Name = name;
        }

        /// <summary>
        /// Receives a message from source Person.
        /// </summary>
        /// <param name="message">Message received.</param>
        /// <param name="source">Person who sent the message.</param>
        public void Listen(string message, Person source)
        {
            // If source is self, ignore.
            if (source == this) return;

            // Output received message.
            Console.WriteLine($"{source} to {this}: '{message}'");
        }

        /// <summary>
        /// Sends passed message to all subscribed Persons via Crier.
        /// </summary>
        /// <param name="message">Message to be sent.</param>
        public void Say(string message)
        {
            Crier.Shout(message, this);
        }

        /// <summary>
        /// Overrides ToString() method.
        /// </summary>
        /// <returns>Name property value.</returns>
        public override string ToString() => Name;
    }
}
