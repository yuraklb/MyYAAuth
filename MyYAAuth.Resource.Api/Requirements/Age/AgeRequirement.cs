using Microsoft.AspNetCore.Authorization;

namespace MyYAAuth.Resource.Api.Requirements.Age 
{
    public class AgeRequirement : IAuthorizationRequirement
    {
        public AgeRequirement(int age)
        {
            Age = age;
        }

        internal int Age { get; set; }
    }
}