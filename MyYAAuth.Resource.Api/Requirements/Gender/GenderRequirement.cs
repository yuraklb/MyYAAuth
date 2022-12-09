using Microsoft.AspNetCore.Authorization;

namespace MyYAAuth.Resource.Api.Requirements.Gender
{
    public class GenderRequirement : IAuthorizationRequirement
    {
        public GenderRequirement(string gender)
        {
            Gender = gender;
        }

        internal string Gender { get; set; }
    }
}