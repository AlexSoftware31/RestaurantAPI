using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantWebAPI.Helpers
{
    public class JwtHelper
    {
        public static byte[] GetKey()
        {
            var key = Encoding.UTF8.GetBytes("fe648f434ee50f2bd9038c73edbb59e326e50fa71ea7625c544f5b20dfdf1f76b76b9f5ea27e41a554188d887436c314b28330342eaf384991a8673866ff03fc3b6d6e192766a3e50743d5d70a9016115d82a502b41bbb8b3d3b3944a4652f5214bc139d3e78981761cc9c5a8614afb5950e6cb254b646e791b07f57c99c0391");

            return key;
        }

        public static string GenerateJwtToken(string username)
        {
            var key = GetKey();
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, "Admin")
            };

            var token = new JwtSecurityToken(
                issuer: "http://localhost:5014",
                audience: "http://localhost:5014",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
