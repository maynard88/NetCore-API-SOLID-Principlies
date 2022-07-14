using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FinTech.Core.FTEntities;

namespace FinTech.EntityFrameworkCore.EntityFrameworkCore
{
    public class FinTechDbContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<EmployeeTemperature> Temperature { get; set; }


        public FinTechDbContext(DbContextOptions<FinTechDbContext> options)
            : base(options)
        { 
        
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


          
        }
    }
}
