using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace MyAuth.UI.Requirements.Resource
{
    public class ResourceBasedHandler : AuthorizationHandler<ResourceBasedRequirement, int>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceBasedRequirement requirement, int resource)
        {
            if (resource == 1)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}