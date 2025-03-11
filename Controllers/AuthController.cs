using Edugo.StudentService.DTOs;
using Edugo.StudentService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Edugo.StudentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly IConfiguration _config;

        public AuthController(IStudentRepository repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var student = await _repository.GetByEmailAsync(dto.Email);
            if (student == null || student.Password != dto.Password)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, student.Name),
                new Claim(ClaimTypes.Role, student.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expires
            });
        }
    }
}
