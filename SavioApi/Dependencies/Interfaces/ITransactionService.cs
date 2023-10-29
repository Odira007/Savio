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
        Task<List<TransactionResponse<Transaction>>> GetAccountTransactions(Guid AccountId);
        Task<List<TransactionResponse<Transaction>>> GetUserTransactions(Guid UserId);
        Task<List<TransactionResponse<Transaction>>> GetAllBankTransactions(Bank bank);
        Task<List<TransactionResponse<Transaction>>> GetAllTransactions();
        Task<TransactionResponse<Transaction>> UpdateTransaction(Guid TransactionId,UpdateTransactionDto dto);
        Task<TransactionResponse<Transaction>> ApproveTransaction(Guid TransactionId);
        Task<TransactionResponse<Transaction>> RejectTransaction(Guid TransactionId);
    }
}