using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Models
{
    public class FrontStaff
    {
        [Key]
        [Required]
        [RegularExpression(@"^(?=.[a-z])(?=.[A-Z])(?=.*\d).{8,15}$")]
        public string StaffUsername { get; set; }
        [Required]
       
        public string Password { get; set; }
    }
}
