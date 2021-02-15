using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaiOfResponsibilityPattern
{
    /// <summary>
    /// Employee class used to create basic chain of responsibility.
    /// 
    /// Acts as the ConcreteHandler in Chain of Responsibility.
    /// </summary>
    /// <typeparam name="T">Type of object employee will be dealing with.</typeparam>
    public class Employee<T> : IEmployee<T> where T : class, IPublishable
    {
        private IEmployee<T> _successor;
        private readonly string _name;
        private ISpecification<T> _specification;
        private readonly Action<T> _publicationAction;
        private readonly Position _position;

        public Employee(string name, Position position, Action<T> publicationAction)
        {
            _name = name;
            _position = position;
            _publicationAction = publicationAction;
        }

        /// <summary>
        /// Check if Employee can approve book for publication by checking
        /// if current specification is satisfied by book.
        /// </summary>
        /// <param name="book">Book to check for approval.</param>
        /// <returns>Indicates if Employee can approve book or not.</returns>
        public bool CanApprove(T book)
        {
            if (_specification != null && book != null)
            {
                return _specification.IsSatisfiedBy(book);
            }
            return false;
        }

        /// <summary>
        /// Attempts to publish book.
        /// </summary>
        /// <param name="book">Book to attempt publication upon.</param>
        public void PublishBook(T book)
        {
            // Check if Employee has rights to approve publication.
            if (CanApprove(book))
            {
                // Ensure position isn't Default (which indicates no employees in chain can approve).
                if (_position != Position.Default)
                {
                    Console.WriteLine($"{_position} {_name} approved publication of {book}.");
                }
                // Invoke passed action to publish book.
                _publicationAction.Invoke(book);
                Console.WriteLine("-----");
            }
            else
            {
                // If unable to approve, check if successor and try to publish book as successor.
                _successor?.PublishBook(book);
            }
        }

        public void SetSpecification(ISpecification<T> specification)
        {
            _specification = specification;
        }

        public void SetSuccessor(IEmployee<T> employee)
        {
            _successor = employee;
        }
    }
}
