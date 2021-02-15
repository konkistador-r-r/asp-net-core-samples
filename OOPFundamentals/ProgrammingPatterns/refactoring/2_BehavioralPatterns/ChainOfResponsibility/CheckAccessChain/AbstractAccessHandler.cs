using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.CheckAccessChain
{
    // The Base Handler is an optional class where you can put the boilerplate code that’s common to all handler classes.
    public abstract class AbstractAccessHandler : IAccessHandler
    {
        // Usually, this class defines a field for storing a reference to the next handler.
        private IAccessHandler _nextHandler;

        // The clients can build a chain by passing a handler to the constructor or setter of the previous handler. 
        public IAccessHandler SetNext(IAccessHandler handler)
        {
            this._nextHandler = handler;

            // Returning a handler from here will let us link handlers in a convenient way like this:
            // monkey.SetNext(squirrel).SetNext(dog);
            return handler;
        }

        // The class may also implement the default handling behavior: 
        // it can pass execution to the next handler after checking for its existence.
        public virtual AccessResult Handle(AccessResult request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return request;
            }
        }
    }
}
