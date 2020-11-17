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
        //public Employee()
        //{
        //    Employees = new HashSet<Employee>();
        //}

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
        [Column("Age", TypeName = "int(1)")]
        public int Age { get; set; }

        [Required]
        [Column("City", TypeName = "varchar(100)")]
        public string City { get; set; }

        [Required]
        [Column("Department", TypeName = "varchar(100)")]
        public string Department { get; set; }

        //[Timestamp]
        //[Column("CreatedAt", TypeName = "timestamp")]
        //public byte[] CreatedAt { get; set; }

        //ICollection is for looping through List<Objects> and allows to modify them(Add,Remove) . IEnumerables only allows to loop
       // public virtual ICollection<Employee> Employees { get; set; }
    }
}
