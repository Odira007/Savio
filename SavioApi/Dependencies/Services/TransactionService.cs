using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class TransactionService : ITransactionService
    {
        private readonly SavioDbContext _context;
        private readonly IMapper _mapper;

        private IUserService _user;
        private IAccountService _account;
        AutoTransactionResponse<Transaction> x = new();

        public TransactionService(
            SavioDbContext context,
            IAccountService account,
            IMapper mapper,
            IUserService user
        )
        {
            _context = context;
            _account = account;
            _user = user;
            _mapper = mapper;
        }

        public async Task<TransactionResponse<Transaction>> SendMoney(CreateTransactionDto dto)
        {
            var transaction = _mapper.Map<Transaction>(dto);

            GetAccountDto accountDto =
                new()
                {
                    AccountNumber = dto.TransactionReceiverAccountNumber,
                    BankName = dto.BankName
                };
            var receivingAccount = await _account.GetAccountByAccountNumber(accountDto);
            var sendingaccount = await _account.GetAccountByAccountId(dto.AccountId);
            // var receivingAccount=await _account.GetAccountByAccountId(dto.TransactionReceiver);
            if (sendingaccount == null || receivingAccount == null)
            {
                if (receivingAccount == null)
                {
                    return x.Failed("RECEIVING ACCOUNT NOT FOUND");
                }

                var senderErrorInfo =
                    (sendingaccount != null) ? sendingaccount.AccountId : dto.AccountId;

                return x.Failed(
                    $"INVALID TRANSACTION : INCORRECT USER DETAILS || Sender: {senderErrorInfo} | Reciever: {receivingAccount.AccountId}"
                );
            }
            if (dto.BankName != receivingAccount.BankName)
            {
                x.Failed("INVALID BANK OR ACCOUNT NOT FOUND IN THIS BANK");
            }

            transaction.Account = sendingaccount;
            transaction.TransactionTime = DateTime.Now;
            transaction.TransactionUpdatedAt = DateTime.MinValue;
            transaction.TransactionStatus = TransactionStatus.Pending;
            transaction.TransactionType = TransactionType.Debit;
            transaction.ReceivingAccount = receivingAccount.AccountId;
            await _context.Transactions.AddAsync(transaction);
            var balance = sendingaccount.AccountBalance;
            if (await ApproveTransaction(transaction.TransactionId, dto.TransactionAmount))
            {
                await _account.UpdateAccountBalance(dto.AccountId, balance - dto.TransactionAmount);
                await _account.UpdateAccountBalance(
                    receivingAccount.AccountId,
                    receivingAccount.AccountBalance + dto.TransactionAmount
                );

                transaction.Account = sendingaccount;
                transaction.TransactionTime = DateTime.Now;
                transaction.TransactionStatus = TransactionStatus.Successful;
                transaction.ReceivingAccount = receivingAccount.AccountId;
                transaction.TransactionType = TransactionType.Debit;
                var response = x.Approved("TRANSFER SUCCESSFUL");
                response.Data = transaction;
                return response;
            }
            await _context.SaveChangesAsync();

            return x.Declined("TRANSACTION ERROR: INSUFFICIENT ACCOUNT BALANCE ");

            // await _context.Transactions.AddAsync(transaction);
        }

        public async Task<bool> ApproveTransaction(Guid TransactionId, double Amount)
        {
            var transaction = await _context.Transactions.FindAsync(TransactionId);
            if (transaction == null)
            {
                return false;
            }
            var accBal = transaction.Account.AccountBalance;
            if (Amount >= accBal)
            {
                return false;
            }
            return true;

            //  await _account.UpdateAccountBalance(dto.AccountId, balance - dto.TransactionAmount);
            // await _account.UpdateAccountBalance(
            //     receivingAccount.AccountId,
            //     receivingAccount.AccountBalance + dto.TransactionAmount
            // );
            // throw new NotImplementedException();
        }

        public async Task<List<Transaction>> GetAccountTransactions(Guid AccountId)
        {
            var transactions = await _context.Transactions
                .Where(t => t.AccountId == AccountId)
                .ToListAsync();
            // throw new NotImplementedException();
            if (transactions == null)
            {
                return null;
            }
            return transactions;
        }

        public async Task<List<Transaction>> GetAllBankTransactions(Bank bank)
        {
            return await _context.Transactions.Where(t => t.Account.BankName == bank).ToListAsync();

            //    throw new NotImplementedException();
        }

        public async Task<List<Transaction>> GetAllTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<List<Transaction>> GetUserTransactions(Guid UserId)
        {
            return await _context.Transactions.Where(t => t.Account.UserId == UserId).ToListAsync();
            // throw new NotImplementedException();
        }

        public Task<bool> RejectTransaction(Guid TransactionId)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponse<Transaction>> UpdateTransaction(
            Guid TransactionId,
            UpdateTransactionDto dto
        )
        {
            throw new NotImplementedException();
        }
    }
}
