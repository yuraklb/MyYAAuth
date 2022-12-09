using System;
using Microsoft.AspNetCore.Mvc;

namespace MyYAAuth.Resource.Api.Requirements.Permission
{
    public class AuthorizePermissionAttribute : TypeFilterAttribute
    {
        public AuthorizePermissionAttribute(params Permission[] permissions)
            : base(typeof(PermissionFilter))
        {
            Arguments = new[] { new PermissionRequirement(permissions) };
            Order = Int32.MaxValue;
        }
    }
}