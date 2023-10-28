using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavioApi.Models.Categories;
using SavioApi.Models;

namespace SavioApi.Dto.Account.Requests
{
    public class UpdateAccountDto
    {
        public double AccountBalance { get; set; }=0.00;
        public AccountType AccountType { get; set; }
        public AccountStatus AccountStatus { get; set; } = AccountStatus.Active;
        public List<Guid> AccountBeneficiaries { get; set; }
        // public DateTime AccountRenewalDate { get; set; }   WILL LOVE TO ADD A FEATURE LIKE THIS LATER THO

        // public DateTime AccountUpdatedAt { get; set; } = DateTime.Now;//STILL LOOKING AT THIS
        
    }
}