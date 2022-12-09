using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace MyAuth.UI.Requirements
{
    public class ResourceBasedRequirement : IAuthorizationRequirement
    {
        public ResourceBasedRequirement()
        {
        }
    }
}