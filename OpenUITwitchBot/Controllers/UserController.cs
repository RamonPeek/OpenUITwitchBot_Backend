using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Combined;
using Services.Interfaces;

namespace OpenUITwitchBot.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserService UserService { get; set; }

        private IAuthService AuthService { get; set; }

        public UserController(IUserService userService, IAuthService authService)
        {
            UserService = userService;
            AuthService = authService;
        }

        [HttpPost("")]
        public IActionResult Create(UserWithCredentials userWithCredentials)
        {
            User userResult = UserService.Create(userWithCredentials.User, userWithCredentials.Credentials);
            if (userResult == null)
                return BadRequest();
            bool credentialsResult = AuthService.CreateCredentials(userWithCredentials.Credentials);
            if (credentialsResult == false)
                return BadRequest();
            return Ok(userResult);
        }

        [HttpGet("")]
        public IActionResult GetById(string userId)
        {
            User userResult = UserService.GetById(userId);
            if (userResult == null)
                return NotFound();
            return Ok(userResult);
        }

        [HttpPut("")]
        public IActionResult Update(string userId, User user)
        {
            User userResult = UserService.Update(userId, user);
            if (userResult == null)
                return BadRequest();
            return Ok(userResult);
        }

        [HttpDelete("")]
        public IActionResult Delete(string userId)
        {
            User userResult = UserService.GetById(userId);
            if (userResult == null)
                return BadRequest();
            Credentials credentials = AuthService.GetByUserId(userId);
            if (credentials == null)
                return BadRequest();
            bool credentialsResult = AuthService.DeleteCredentials(credentials);
            if (credentialsResult == false)
                return BadRequest();
            return Ok(userResult);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            List<User> usersResult = UserService.GetAll();
            return Ok(usersResult);
        }

    }
}