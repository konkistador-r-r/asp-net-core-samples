using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.CheckAccessChain
{
    // he Handler declares the interface, common for all concrete handlers. 
    // It usually contains just a single method for handling requests, 
    // but sometimes it may also have another method for setting the next handler on the chain.
    public interface IAccessHandler
    {
        IAccessHandler SetNext(IAccessHandler handler);

        AccessResult Handle(AccessResult request);
    }
}
