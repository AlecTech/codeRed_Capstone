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
        [MaxLength(60, ErrorMessage = "Lenght can not exceed 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName", TypeName = "varchar(60)")]
        [MaxLength(60, ErrorMessage = "Lenght can not exceed 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // [RegularExpression(@"^([\w\.\-] +)@([\w\-] +)((\.(\w){2, 3})+)$")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", 
            ErrorMessage = "Invalid Email Format")]
        [Column("Email", TypeName = "varchar(100)")]
        public string Email { get; set; }
      
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone format should be: (xxx)xxx-xxxx")]
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
