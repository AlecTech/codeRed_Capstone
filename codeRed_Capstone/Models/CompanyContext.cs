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
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeDate> EmployeeDates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection =
                    "server=localhost;" +
                    "port=3306;" +
                    "user=root;" +
                    "database=codered_employeeExtraDB_cf;";
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
                     
                    }
                );
            });


            modelBuilder.Entity<EmployeeDate>(entity =>
            {            
                entity.Property(e => e.ModifiedDate).ValueGeneratedOnAdd();

                //entity.Property(e => e.FiredDate).HasDefaultValue();

                entity.HasIndex(e => e.EmployeeID)
                 .HasName("FK_" + nameof(EmployeeDate) + "_" + nameof(Employee));

                entity.HasOne(child => child.Employee)
                  .WithMany(parent => parent.EmployeeDates)
                  .HasForeignKey(child => child.EmployeeID)
           
                  // Restrict: Throw an exception if we try to orphan a child record.
                  // Cascade: Remove any child records that would be orphaned by a removed parent.
                
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK_" + nameof(EmployeeDate) + "_" + nameof(Employee));

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("NOW()");

                entity.HasData(
                    new EmployeeDate()
                    {
                        ID = -1,
                        EmployeeID = -1,
                        HiredDate = new DateTime(2020, 01, 01),
                        FiredDate = null,
                        ModifiedDate = new DateTime()
                        // CreatedAt = new DateTime (GetUtcDate())
                    },
                    new EmployeeDate()
                    {
                        ID = -2,
                        EmployeeID = -2,
                        HiredDate = new DateTime(2020, 02, 02),
                        FiredDate = new DateTime(2020, 05, 05),
                        ModifiedDate = new DateTime()
                    },
                    new EmployeeDate()
                    {
                        ID = -3,
                        EmployeeID = -3,
                        HiredDate = new DateTime(2020, 04, 04),
                        FiredDate = null,
                        ModifiedDate = new DateTime()
                    },
                    new EmployeeDate()
                    {
                        ID = -4,
                        EmployeeID = -4,
                        HiredDate = new DateTime(2020, 06, 06),
                        FiredDate = null,
                        ModifiedDate = new DateTime()
                    },
                    new EmployeeDate()
                    {
                        ID = -5,
                        EmployeeID = -5,
                        HiredDate = new DateTime(2020, 07, 07),
                        FiredDate = null,
                        ModifiedDate = new DateTime()
                    }
                );
            });


        }
    }
}
