using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class AppDbContext : DbContext
    { // DbContextOptions is used when making creating
        //an instance within DbContext.
        public AppDbContext(DbContextOptions<AppDbContext> options)
            // Passing options to base DbContext Class.
            : base(options)
        {

        }

        // Property used to query and hold Employee from DbSet.
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeds Db with Employee, HasData() used to speciy seed data.
            modelBuilder.Entity<Employee>().HasData(
                // New Instance.
                new Employee
                {
                    Id = 1,
                    Name = "Aaron",
                    Department = Dept.IT,
                    Email = "Aaron@Gmail.com",
                },
                 new Employee
                 {
                     Id = 2,
                     Name = "Dustin",
                     Department = Dept.IT,
                     Email = "Dustin@Gmail.com",
                 },
                  new Employee
                  {
                      Id = 3,
                      Name = "Jake",
                      Department = Dept.IT,
                      Email = "Jake@Gmail.com",
                  },
                   new Employee
                   {
                       Id = 4,
                       Name = "Patrick",
                       Department = Dept.IT,
                       Email = "Patrick@Gmail.com",
                   }
                );
        }
    }
}
