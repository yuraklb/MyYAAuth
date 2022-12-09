using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MyYAAuth.Resource.Api.Requirements.Permission
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            //TODO: ваш код проверки, есть ли у пользователя права на эти операции
            if (requirement.Permissions.Any()) 
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
            
        }
    }
}