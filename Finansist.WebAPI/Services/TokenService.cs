using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Finansist.WebAPI.Services
{
    public class TokenService
    {

        private static ClaimsIdentity ConfigureClaimsAndRoles(Guid id, string nome, String email)
        {
            return new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, nome),
                new Claim(ClaimTypes.Email, email),
                new Claim("Id", id.ToString()),
                new Claim(ClaimTypes.Role, PerfilUsuarioEnum.Administrador.ToString())
        });
        }

        public static string GenerateJwtToken(HttpContext httpContext, Guid id, string nome, String email)
        {
            var service = httpContext.RequestServices.GetRequiredService<IConfiguration>();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(service["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = ConfigureClaimsAndRoles(id, nome, email),
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
