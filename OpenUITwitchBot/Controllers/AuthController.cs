using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using Services.Interfaces;

namespace OpenUITwitchBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IConfiguration Configuration;

        private IAuthService AuthService { get; set; }
        private IUserService UserService { get; set; }

        public AuthController(IConfiguration configuration, IAuthService authService, IUserService userService)
        {
            Configuration = configuration;
            AuthService = authService;
            UserService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate(Credentials credentials)
        {
            //Hash the password
            String userId = AuthService.Authenticate(credentials);
            User user = UserService.GetById(userId);
            if (user == null)
                return Unauthorized();
            return Ok(new { token = GenerateJSONWebToken(user) });
        }

        [HttpPost("validate")]
        public IActionResult validateSession()
        {
            ClaimsIdentity identity = User.Identity as ClaimsIdentity;
            string userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized("Your session has expired.");
            return Ok(userId);
        }

        private string GenerateJSONWebToken(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT_SECRET"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(ClaimTypes.Name, user.Id));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            JwtSecurityToken token = new JwtSecurityToken(
                Configuration["VUE_APP_ROOT"],
                Configuration["VUE_APP_ROOT"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}