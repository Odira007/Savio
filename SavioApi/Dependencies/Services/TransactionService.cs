using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SavioApi.Data;
using SavioApi.Dependencies.Interfaces;
using SavioApi.Dto.Account.Requests;
using SavioApi.Dto.Transactions;
using SavioApi.Dto.Transactions.Requests;
using SavioApi.Models.Categories;
using SavioApi.Models.Categories.SavioApi.Models.Categories;
using SavioApi.Models.Data;
using SavioApi.Response;

namespace SavioApi.Dependencies.Services
{
    public class TransactionService:ITransactionService
    {
         private readonly SavioDbContext _context; 
        private readonly IMapper _mapper;

        private IUserService _user;
        private IAccountService _account;
        AutoTransactionResponse<Transaction> x=new();

        public TransactionService(SavioDbContext context,IAccountService account,IMapper mapper,IUserService user)
        {
            _context = context;
            _account=account;
            _user=user;
            _mapper=mapper;
        }
          public async Task<TransactionResponse<Transaction>> SendMoney(CreateTransactionDto dto)
        {
            
            var transaction=_mapper.Map<Transaction>(dto);
            GetAccountDto accountDto=new(){
            AccountNumber=dto.TransactionReceiver,
            BankName=dto.BankName};
            var receivingAccount=await _account.GetAccountByAccountNumber(accountDto);
            var sendingaccount=await _account.GetAccountByAccountId(dto.AccountId);
            // var receivingAccount=await _account.GetAccountByAccountId(dto.TransactionReceiver);
            if(sendingaccount==null||receivingAccount==null){
                return x.Failed("INVALID TRANSACTION");
            }
           if(receivingAccount==null){
            return x.Failed("RECEIVING ACCOUNT NOT FOUND");
           }
           var balance=sendingaccount.AccountBalance;
           if(balance<dto.TransactionAmount){
            return x.Declined("INSUFFICIENT ACCOUNT BALANCE");
           }
           await _account.UpdateAccountBalance(dto.AccountId,balance-dto.TransactionAmount);
           await _account.UpdateAccountBalance(receivingAccount.AccountId,receivingAccount.AccountBalance+dto.TransactionAmount);
           transaction.Account=sendingaccount;
           transaction.TransactionTime=DateTime.Now;
           transaction.ReceivingAccount=receivingAccount.AccountId;
           transaction.TransactionType=TransactionType.Debit;
           var response=x.Approved("TRANSFER SUCCESSFUL");
           response.Data=transaction;
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return response;
            
        }

        public Task<TransactionResponse<Transaction>> ApproveTransaction(Guid TransactionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionResponse<Transaction>>> GetAccountTransactions(Guid AccountId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionResponse<Transaction>>> GetAllBankTransactions(Bank bank)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionResponse<Transaction>>> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionResponse<Transaction>>> GetUserTransactions(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponse<Transaction>> RejectTransaction(Guid TransactionId)
        {
            throw new NotImplementedException();
        }

      

        public Task<TransactionResponse<Transaction>> UpdateTransaction(Guid TransactionId, UpdateTransactionDto dto)
        {
            throw new NotImplementedException();
        }
    }
}