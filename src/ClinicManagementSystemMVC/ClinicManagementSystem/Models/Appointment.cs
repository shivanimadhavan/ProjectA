using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public int PatientID { get; set; }
        public string Specializationrequired { get; set; }
        //[ForeignKey("DName")]
        public string DFirstName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Visitdate { get; set; }
        [DataType(DataType.Time)]
        public DateTime AppoinmentTime { get; set; }
    }
}
