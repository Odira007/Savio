using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavioApi.Models.Categories;
namespace SavioApi.Dto.Transactions
{
    public class CreateTransactionDto
    {

        public Guid AccountId { get; set; }
        public TransactionType TransactionType { get; set; }
        public Guid TransactionSender { get; set; }
        public Guid TransactionReceiver { get; set; }
        public double TransactionAmount { get; set; }
        
    }
}