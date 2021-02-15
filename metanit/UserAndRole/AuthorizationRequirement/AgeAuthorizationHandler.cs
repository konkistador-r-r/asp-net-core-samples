using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserAndRole.Models;

namespace UserAndRole.AuthorizationRequirement
{
    public class AgeAuthorizationHandler : AuthorizationHandler<AgeRequirement>
    {
        // Этот метод вызывается системой авторизации при доступе к ресурсу, к которому применяется ограничение, используемое обработчиком.
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth)) {
                var year = 0;
                if (Int32.TryParse(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value, out year))
                {
                    if ((DateTime.Now.Year - year) >= requirement.Age)
                    {
                        //  метод Fail(), если запрос не соответствует ограничению.
                        // Если метод Succeed не вызывается, то считается, что авторизация прошла неудачно.
                        context.Succeed(requirement);
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}
