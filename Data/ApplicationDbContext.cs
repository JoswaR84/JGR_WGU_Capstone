using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using JGR_WGU_Capstone.Models;

namespace JGR_WGU_Capstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<JGR_WGU_Capstone.Models.Computer> Computer { get; set; }
        public DbSet<JGR_WGU_Capstone.Models.Maintenance> Maintenance { get; set; }
    }
}
