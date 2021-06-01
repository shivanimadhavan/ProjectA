using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public int PatientID { get; set; }
        public ASpecializationRequired SpecializationRequired { get; set; }
        public List<DocDetails> DoctorName { get; set; }

        [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid date format.")]
        public string VisitDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime VisitTime { get; set; }
    }
    public enum ASpecializationRequired
    {
        General, Gynaecologist, Pediatrics, Orthopedics, Ophthalmology
    }
}