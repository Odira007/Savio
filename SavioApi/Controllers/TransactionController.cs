using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeCommApi.Dependencies;
using Microsoft.AspNetCore.Mvc;
using SavioApi.Dependencies.Interfaces;
using SavioApi.Dto.Transactions;
using SavioApi.Models.Categories;
using SavioApi.Models.Data;
using SavioApi.Response;

namespace SavioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;
        private readonly IMapper _mapper;
        
        public TransactionController(IMapper mapper,ITransactionService service)
        {
            _service = service;
            _mapper=mapper;
            
        }
        
        [HttpPost("SendMoney")]
        public async Task<ActionResult<TransactionResponse<Transaction>>> SendMoney(CreateTransactionDto dto){
            AutoResponse<Transaction>x=new();
            try{
                var transaction=await _service.SendMoney(dto);
                if(transaction.Status==TransactionStatus.Failed||transaction.Status==TransactionStatus.Declined){
                    return BadRequest(transaction.ResponseMessage);
                }
                return Ok(transaction);
            }
            catch(Exception ex){
                return StatusCode(500,x.ConvertToBad($"{ex.Message}"));
            }
        }
    }
}