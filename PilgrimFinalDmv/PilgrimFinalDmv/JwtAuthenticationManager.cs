using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace PilgrimFinalDmv
{
    public class JwtAuthenticationManager
    {
        private readonly string dmvkey;
        private readonly string lawkey;

        private readonly IDictionary<string, string> dmvusers = new Dictionary<string, string>()
        {{"testdmv", "pass"}};

        private readonly IDictionary<string, string> lawusers = new Dictionary<string, string>()
        {{"testlaw", "pass"}};

        public JwtAuthenticationManager(string key)
        {
            this.dmvkey = dmvkey;
            this.lawkey = lawkey;
        }

        public string AuthenticateDMV(string username, string password)
        {
            if(!dmvusers.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }

            JwtSecurityTokenHandler dmvHandler = new JwtSecurityTokenHandler();
            var dmvKey = Encoding.ASCII.GetBytes(dmvkey);

            SecurityTokenDescriptor tokener = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(dmvKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var dmvToken = dmvHandler.CreateToken(tokener);

            return dmvHandler.WriteToken(dmvToken);
        }
        public string AuthenticateLAW(string username, string password)
        {
            if (!lawusers.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }

            JwtSecurityTokenHandler lawHandler = new JwtSecurityTokenHandler();
            var lawKey = Encoding.ASCII.GetBytes(lawkey);

            SecurityTokenDescriptor tokener = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(lawKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var lawToken = lawHandler.CreateToken(tokener);

            return lawHandler.WriteToken(lawToken);
        }
    }
}
