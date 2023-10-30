using Savio.Client.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Savio.Client.Models
{
    public class UserAccount
    {
        public String AccountNumber { get; set; }
        public double AccountBalance { get; set; } = 0.00;
        public Bank BankName { get; set; }
        public AccountType AccountType { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public DateTime AccountCreatedAt { get; set; } = DateTime.Now;
    }
}
