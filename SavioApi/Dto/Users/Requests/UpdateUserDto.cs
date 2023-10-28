using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SavioApi.Dto.User.Requests
{
    public class UpdateUserDto
    {
        [Required]
        public String? FirstName { get; set; }

        [Required]
        public String? LastName { get; set; }

        [Required]
        public String Email { get; set; }
        public String? ProfilePicture { get; set; }

        [Required]
        public String? PhoneNumber { get; set; }

        [Required]
        public String? Password { get; set; }

        [Compare("Password")]
        [Required]
        public String? ConfirmPassword { get; set; }
    }
}
