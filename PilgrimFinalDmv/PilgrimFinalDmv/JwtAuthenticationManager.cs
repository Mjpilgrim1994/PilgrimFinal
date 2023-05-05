using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace PilgrimFinalDmv
{
    public class JwtAuthenticationManager
    {
        private readonly string key;

        private readonly IDictionary<string, string> users = new Dictionary<string, string>()
        {{"testdmv", "pass"}, {"testlaw", "pass"}, {"test", "test" }};

        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }

        public string Authenticate(string username, string password)
        {
            if(!users.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }

            JwtSecurityTokenHandler Handler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(key);

            SecurityTokenDescriptor tokener = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var Token = Handler.CreateToken(tokener);

            return Handler.WriteToken(Token);
        }
    }
}
