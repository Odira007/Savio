using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CodeCommApi.Dependencies;
using CodeCommApi.Response;
using Microsoft.AspNetCore.Mvc;
using SavioApi.Dependencies.Interfaces;
using SavioApi.Dto.User.Requests;
using SavioApi.Dto.User.Response;
using SavioApi.Models;

namespace SavioApi.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<DefaultResponse<ReadUserDto>>> CreateUser(
            [FromBody] CreateUserDto dto
        )
        {
            var x = new AutoResponse<ReadUserDto>();
            try
            {
                var user = await _service.CreateUser(dto);
                if (user == null)
                {
                    return BadRequest(x.ConvertToBad("UNABLE TO CREATE USER"));
                }
                var userDto = _mapper.Map<ReadUserDto>(user);
                var response = x.ConvertToGood("USER CREATED SUCCESSFULLY");
                response.Data = userDto;

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, x.ConvertToBad($"{ex.Message}"));
            }
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<DefaultResponse<ReadUserDto>>> DeleteUser(Guid id)
        {
            var x = new AutoResponse<ReadUserDto>();
            try
            {
                var result = await _service.DeleteUser(id);
                if (!result)
                {
                    return BadRequest(x.ConvertToBad("USER NOT FOUND OR DELETION FAILED"));
                }

                return StatusCode(204, x.ConvertToGood("USER DELETED SUCCESSFULLY"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, x.ConvertToBad($"{ex.Message}"));
            }
        }

        [HttpGet("GetUserById/{UserId}")]
        public async Task<ActionResult<DefaultResponse<ReadUserDto>>> GetUserById(
            [FromRoute] Guid UserId
        )
        {
            var x = new AutoResponse<ReadUserDto>();
            try
            {
                var user = await _service.FindUser(UserId);
                if (user == null)
                {
                    return NotFound(x.ConvertToBad("USER NOT FOUND"));
                }
                var userDto = _mapper.Map<ReadUserDto>(user);
                var response = x.ConvertToGood("USER FOUND SUCCESSFULLY");
                response.Data = userDto;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, x.ConvertToBad($"{ex.Message}"));
            }
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<DefaultResponse<List<ReadUserDto>>>> GetUsers()
        {
            var x = new AutoResponse<List<ReadUserDto>>();

            try
            {
                var users = await _service.GetUsers();
                if (users == null || users.Count == 0)
                {
                    return NotFound(x.ConvertToBad("USERS NOT FOUND"));
                }
                var usersDto = users.Select(x => _mapper.Map<ReadUserDto>(x)).ToList();
                var response = x.ConvertToGood("USERS FOUND SUCCESSFULLY");
                response.Data = usersDto;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, x.ConvertToBad($"{ex.Message}"));
            }
        }

        [HttpPut("UpdateUser/{USerId}")]
        public async Task<ActionResult<DefaultResponse<ReadUserDto>>> UpdateUser(
            [FromRoute] Guid UserId,
            [FromBody] UpdateUserDto dto
        )
        {
            var x = new AutoResponse<ReadUserDto>();

            try
            {
                var user = await _service.UpdateUser(UserId, dto);
                if (user == null)
                {
                    return BadRequest(x.ConvertToBad("UPDATE FAILED, USER NOT FOUND"));
                }
                var userDto = _mapper.Map<ReadUserDto>(user);
                var response = x.ConvertToGood("USER UPDATED SUCCESSUFULLY");
                response.Data = userDto;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, x.ConvertToBad($"{ex.Message}"));
            }
        }

        [HttpPost("UserLogin")]
        public async Task<ActionResult<DefaultResponse<ReadUserDto>>> UserLogin(
            [FromBody] UserLoginDto dto
        )
        {
            var x = new AutoResponse<ReadUserDto>();
            try
            {
                var user = await _service.UserLogin(dto);
                if (user == null)
                {
                    return Unauthorized(x.ConvertToBad("LOGIN FAILED"));
                }
                var userDto = _mapper.Map<ReadUserDto>(user);
                var response = x.ConvertToGood("LOGIN SUCCESSFULL");
                response.Data = userDto;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, x.ConvertToBad($"{ex.Message}"));
            }
        }
    }
}
