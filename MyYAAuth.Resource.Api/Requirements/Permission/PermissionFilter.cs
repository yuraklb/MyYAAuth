using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyYAAuth.Resource.Api.Requirements.Permission
{
    public class PermissionFilter : Attribute, IAsyncAuthorizationFilter
    {
        private readonly IAuthorizationService _authService;
        private readonly Permission[] _permissions;

        public PermissionFilter(IAuthorizationService authService, Permission[] permissions)
        {
            _authService = authService;
            _permissions = permissions;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var r = await _authService.AuthorizeAsync(context.HttpContext.User, null, new PermissionRequirement(_permissions));

            bool ok = r.Succeeded;

            if (!ok) context.Result = new ChallengeResult();
        }
    }
}