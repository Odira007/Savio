using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SavioApi.Dto.User.Requests
{
    public class UserLoginDto
    {
        [Required]
         public String? EmailOrPhoneNumber { get; set; }
         [Required]
        public String? Password { get; set; }
        
    }
}