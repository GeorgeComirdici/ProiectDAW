using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ProiectDAW.Models;
using System.Security.Claims;

namespace ProiectDAW.Helpers
{
    public class Jwt
    {
        private string _secureKey = "TokenulMeuSecretGeorgeComirdici";
        public string CreateToken(int IdAngajat)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secureKey));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credential);
            var payload = new JwtPayload(IdAngajat.ToString(),null,null,null,DateTime.Now.AddDays(1));
            var token = new JwtSecurityToken(header, payload); 
       
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public JwtSecurityToken Verificare(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secureKey);
            tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            },out SecurityToken securityToken);
            return (JwtSecurityToken)securityToken;
        }
    }
}
