using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SavioApi.Dto.User.Requests
{
    public class CreateUserDto
    {
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        [EmailAddress]
        public String? Email { get; set; }
        public String? PhoneNumber { get; set; }
        public String ProfilePicture { get; set; }
        public String Password { get; set; }
        [Compare("Password")]
        public String ConfirmPassword { get; set; }
        public String? BVN { get; set; }
    }
}