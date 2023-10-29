using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SavioApi.Data;
using SavioApi.Dependencies.Interfaces;
using SavioApi.Dto.Account.Requests;
using SavioApi.Models.Categories;
using SavioApi.Models.Data;

namespace SavioApi.Dependencies.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly SavioDbContext _context;
        private IUserService _user;

        public AccountService(IMapper mapper, SavioDbContext context, IUserService user)
        {
            _context = context;
            _mapper = mapper;
            _user = user;
        }

        public async Task<UserAccount> CreateAccount(CreateAccountDto dto)
        {
            Users user = await _user.FindUser(dto.UserId);
            if (user == null)
            {
                return null;
            }
            UserAccount account = _mapper.Map<UserAccount>(dto);
            account.AccountId=Guid.NewGuid();
            account.AccountUser = user;
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<List<UserAccount>> GetUserAccounts(Guid UserId)
        {
            return await _context.Accounts.Where(a => a.UserId == UserId).ToListAsync();
        }

        public async Task<UserAccount> GetAccountByAccountId(Guid Id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x=>x.AccountId==Id);
        }

        public async Task<UserAccount> GetAccountByAccountNumber(GetAccountDto dto)
        {
            return await _context.Accounts.FirstOrDefaultAsync(
                a => a.AccountNumber == dto.AccountNumber && a.BankName == dto.BankName
            );
        }

        public async Task<UserAccount> UpdateAccount(Guid Id, UpdateAccountDto dto)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x=>x.AccountId==Id);
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

        public async Task<UserAccount> DisableAccount(Guid Id)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x=>x.AccountId==Id);
            if (account != null)
            {
                account.AccountStatus = AccountStatus.InActive; // Update the status accordingly
                await _context.SaveChangesAsync();
            }
            return account;
        }

        public async Task<bool> DeleteAccount(Guid Id)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x=>x.AccountId==Id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<UserAccount> UpdateAccountBalance(Guid AccountId, double Amount)
        {
           var account = await _context.Accounts.FirstOrDefaultAsync(x=>x.AccountId==AccountId);
            if (account != null)
            {
                account.AccountBalance =Amount;
                account.AccountUpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return account;
        }
    }
}
