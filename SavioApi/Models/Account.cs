using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SavioApi.Models.Categories;
using SavioApi.Models.Categories.SavioApi.Models.Banks;

namespace SavioApi.Models
{
    [PrimaryKey("UserId", "AccountNumber")]
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }
        public String AccountNumber { get; set; }
        public double AccountBalance { get; set; }
        public Bank BankName { get; set; }

        [ForeignKey("AccountUser")]
        public Guid UserId { get; set; }
        public User AccountUser { get; set; }
        public AccountType AccountType { get; set; }
        public AccountStatus AccountStatus { get; set; } = AccountStatus.Active;
        public List<User>? AccountBeneficiaries { get; set; }
        public DateTime AccountCreatedAt { get; set; } = DateTime.Now;

        // public DateTime AccountRenewalDate { get; set; }   WILL LOVE TO ADD A FEATURE LIKE THIS LATER THO

        public DateTime AccountUpdatedAt { get; set; } = DateTime.MinValue;
    }
}
