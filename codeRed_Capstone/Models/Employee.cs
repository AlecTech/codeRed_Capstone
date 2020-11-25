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
        public DateTime ValidationValidFrom { get; set; }

        [Key]
        [Required]
        [Column("ID", TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column("FirstName", TypeName = "varchar(60)")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName", TypeName = "varchar(60)")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Column("Email", TypeName = "varchar(100)")]
        public string Email { get; set; }
      
        [Required]
        [Column("Phone", TypeName = "varchar(20)")]
        public string Phone { get; set; }

        [Required]
        [Range(16, 100)]
        [Column("Age", TypeName = "int(1)")]
        public int Age { get; set; }

        [Required]
        [Column("City", TypeName = "varchar(100)")]
        public string City { get; set; }

        [Required]
        [Column("Department", TypeName = "varchar(100)")]
        public string Department { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Column("HiredDate", TypeName = "date")]
        [Display(Name = "Hired On")]
        public DateTime HiredDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Column("FiredDate", TypeName = "date")]
        [Display(Name = "Fired On")]
        public DateTime? FiredDate { get; set; }

        [Required]
        [Column("ModifiedDate", TypeName = "datetime")]
        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }

    }
}
