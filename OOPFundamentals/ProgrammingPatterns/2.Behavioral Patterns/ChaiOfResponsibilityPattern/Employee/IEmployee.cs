using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaiOfResponsibilityPattern
{
    /// <summary>
    /// Basic employee interface.
    /// 
    /// Acts as the Handler in Chain of Responsibility.
    /// </summary>
    /// <typeparam name="T">Type of object employee will be dealing with.</typeparam>
    public interface IEmployee<T>
    {
        void PublishBook(T book);
        void SetSpecification(ISpecification<T> specification);
        void SetSuccessor(IEmployee<T> employee);
    }
}
