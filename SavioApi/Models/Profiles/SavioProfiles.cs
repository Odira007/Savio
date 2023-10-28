using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SavioApi.Dto.Account.Requests;
using SavioApi.Dto.Account.Response;
using SavioApi.Dto.User.Requests;
using SavioApi.Dto.User.Response;

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

         CreateMap<CreateUserDto,Account>();
         CreateMap<UpdateAccountDto,Account>();
         CreateMap<Account,ReadAccountDto>();

        //  CreateMap<CreateUserDto,Users>();
        //  CreateMap<UpdateUserDto,Users>();
        //  CreateMap<Users,ReadUserDto>();

         

            
        }
    }
}