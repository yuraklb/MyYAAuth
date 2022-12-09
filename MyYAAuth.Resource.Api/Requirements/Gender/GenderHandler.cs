using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MyYAAuth.Resource.Api.Requirements.Gender
{
    public class GenderHandler : AuthorizationHandler<GenderRequirement>
    {
        public GenderHandler()
        {
            // fooService будет передан через DI 
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GenderRequirement requirement)
        {
            Console.WriteLine("GenderHandler");
            
            if (context.User.HasClaim(c => c.Type == "gender"))
            {
                if (context.User.FindFirst(c => c.Type == "gender").Value == requirement.Gender)
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}