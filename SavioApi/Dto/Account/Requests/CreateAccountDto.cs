using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavioApi.Models.Categories;
using SavioApi.Models.Categories.SavioApi.Models.Categories;

namespace SavioApi.Dto.Account.Requests
{
    public class CreateAccountDto
    {
  
        public String AccountNumber { get; set; }

        public Bank BankName { get; set; }


        public Guid UserId { get; set; }

        public AccountType AccountType { get; set; }
        public AccountStatus AccountStatus { get; set; } = AccountStatus.Active;



    }
}