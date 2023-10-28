using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SavioApi.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? Email { get; set; }
        public String? PhoneNumber { get; set; }
        public String? ProfilePicture { get; set; }


        public String? Password { get; set; }
        public String? BVN { get; set; }
    }
}
