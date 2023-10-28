using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SavioApi.Dto.User.Requests;
using SavioApi.Dto.User.Response;

namespace SavioApi.Models.Profiles
{
    public class SavioProfiles:Profile
    {
        public SavioProfiles()
        {
            //USER
         CreateMap<CreateUserDto,User>();
         CreateMap<UpdateUserDto,User>();
         CreateMap<User,ReadUserDto>();

         

            
        }
    }
}