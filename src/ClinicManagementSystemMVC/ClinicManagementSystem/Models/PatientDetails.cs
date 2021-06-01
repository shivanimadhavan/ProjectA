using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Models
{
    public class PatientDetails
    {
        [Key]
        public int PatientID { get; set; }
        [Required]
        public string PFirstName { get; set; }
        public string PLastName { get; set; }
        public string Sex { get; set; }

        public int Age { get; set; }
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Birth Date is required.")]
        [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid date format.")]
        public string BirthDate { get; set; }
    }
}
