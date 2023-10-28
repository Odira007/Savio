using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavioApi.Models.Categories.SavioApi.Models.Categories;

namespace SavioApi.Dto.Account.Requests
{
    public class GetAccountDto
    {
        public String AccountNumber { get; set; }
        public Bank BankName { get; set; }
    }
}