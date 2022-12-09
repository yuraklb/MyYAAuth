using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyAuth.UI.Requirements.Resource;
using MyYAAuth.Resource.Api.Requirements.Age;
using MyYAAuth.Resource.Api.Requirements.Gender;

namespace MyYAAuth.Resource.Api.Extensions
{
    public static class RegisterAuthorizationHandlersExtension
    {
        public static void RegisterAuthorizationHandlers(this IServiceCollection collection)
        {

            collection.AddTransient<IAuthorizationHandler, AgeHandler>();
            collection.AddTransient<IAuthorizationHandler, GenderHandler>();
            collection.AddTransient<IAuthorizationHandler, ResourceBasedHandler>();
            collection.AddTransient<IAuthorizationHandler, ResourceOperationHandler>();
        }
    }
}