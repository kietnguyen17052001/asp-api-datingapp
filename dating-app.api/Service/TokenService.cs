using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace dating_app.api.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string createToken(string username)
        {
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.NameId, username),
                new Claim(JwtRegisteredClaimNames.Email, $"{username}@dev.com")
            };
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    symmetricKey, SecurityAlgorithms.HmacSha512Signature
                )
            };
            var tokenHanlder = new JwtSecurityTokenHandler();
            var token = tokenHanlder.CreateToken(tokenDescriptor);
            return tokenHanlder.WriteToken(token);
        }
    }
}