using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using SavioApi.Models.Categories.SavioApi.Models.Transactions;

namespace SavioApi.Models
{
    public class Transaction
    {
        [Key]
        public Guid TransactionId { get; set; }

        
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public DateTime TransactionTime { get; set; }
        public TransactionType TransactionType { get; set; }
        public Guid TransactionSender { get; set; }
        public Guid TransactionReceiver { get; set; }
        public double TransactionAmount { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
    }
}
