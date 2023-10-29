using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavioApi.Dto.Account.Requests;
using SavioApi.Models;
using SavioApi.Models.Data;

namespace SavioApi.Dependencies.Interfaces
{
    public interface IAccountService
    {
        Task<UserAccount> CreateAccount(CreateAccountDto dto);
        Task<List<UserAccount>> GetUserAccounts(Guid UserId);
        Task<UserAccount> UpdateAccountBalance(Guid AccountId,double Amount);
        Task<UserAccount> GetAccountByAccountId(Guid Id);
        Task<UserAccount> GetAccountByAccountNumber(GetAccountDto dto);
        Task<UserAccount>  UpdateAccount(Guid Id,UpdateAccountDto dto);
        Task<UserAccount>  DisableAccount(Guid Id);
        Task<bool> DeleteAccount(Guid Id);

        
    }
}