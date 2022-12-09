using Microsoft.Extensions.DependencyInjection;
using MyYAAuth.Resource.Api.Models;

namespace MyYAAuth.Resource.Api.Extensions
{
    public static class RegisterCustomServicesExtension
    {
        public static void RegisterCustomServices(this IServiceCollection collection)
        {
            collection.AddScoped<IBookStoreService, BookStoreService>();
        }
    }
}