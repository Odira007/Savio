using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavioApi.Models.Categories;

namespace SavioApi.Dto.Transactions.Requests
{
    public class UpdateTransactionDto
    {


        public Guid AccountId { get; set; }

       



        public double TransactionAmount { get; set; }
        public TransactionStatus TransactionStatus { get; set; }=TransactionStatus.Pending;
        
    }
}