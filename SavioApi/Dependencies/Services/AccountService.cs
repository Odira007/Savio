using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SavioApi.Data;
using SavioApi.Dependencies.Interfaces;
using SavioApi.Dto.Account.Requests;
using SavioApi.Models;
using SavioApi.Models.Categories;

namespace SavioApi.Dependencies.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly SavioDbContext _context;

        public AccountService(IMapper mapper, SavioDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Account> CreateAccount(CreateAccountDto dto)
        {
            var account = _mapper.Map<Account>(dto);
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<List<Account>> GetUserAccounts(Guid UserId)
        {
            return await _context.Accounts.Where(a => a.UserId == UserId).ToListAsync();
        }

        public async Task<Account> GetAccountByAccountId(Guid Id)
        {
            return await _context.Accounts.FindAsync(Id);
        }

        public async Task<Account> GetAccountByAccountNumber(GetAccountDto dto)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == dto.AccountNumber && a.BankName == dto.BankName);
        }

        public async Task<Account> UpdateAccount(Guid Id, UpdateAccountDto dto)
        {
            var account = await _context.Accounts.FindAsync(Id);
            if (account != null)
            {
                account.AccountBalance = dto.AccountBalance;
                account.AccountType = dto.AccountType;
                account.AccountStatus = dto.AccountStatus;
                // Update other properties if needed
                account.AccountUpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return account;
        }

        public async Task<Account> DisableAccount(Guid Id)
        {
            var account = await _context.Accounts.FindAsync(Id);
            if (account != null)
            {
                account.AccountStatus = AccountStatus.InActive; // Update the status accordingly
                await _context.SaveChangesAsync();
            }
            return account;
        }

        public async Task<bool> DeleteAccount(Guid Id)
        {
            var account = await _context.Accounts.FindAsync(Id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
