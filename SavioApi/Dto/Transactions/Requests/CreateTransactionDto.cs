using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavioApi.Models.Categories;
using SavioApi.Models.Categories.SavioApi.Models.Categories;
namespace SavioApi.Dto.Transactions
{
    public class CreateTransactionDto
    {

        public Guid AccountId { get; set; }
        // public TransactionType TransactionType { get; set; }
        // public Guid TransactionReceiver { get; set; }
        public String TransactionReceiver { get; set; }
        public Bank BankName { get; set; }
        public double TransactionAmount { get; set; }
        
    }
}