using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicManagementSystemMVC.Models;

namespace ClinicManagementSystemMVC.Models
{
    public class ClinicalDetailsContext : DbContext
    {
        public ClinicalDetailsContext(DbContextOptions<ClinicalDetailsContext> options) : base(options)
        { }
        public DbSet<Appointment> AppointmentTable { get; set; }
        public DbSet<DocDetails> DocTable { get; set; }
        public DbSet<PatientDetails> PatientTable { get; set; }
        public DbSet<Register> RegisterTable { get; set; }

        public DbSet<UserLogin> LoginTable { get; set; }
      
        
    }
}