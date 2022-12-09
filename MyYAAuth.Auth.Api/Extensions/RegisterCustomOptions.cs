using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyYAAuth.Auth.Api.Services;
using MyYAAuth.Auth.Common;

namespace MyYAAuth.Auth.Api.Infrastructure
{
    public static class RegisterCustomOptionsExtension
    {
        public static void RegisterCustomOptions(this IServiceCollection collection, ConfigurationManager configuration)
        {

            //результат одинаковый
            // variant_1 var authOptionsConfiguration = configuration.GetSection("Auth").Get<AuthOptions>();
            // variant_2 var authOptionsConfiguration = Configuration.GetSection("Auth");
            // services.Configure<AuthOptions>(authOptionsConfiguration);

            var authOptionsConfigurations = configuration.GetSection("Auth");
            collection.Configure<AuthOptions>(authOptionsConfigurations);
        }
    }
}