using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codeRed_Capstone.Models
{
    [Table("employee")]
    public class Employee
    {
        //default constructor 
        public Employee()
        {
            EmployeeDates = new HashSet<EmployeeDate>();
        }

        public string GetHiredDate
        {
            get
            {
                var hiredate = "this employee has never been hired";
                if (EmployeeDates.LastOrDefault() != null)
                {
                    hiredate = EmployeeDates.LastOrDefault().HiredDate.ToLongDateString();

                }
                return hiredate;
            }
        }
        
        public string GetFiredDate
        {
            get
            {
                var firedate = "this employee has never been fired";
                if (EmployeeDates.LastOrDefault() != null && EmployeeDates.LastOrDefault().FiredDate.HasValue)
                {
                    firedate = EmployeeDates.LastOrDefault().FiredDate.Value.ToLongDateString();
                }
                return firedate;
            }
        }

        private DateTime hireddate = DateTime.Now;
        public DateTime HiredDate
        {
            get
            {
                //DateTime hiredate = null;
                //if (EmployeeDates.LastOrDefault() != null )
                //{
                //    hiredate = EmployeeDates.LastOrDefault().HiredDate;
                //}
                return hireddate;
            }
            //set
            //{
            //    hireddate = value;
            //}
        }

        public DateTime? FiredDate
        {
            get
            {
                DateTime? firedate = null;
                if (EmployeeDates.LastOrDefault() != null && EmployeeDates.LastOrDefault().FiredDate.HasValue)
                {
                    firedate = EmployeeDates.LastOrDefault().FiredDate.Value;
                }
                return firedate;
            }
        }

        [Key]
        [Required]
        [Column("ID", TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column("FirstName", TypeName = "varchar(60)")]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName", TypeName = "varchar(60)")]
        public string LastName { get; set; }

        [Required]
        [Column("Email", TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column("Phone", TypeName = "varchar(20)")]
        public string Phone { get; set; }

        [Required]
        [Range (16, 100)]
        [Column("Age", TypeName = "int(1)")]
        public int Age { get; set; }

        [Required]
        [Column("City", TypeName = "varchar(100)")]
        public string City { get; set; }

        [Required]
        [Column("Department", TypeName = "varchar(100)")]
        public string Department { get; set; }


        [InverseProperty(nameof(Models.EmployeeDate.Employee))]
        //ICollection is for looping through List<Objects> and allows to modify them(Add,Remove) . IEnumerables only allows to loop
        public virtual ICollection<EmployeeDate> EmployeeDates { get; set; }
       
      
    }
}
