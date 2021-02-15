using System;
using System.Collections.Generic;
using System.Text;
using ChainOfResponsibility.CheckAccessChain;

namespace ChainOfResponsibility
{
    public class CheckAccessChainClient
    {
        public static AbstractAccessHandler SetUpChain() {
            var authentication = new AuthenticationHandler();
            var authorization = new AuthorizationHandler();

            authentication.SetNext(authorization);

            return authentication;
        }

        // The client code is usually suited to work with a single handler. In
        // most cases, it is not even aware that the handler is part of a chain.
        public static void ClientCode(AbstractAccessHandler handler)
        {
            foreach (var user in new List<User> { 
                new User { Name = "vasya", Roles = new List<string>{ "User" } }, 
                new User { Name = "petya", Roles = new List<string>{ "Supporter" } },
                new User { Name = "kolya", Roles = new List<string>{ "Admin" } }
            })
            {
                Console.WriteLine($"Users: Who wants an access {user.Name}?");
               
                var accessInfo = handler.Handle(new AccessResult { User = user });

                if (string.IsNullOrEmpty(accessInfo.Error))
                {
                    Console.WriteLine($"Access to Ordering System - granted.\n");
                }
                else
                {
                    Console.WriteLine($"{accessInfo.Error}.\n");
                }
            }
        }
    }
}
