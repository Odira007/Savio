using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavioApi.Dto.User.Requests
{
    public class UpdateUserDto
    {
                public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? Email { get; set; }
        public String? PhoneNumber { get; set; }        
    }
}