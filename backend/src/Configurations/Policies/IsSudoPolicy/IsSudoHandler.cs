using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace src.Configurations.Policies.IsSudoPolicy
{
    public class IsSudoHandler : AuthorizationHandler<IsSudoRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsSudoRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "Role" && c.Value.Contains("Sudo")))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}