using GlobalInsightsTribuneApi.Controllers;
using GlobalInsightsTribuneApi.Entitys;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GlobalInsightsTribuneApi.Services
{
    public static class TokenService
    {
        private static readonly IConfiguration? _configuration;

        public static string GenerateToken(User user) 
        { 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key  = Encoding.ASCII.GetBytes(_configuration.GetConnectionString("SecretAuth"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject =new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
             };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
