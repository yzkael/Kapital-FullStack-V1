using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace src.Configurations.Policies.IsSudoPolicy
{
    public class IsSudoRequirement : IAuthorizationRequirement
    {
        public IsSudoRequirement()
        {
            IsSudo = true;
        }

        public bool IsSudo { get; }
    }
}