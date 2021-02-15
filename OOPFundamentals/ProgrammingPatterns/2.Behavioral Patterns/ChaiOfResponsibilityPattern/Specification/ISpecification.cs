using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaiOfResponsibilityPattern
{
    /// <summary>
    /// Defines the specification pattern interface.
    /// </summary>
    /// <typeparam name="T">Type of object specification applies to.</typeparam>
    public interface ISpecification<in T>
    {
        /// <summary>
        /// Checks if current specification is satisfied by passed expression.
        /// </summary>
        /// <param name="expression">Expression to check.</param>
        /// <returns>Result.</returns>
        bool IsSatisfiedBy(T expression);
    }
}
