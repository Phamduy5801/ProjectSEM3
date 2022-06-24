using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectTestSem3_Server
{
    public class Auth : IAuth
    {
        public string key { get; set; }
        public Auth(string key)
        {
            this.key = key;
        }
        public string Authentication(string username, string password)
        {
            var issuer = "SomeIssuer";
            var audience = "SomeAudience";
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials
        (securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer,
            audience: audience,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
