using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.CheckAccessChain
{
    public class AuthorizationHandler : AbstractAccessHandler
    {
        public override AccessResult Handle(AccessResult request)
        {
            if (CanGiveAccess(request.User.Roles))
            {
                // pass execution to next handler
                return base.Handle(request);
            }
            else
            {
                request.Error = "Authorization was not passed" + " " + "User is not in Roles Supporter or Admin.";
                // stop execution
                return request;
            }
        }

        private bool CanGiveAccess(List<string> roles)
        {
            return roles.Contains("Admin") || roles.Contains("Supporter");
        }
    }
}
