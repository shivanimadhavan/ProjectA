using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Models
{
    public class UserLogin
    {
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^(?=.[a-z])(?=.[A-Z])(?=.*\d).{8,15}$")]

        public string Password { get; set; }
    }
}
