using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyYAAuth.Auth.Api.Services;

namespace MyYAAuth.Auth.Api.Infrastructure
{
    public static class RegisterCustomServicesExtension
    {
        public static void RegisterCustomServices(this IServiceCollection collection)
        {
            collection.AddScoped<IAccountsService, AccountsService>();
        }
    }
}