using Microsoft.AspNetCore.Mvc;
using SavioApi.Dependencies.Interfaces;
using SavioApi.Dto.Account.Requests;
using SavioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SavioApi.Dto.Account.Response;
using CodeCommApi.Dependencies;
using CodeCommApi.Response;

namespace SavioApi.Controllers
{
    [Route("api/Accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        private readonly IMapper _mapper;
        private AutoResponse<ReadAccountDto> x=new();

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _service = accountService;
            _mapper = mapper;
        }

        [HttpPost("CreateAccount")]
        public async Task<ActionResult<DefaultResponse<ReadAccountDto>>> CreateAccount(
            [FromBody] CreateAccountDto dto
        )
        {
            try
            {
                var newAccount = await _service.CreateAccount(dto);

                if (newAccount != null)
                {

                    var accountDto = _mapper.Map<ReadAccountDto>(newAccount);
                    var response = x.ConvertToGood("ACCOUNT CREATED SUCCESSFULLY");
                    response.Data = accountDto;
                    return StatusCode(201, response); // 201 Created
                }
                return BadRequest(x.ConvertToBad("UNABLE TO CREATE ACCOUNT"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, x.ConvertToBad($"AN ERROR OCCURED : {ex.Message}"));
            }
        }

        [HttpGet("GetUserAccounts/{UserId}")]
        public async Task<ActionResult<DefaultResponse<List<ReadAccountDto>>>> GetUserAccounts(Guid UserId)
        {
            try
            {
                var userAccounts = await _service.GetUserAccounts(UserId);

                if (userAccounts != null && userAccounts.Any())
                {
                    var x = new AutoResponse<List<ReadAccountDto>>();
                    var accountDtos = _mapper.Map<List<ReadAccountDto>>(userAccounts);
                    var response = x.ConvertToGood("ACCOUNTS FETCHED SUCCESSFULLY");
                    response.Data = accountDtos;
                    return Ok(response);
                }
                return NotFound(x.ConvertToBad("USER HAS NO ACCOUNTS"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, x.ConvertToBad($"AN ERROR OCCURED : {ex.Message}"));
            }
        }

        [HttpGet("GetAccountById/{accountId}")]
        public async Task<ActionResult<DefaultResponse<ReadAccountDto>>> GetAccountById([FromRoute] Guid accountId)
        {
            try
            {
                var account = await _service.GetAccountByAccountId(accountId);

                if (account != null)
                {
                    var accountDto = _mapper.Map<ReadAccountDto>(account);
                    var response = x.ConvertToGood("ACCOUNT FETCHED SUCCESSFULLY");
                    response.Data = accountDto;
                    return Ok(response);
                }
                return NotFound(x.ConvertToBad("ACCOUNT NOT FOUND"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, x.ConvertToBad($"AN ERROR OCCURED : {ex.Message}"));
            }
        }

        [HttpPut("UpdateAccount/{accountId}")]
        public async Task<ActionResult<DefaultResponse<ReadAccountDto>>> UpdateAccount(
            [FromRoute] Guid accountId,
            [FromBody] UpdateAccountDto updateAccountDto
        )
        {
            try
            {
                var updatedAccount = await _service.UpdateAccount(accountId, updateAccountDto);

                if (updatedAccount != null)
                {
                    var accountDto = _mapper.Map<ReadAccountDto>(updatedAccount);
                    var response = x.ConvertToGood("ACCOUNT UPDATED SUCCESSFULLY");
                    response.Data = accountDto;
                    return Ok(response);
                }
                return BadRequest("UPDATE FAILED");
            }
            catch (Exception ex)
            {
                return StatusCode(500, x.ConvertToBad($"AN ERROR OCCURED : {ex.Message}"));
            }
        }

        [HttpPatch("DisableAccount/{accountId}")]
        public async Task<ActionResult<DefaultResponse<ReadAccountDto>>> DisableAccount([FromRoute] Guid accountId)
        {
            try
            {
                var disabledAccount = await _service.DisableAccount(accountId);

                if (disabledAccount != null)
                {
                    var accountDto = _mapper.Map<ReadAccountDto>(disabledAccount);
                    var response = x.ConvertToGood("ACCOUNT DISABLED SUCCESSFULLY");
                    response.Data = accountDto;
                    return Ok(response);
                }
                return BadRequest(x.ConvertToBad("UNABLE DO DISABLE ACCOUNT"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, x.ConvertToBad($"AN ERROR OCCURED : {ex.Message}"));
            }
        }

        [HttpDelete("DeleteAccount/{accountId}")]
        public async Task<ActionResult<DefaultResponse<bool>>> DeleteAccount([FromRoute]Guid accountId)
        {
            try
            {
                var deletionResult = await _service.DeleteAccount(accountId);

                if (deletionResult)
                {
                    return NoContent(); // 204 No Content
                }
                return BadRequest(x.ConvertToBad("UNABLE TO DELETE ACCOUNT"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, x.ConvertToBad($"AN ERROR OCCURED : {ex.Message}"));
            }
        }
    }
}
