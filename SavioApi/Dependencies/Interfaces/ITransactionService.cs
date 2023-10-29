using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavioApi.Dto.Transactions;
using SavioApi.Dto.Transactions.Requests;
using SavioApi.Models;
using SavioApi.Models.Categories.SavioApi.Models.Categories;
using SavioApi.Models.Data;

namespace SavioApi.Dependencies.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> SendMoney(CreateTransactionDto dto);
        Task<List<Transaction>> GetAccountTransactions(Guid AccountId);
        Task<List<Transaction>> GetUserTransactions(Guid UserId);
        Task<List<Transaction>> GetAllBankTransactions(Bank bank);
        Task<List<Transaction>> GetAllTransactions();
        Task<Transaction> UpdateTransaction(Guid TransactionId,UpdateTransactionDto dto);
        Task<Transaction> ApproveTransaction(Guid TransactionId);
        Task<Transaction> RejectTransaction(Guid TransactionId);
    }
}