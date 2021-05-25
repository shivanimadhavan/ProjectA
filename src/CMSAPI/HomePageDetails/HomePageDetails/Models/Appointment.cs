using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace HomePageDetails.Models
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
