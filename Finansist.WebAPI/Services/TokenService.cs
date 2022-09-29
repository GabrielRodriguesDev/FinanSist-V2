using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Finansist.Domain.Models.ValueObjects;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Finansist.WebAPI.Services
{
    public class TokenService
    {

        private static ClaimsIdentity ConfigureClaimsAndRoles(Autenticado autenticado)
        {
            return new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, autenticado.Nome),
                new Claim(ClaimTypes.Email, autenticado.Email),
                new Claim("id", autenticado.Id.ToString()),
                new Claim(ClaimTypes.Role, autenticado.Perfil.ToString()),
        });
        }

        public static string GenerateJwtToken(HttpContext httpContext, Autenticado autenticado)
        {
            var service = httpContext.RequestServices.GetRequiredService<IConfiguration>();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(service["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = ConfigureClaimsAndRoles(autenticado),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = service["Jwt:Issuer"],
                Audience = service["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public bool? ValidateJwtToken(HttpContext httpContext, string token)
        {
            var service = httpContext.RequestServices.GetRequiredService<IConfiguration>();
            var tokenHandler = new JsonWebTokenHandler();
            var key = Encoding.ASCII.GetBytes(service["Jwt:key"]);

            var result = tokenHandler.ValidateToken(token, new TokenValidationParameters()
            {
                ValidIssuer = service["Jwt:Issuer"],
                ValidateIssuer = true,
                ValidAudience = service["Jwt:Audience"],
                ValidateAudience = true,
                ValidateLifetime = true,
                LifetimeValidator = LifetimeValidator,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
            });

            return result.IsValid ? true : false;

        }

        public bool LifetimeValidator(DateTime? notBefore,
        DateTime? expires,
        SecurityToken securityToken,
        TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }
}
