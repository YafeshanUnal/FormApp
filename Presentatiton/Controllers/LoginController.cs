using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MyProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DatabaseContext _context;

        public LoginController(IConfiguration config, DatabaseContext context)
        {
            _context = context;
            _configuration = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Kullanıcı adı ve şifrenin doğruluğunu kontrol edin
            var user = _context.Users.FirstOrDefault(
                x => x.Username == login.Username && x.Password == login.Password
            );
            if (user == null)
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı!");
            }

            // Token için gerekli ayarları yapın
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:Key"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[] { new Claim(ClaimTypes.Name, user.Username) }
                ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            // Token oluşturun ve response olarak döndürün
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(tokenHandler.WriteToken(token));
        }

        [HttpGet("check")]
        public IActionResult Check()
        {
            var token = HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()
                ?.Split(" ")
                .Last();
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Token bulunamadı.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:Key"));
            try
            {
                // Token'ın doğruluğunu kontrol edin
                tokenHandler.ValidateToken(
                    token,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    },
                    out var validatedToken
                );

                // Token doğru ise kullanıcı bilgilerini döndürün
                var jwtToken = (JwtSecurityToken)validatedToken;
                var username = jwtToken.Claims.First(x => x.Type == ClaimTypes.Name).Value;
                return Ok($"Hoş geldiniz {username}!");
            }
            catch (Exception)
            {
                return BadRequest("Geçersiz token.");
            }
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
