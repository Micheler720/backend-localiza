using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using Domains.Interfaces;
using Entities;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace Infra.Authentication
{
    public class Authentication : IToken
    {
        public string TokenGenerate(User user)
        {
                var tokenHandler = new JwtSecurityTokenHandler();
				JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory,"appsettings.json")));
				var key = Encoding.ASCII.GetBytes(jAppSettings["JwtToken"].ToString());
				var expirationTime = Convert.ToInt32(jAppSettings["ExpirationTime"]);
                var claimName = user.UserRole.ToString() == "Operator" ? user.Registration : user.Cpf;
				var tokenDescriptor = new SecurityTokenDescriptor()
				{
					Subject = new ClaimsIdentity(new Claim[]{
						new Claim(ClaimTypes.Name, claimName),
						new Claim(ClaimTypes.Role, user.UserRole.ToString()),
					}),
					Expires = DateTime.UtcNow.AddHours(expirationTime),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
				};
				var token = tokenHandler.CreateToken(tokenDescriptor);
				return tokenHandler.WriteToken(token);
        }
    }
}