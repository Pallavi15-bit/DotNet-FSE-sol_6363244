using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI_5.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet("token")]
        public IActionResult GetToken()
        {
            var token = GenerateJSONWebToken(1, "Admin");
            return Ok(new { token });
        }

        private string GenerateJSONWebToken(int userId, string userRole)
        {
            string securityKey = "mysuperdupersecretkeymysuperdupersecretkey"; // 32+ chars
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); 
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); 

            var claims = new[]
            {
                new Claim(ClaimTypes.Role, userRole),
                new Claim("UserId", userId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "mySystem",
                audience: "myUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
