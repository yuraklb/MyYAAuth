using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using MyAuth.UI.Requirements.ResourceOperation;

namespace MyAuth.UI.Requirements.Resource
{
    public class ResourceOperationHandler : AuthorizationHandler<OperationAuthorizationRequirement, ResourceObjectToAllow>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, ResourceObjectToAllow resource)
        {
            
            //get list of operation structure (from database or from claims (User object in context))

            //context.User.Identities.FirstOrDefault(i=>i.na) FindFirstValue("create-any-resource");
                
            var listAllowedOperations = new List<string>() {"Create", "Update"};
            var listAllowedUUID = new List<int>() {1, 2, 4, 5};
            
            //string operationName = requirement.Name;

            if (listAllowedUUID.Contains(resource.UUID) && listAllowedOperations.Contains(resource.OperationName))
            {
                // Проверка, имеет ли пользователь права на действия с заказом
                if(true) context.Succeed(requirement);    
            }
            
            return Task.CompletedTask;
        }
    }
}