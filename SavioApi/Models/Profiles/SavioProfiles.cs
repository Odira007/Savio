using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SavioApi.Dto.Account.Requests;
using SavioApi.Dto.Account.Response;
using SavioApi.Dto.Transactions;
using SavioApi.Dto.Transactions.Responses;
using SavioApi.Dto.User.Requests;
using SavioApi.Dto.User.Response;
using SavioApi.Models.Data;

namespace SavioApi.Models.Profiles
{
    public class SavioProfiles:Profile
    {
        public SavioProfiles()
        {
            //USER
         CreateMap<CreateUserDto,Users>();
         CreateMap<UpdateUserDto,Users>();
         CreateMap<Users,ReadUserDto>();

         CreateMap<CreateAccountDto,UserAccount>();
         CreateMap<UpdateAccountDto,UserAccount>();
         CreateMap<UserAccount,ReadAccountDto>();

         CreateMap<CreateTransactionDto,Transaction>();
         CreateMap<Transaction,ReadTransactionDto>();

         

            
        }
    }
}