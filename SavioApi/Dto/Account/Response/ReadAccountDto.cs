using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavioApi.Models;
using SavioApi.Models.Categories;
using SavioApi.Models.Categories.SavioApi.Models.Categories;
using SavioApi.Models.Data;

namespace SavioApi.Dto.Account.Response
{
    public class ReadAccountDto
    {
        
        public Guid AccountId { get; set; }
        public String AccountNumber { get; set; }
        public double AccountBalance { get; set; }
        public Bank BankName { get; set; }
        public Guid UserId { get; set; }
        public Users AccountUser { get; set; }
        public AccountType AccountType { get; set; }
        public AccountStatus AccountStatus { get; set; } 
        public List<Users>? AccountBeneficiaries { get; set; }
        public DateTime AccountCreatedAt { get; set; } 


       
    
    }
}