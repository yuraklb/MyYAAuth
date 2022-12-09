using Microsoft.AspNetCore.Authorization;

namespace MyYAAuth.Resource.Api.Requirements.Permission
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public Permission[] Permissions { get; set; }

        public PermissionRequirement(Permission[] permissions)
        {
            Permissions = permissions;
        }
    }
}