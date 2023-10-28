using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavioApi.Dto.Account.Requests;
using SavioApi.Models;

namespace SavioApi.Dependencies.Interfaces
{
    public interface IAccountService
    {
        Task<Account> CreateAccount(CreateAccountDto dto);
        Task<List<Account>> GetUserAccounts(Guid UserId);
        Task<Account> GetAccountByAccountId(Guid Id);
        Task<Account> GetAccountByAccountNumber(GetAccountDto dto);
        Task<Account>  UpdateAccount(Guid Id,UpdateAccountDto dto);
        Task<Account>  DisableAccount(Guid Id);
        Task<bool> DeleteAccount(Guid Id);

        
    }
}