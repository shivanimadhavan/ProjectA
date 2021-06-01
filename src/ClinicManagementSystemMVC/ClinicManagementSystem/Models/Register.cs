using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Models
{
    public class Register
    {
        [Key]
        //[Required(ErrorMessage = "Enter Username")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "special characters are not allowed.")]
        public string RUsername { get; set; }
        [Required]
        //[RegularExpression(@"^(?=.[a-z])(?=.[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }
        public string ConPassword { get; set; }
        public string Email { get; set; }
    }
}

    
