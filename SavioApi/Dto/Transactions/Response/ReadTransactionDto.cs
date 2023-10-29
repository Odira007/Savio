using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavioApi.Models.Data;
using SavioApi.Models.Categories;

namespace SavioApi.Dto.Transactions.Responses
{
    public class ReadTransactionDto
    {

        public Guid TransactionId { get; set; } 
        public Guid AccountId { get; set; }
        public UserAccount TransactionAccount { get; set; }
        public DateTime TransactionTime { get; set; }
        public TransactionType TransactionType { get; set; }
        public Guid TransactionSender { get; set; }
        public Users Sender {get;set;}
        public Guid TransactionReceiver { get; set; }
        public Users Receiver { get; set; }
        public double TransactionAmount { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
    }
}