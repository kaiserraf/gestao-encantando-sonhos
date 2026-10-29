using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GesApi.src.Utils.UtilsInterfaces;
using Microsoft.IdentityModel.Tokens;

namespace GesApi.src.Utils {
    public class AuthenticateUser : IAuthenticateUser {

        private readonly IConfiguration _config;
        public AuthenticateUser(IConfiguration config) {
            _config = config;
        }

        public async Task<string> CreateToken(long id, int profileTypeId, int addHours) {
            var claims = new[] {
                new Claim("id", id.ToString()),
                new Claim("profileTypeId", profileTypeId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(addHours),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}