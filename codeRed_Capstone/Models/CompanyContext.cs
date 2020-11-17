using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace codeRed_Capstone.Models
{
    public class CompanyContext : DbContext
    {

        public CompanyContext()
        {
        }
        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection =
                    "server=localhost;" +
                    "port=3306;" +
                    "user=root;" +
                    "database=codered_employeeDB_cf;";
                string version = "10.4.14-MariaDB";
                optionsBuilder.UseMySql(connection, x => x.ServerVersion(version));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.FirstName)
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.LastName)
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Email)
               .HasCharSet("utf8mb4")
               .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Phone)
               .HasCharSet("utf8mb4")
               .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.City)
               .HasCharSet("utf8mb4")
               .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Department)
               .HasCharSet("utf8mb4")
               .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Email).HasDefaultValue("info@company.ca");

                entity.HasData(
                    new Employee()
                    {
                        ID = -1,
                        FirstName = "John",
                        LastName = "Smith",
                        Email = "jsmith@company.ca",
                        Phone = "(780)111-2222",
                        Age = 30,
                        City = "Edmonton",
                        Department = "IT"
                       // CreatedAt = new DateTime (GetUtcDate())
                    },
                    new Employee()
                    {
                        ID = -2,
                        FirstName = "Adam",
                        LastName = "Johnson",
                        Email = "ajohnson@company.ca",
                        Phone = "(780)222-3333",
                        Age = 31,
                        City = "Edmonton",
                        Department = "Sales"
                       // CreatedAt = new DateTime(2018 - 05 - 11T13: 01:16.7610000 + 05:30)
                    },
                    new Employee()
                    {
                        ID = -3,
                        FirstName = "Kyle",
                        LastName = "Sandler",
                        Email = "ksandler@company.ca",
                        Phone = "(780)333-4444",
                        Age = 29,
                        City = "Calgary",
                        Department = "Sales"
                      //  CreatedAt = new DateTime(2018 - 05 - 11T13: 01:16.7610000 + 05:30)
                    },
                    new Employee()
                    {
                        ID = -4,
                        FirstName = "Jessica",
                        LastName = "Alba",
                        Email = "jalba@company.ca",
                        Phone = "(403)444-5555",
                        Age = 25,
                        City = "Calgary",
                        Department = "Accounting"
                      //  CreatedAt = new DateTime(2018 - 05 - 11T13: 01:16.7610000 + 05:30)
                    },
                    new Employee()
                    {
                        ID = -5,
                        FirstName = "Kate",
                        LastName = "Moss",
                        Email = "kmoss@company.ca",
                        Phone = "(780)678-9876",
                        Age = 30,
                        City = "Banff",
                        Department = "CEO"
                      //  CreatedAt = new DateTime(2018 - 05 - 11T13: 01:16.7610000 + 05:30)
                    }
                );
            });    
        }
    }
}
