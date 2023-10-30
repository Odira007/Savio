using Savio.Client.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Savio.Client.Models
{
    public class Transaction
    {
        public UserAccount Account { get; set; }
        public DateTime TransactionTime { get; set; }
        public DateTime? TransactionUpdatedAt { get; set; }
        public TransactionType TransactionType { get; set; }

        public Guid ReceivingAccount { get; set; }
        public double TransactionAmount { get; set; }
    }
}
