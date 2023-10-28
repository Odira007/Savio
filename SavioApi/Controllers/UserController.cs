using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SavioApi.Dependencies.Interfaces;
using SavioApi.Dto.User.Requests;
using SavioApi.Models;

namespace SavioApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserDto dto)
        {
            var user = await _userService.CreateUser(dto);
            if (user == null)
            {
                return BadRequest("User creation failed or user already exists.");
            }
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var result = await _userService.DeleteUser(id);
            if (!result)
            {
                return NotFound("User not found or deletion failed.");
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var user = await _userService.FindUser(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            if (users == null || users.Count == 0)
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(Guid id, [FromBody] UpdateUserDto dto)
        {
            var user = await _userService.UpdateUser(id, dto);
            if (user == null)
            {
                return NotFound("User not found or update failed.");
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> UserLogin([FromBody] UserLoginDto dto)
        {
            var user = await _userService.UserLogin(dto);
            if (user == null)
            {
                return Unauthorized("Invalid credentials or user not found.");
            }
            return Ok(user);
        }
    }
}
