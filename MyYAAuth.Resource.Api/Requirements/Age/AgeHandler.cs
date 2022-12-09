using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MyYAAuth.Resource.Api.Requirements.Age
{
    public class AgeHandler : AuthorizationHandler<AgeRequirement>
    {
        public AgeHandler()
        {
            // fooService будет передан через DI 
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeRequirement requirement)
        {
            /*
            bool hasClaim = context.User.HasClaim(c => c.Type == "age");
            bool hasIdentity = context.User.Identities.Any(i => i.AuthenticationType == "MultiPass");
            string claimValue = context.User.FindFirst(c => c.Type == "age").Value;

            if (int.Parse(claimValue) >= requirement.Age)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
            */
            
            //metanit


            Console.WriteLine("AgeHandler");
            
              if (context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                var year = 0;
                if(Int32.TryParse(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value, out year))
                {
                    if ((DateTime.Now.Year - year) >= requirement.Age)
                    {
                        context.Succeed(requirement);
                    }
                }
            }
            return Task.CompletedTask;
            
        }
    }
}