using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MyYAAuth.Auth.Common
{
    public class AuthOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Secret { get; set; }

        public int TokenLifetime { get; set; } //seconds

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
        }
    }
}