using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_dash.Models
{
    public class User
    {
        public long Id { get; set; }
        
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Needs to be in correct email format")]
        public string Email { get; set; }

        [Required]
        [RegularExpression (@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{5,14}", ErrorMessage="Does not meet password Criteria")]
        public string Password { get; set; }

    }
}
