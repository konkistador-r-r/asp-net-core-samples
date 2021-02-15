using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.CheckAccessChain
{
    public class AuthenticationHandler : AbstractAccessHandler
    {
        public override AccessResult Handle(AccessResult request)
        {
            if (CanGiveAccess(request.User.Name))
            {
                // pass execution to next handler
                return base.Handle(request);
            }
            else
            {
                request.Error = "Authentication was not passed" + " " + "User Name length equal or less than 3 symbols.";
                // stop execution
                return request;
            }
        }

        private bool CanGiveAccess(string user) {
            return user.Length >= 3;
        }
    }
}
