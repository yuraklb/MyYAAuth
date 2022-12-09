using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyYAAuth.Auth.Common;

namespace MyYAAuth.Resource.Api.Extensions
{
    public static class RegisterCustomOptionsExtension
    {
        public static void RegisterCustomOptions(this IServiceCollection collection, ConfigurationManager configuration)
        {
            var authOptionsConfigurations = configuration.GetSection("Auth");
            collection.Configure<AuthOptions>(authOptionsConfigurations);
        }
    }
}