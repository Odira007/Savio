using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavioApi.Dto.Transactions;
using SavioApi.Dto.Transactions.Requests;
using SavioApi.Models;
using SavioApi.Models.Categories.SavioApi.Models.Categories;
using SavioApi.Models.Data;
using SavioApi.Response;

namespace SavioApi.Dependencies.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionResponse<Transaction>> SendMoney(CreateTransactionDto dto);
        Task<List<Transaction>> GetAccountTransactions(Guid AccountId);
        Task<List<Transaction>> GetUserTransactions(Guid UserId);
        Task<List<Transaction>> GetAllBankTransactions(Bank bank);
        Task<List<Transaction>> GetAllTransactions();
        Task<TransactionResponse<Transaction>> UpdateTransaction(Guid TransactionId,UpdateTransactionDto dto);
        Task<bool> ApproveTransaction(Guid TransactionId,double Amount);
        Task<bool> RejectTransaction(Guid TransactionId);
    }
}