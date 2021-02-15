using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaiOfResponsibilityPattern.Specification
{
    /// <summary>
    /// Extends Specification class with logical And, Or, and Not methods.
    /// </summary>
    public static class SpecificationExtensions
    {
        public static Specification<T> And<T>(this ISpecification<T> a, ISpecification<T> b)
        {
            if (a != null && b != null)
            {
                // Check if both a AND b satisfy expression.
                return new Specification<T>(expression => a.IsSatisfiedBy(expression) && b.IsSatisfiedBy(expression));
            }
            return null;
        }
        public static Specification<T> Or<T>(this ISpecification<T> a, ISpecification<T> b)
        {
            if (a != null && b != null)
            {
                // Check if either a OR b satisfy expression.
                return new Specification<T>(expression => a.IsSatisfiedBy(expression) || b.IsSatisfiedBy(expression));
            }
            return null;
        }
        public static Specification<T> Not<T>(this ISpecification<T> a)
        {
            // Check .
            return a != null ? new Specification<T>(expression => !a.IsSatisfiedBy(expression)) : null;
        }
    }
}
