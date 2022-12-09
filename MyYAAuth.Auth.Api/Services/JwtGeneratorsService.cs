using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using MyYAAuth.Auth.Api.Models;
using MyYAAuth.Auth.Common;

namespace MyYAAuth.Auth.Api.Services
{
    public static class JwtGeneratorsService
    {
        public static string GenerateJWT(AuthOptions _authOptions, Account user)
        {

            /*
            {
              "email": "user@email.com",
              "sub": "e2d80add-3db9-465e-b00b-cc0be173d76a",
              "role": "User",
              "exp": 1668950442,
              "iss": "authServer",
              "aud": "resourceServer"
            }
            */


            var authParams = _authOptions;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>(){
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),


                //examples begin
                new Claim(ClaimTypes.Name, "User name here"),
                new Claim("age", "25", ClaimValueTypes.Integer),
                new Claim("gender", "female", ClaimValueTypes.String),
                new Claim("permission-foo", "grant"),
                new Claim(ClaimsIdentity.DefaultNameClaimType, "Default name here"),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "RolesAllow"),
                //examples end


            };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim("role", role.ToString()));
            }

            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
            claims,
            expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
            signingCredentials: credentials);

            var result = new JwtSecurityTokenHandler().WriteToken(token);

            return result;
        }

        public static string GenerateJWT2(AuthOptions _authOptions, Account user)
        {
            var authParams = _authOptions;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = authParams.Issuer,
                Audience = authParams.Audience,
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}