﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using codeRed_Capstone.Models;

namespace codeRed_Capstone.Migrations.Company
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20201122013635_ModifiedOnDelete")]
    partial class ModifiedOnDelete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("codeRed_Capstone.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int(10)");

                    b.Property<int>("Age")
                        .HasColumnName("Age")
                        .HasColumnType("int(1)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("City")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnName("Department")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(100)")
                        .HasDefaultValue("info@company.ca")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("varchar(60)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LastName")
                        .HasColumnType("varchar(60)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("Phone")
                        .HasColumnType("varchar(20)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.ToTable("employee");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Age = 30,
                            City = "Edmonton",
                            Department = "IT",
                            Email = "jsmith@company.ca",
                            FirstName = "John",
                            LastName = "Smith",
                            Phone = "(780)111-2222"
                        },
                        new
                        {
                            ID = -2,
                            Age = 31,
                            City = "Edmonton",
                            Department = "Sales",
                            Email = "ajohnson@company.ca",
                            FirstName = "Adam",
                            LastName = "Johnson",
                            Phone = "(780)222-3333"
                        },
                        new
                        {
                            ID = -3,
                            Age = 29,
                            City = "Calgary",
                            Department = "Sales",
                            Email = "ksandler@company.ca",
                            FirstName = "Kyle",
                            LastName = "Sandler",
                            Phone = "(780)333-4444"
                        },
                        new
                        {
                            ID = -4,
                            Age = 25,
                            City = "Calgary",
                            Department = "Accounting",
                            Email = "jalba@company.ca",
                            FirstName = "Jessica",
                            LastName = "Alba",
                            Phone = "(403)444-5555"
                        },
                        new
                        {
                            ID = -5,
                            Age = 30,
                            City = "Banff",
                            Department = "CEO",
                            Email = "kmoss@company.ca",
                            FirstName = "Kate",
                            LastName = "Moss",
                            Phone = "(780)678-9876"
                        });
                });

            modelBuilder.Entity("codeRed_Capstone.Models.EmployeeDate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int(10)");

                    b.Property<int>("EmployeeID")
                        .HasColumnName("EmployeeID")
                        .HasColumnType("int(10)");

                    b.Property<DateTime?>("FiredDate")
                        .HasColumnName("FiredDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("HiredDate")
                        .HasColumnName("HiredDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ModifiedDate")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID")
                        .HasName("FK_EmployeeDate_Employee");

                    b.ToTable("employeedate");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            EmployeeID = -1,
                            HiredDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = -2,
                            EmployeeID = -2,
                            FiredDate = new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HiredDate = new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = -3,
                            EmployeeID = -3,
                            HiredDate = new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = -4,
                            EmployeeID = -4,
                            HiredDate = new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = -5,
                            EmployeeID = -5,
                            HiredDate = new DateTime(2020, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("codeRed_Capstone.Models.EmployeeDate", b =>
                {
                    b.HasOne("codeRed_Capstone.Models.Employee", "Employee")
                        .WithMany("EmployeeDates")
                        .HasForeignKey("EmployeeID")
                        .HasConstraintName("FK_EmployeeDate_Employee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}