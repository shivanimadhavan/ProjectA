using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Models
{
    public class ClinicContext:DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        { }
        public DbSet<Registration> RegisterTable { get; set; }
        public DbSet<UserLogin> LoginTable { get; set; }
    }
}
