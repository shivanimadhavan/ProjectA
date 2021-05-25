using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomePageDetails.Models
{
    public class UserLogin
    {[Key]
        //[Required(ErrorMessage = "Enter Username")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "special characters are not allowed.")]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"^(?=.[a-z])(?=.[A-Z])(?=.*\d).{8,15}$")]

        public string Password { get; set; }
    }
}
