using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using codeRed_Capstone.Common;
//using Microsoft.AspNetCore.Mvc;

namespace codeRed_Capstone.Models
{
    //IValidatebleObject added because I added CurrentDate Attribute (inside Common Folder) to validate dates(cann't be into the future dates)
    [Table("employee")]
    public class Employee : IValidatableObject
    {
        //public DateTime ValidationValidFrom { get; set; }

       

        [Key]
        [Required]
        [Column("ID", TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //First Name cann't have numbers or special char and can't be empty and can't exceed 60 characters
        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Can not have numbers or special characters")]
        [Column("FirstName", TypeName = "varchar(60)")]
        [MaxLength(60, ErrorMessage = "Lenght can not exceed 60 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        //Last Name cann't have numbers or special char and can't be empty can't exceed 60 characters
        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Can not have numbers or special characters")]
        [Column("LastName", TypeName = "varchar(60)")]
        [MaxLength(60, ErrorMessage = "Lenght can not exceed 60 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z.]+$", 
            ErrorMessage = "Invalid Email Format")]
        [Column("Email", TypeName = "varchar(100)")]
        //Dec 1 adding validation if email exists (Server side)
        //[Remote("CheckEmailAddress", "Validation")]
        public string Email { get; set; }
      
        //Format validation and missing phone validation
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone format should be: (###)###-####")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(###)###-####}")]
        [Column("Phone", TypeName = "varchar(20)")]
        public string Phone { get; set; }

        //Range validation, Age cann't be less or more than range
        [Required]
        [Range(16, 100)]
        [Column("Age", TypeName = "int(1)")]
        public int Age { get; set; }

        //City cann't have numbers or special char and can't be empty
        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Can not have numbers or special characters")]
        [Column("City", TypeName = "varchar(100)")]
        public string City { get; set; }

        //Department cann't be empty
        [Required]
        [Column("Department", TypeName = "varchar(100)")]
        public string Department { get; set; }

        //Format validation and Cann't be into the future and can't be null, default value NOW()
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Column("HiredDate", TypeName = "date")]
        [Display(Name = "Hired On")]
        [CurrentDate(ErrorMessage = "Hired Date can not be into the future")]
        public DateTime HiredDate { get; set; }

        //Format validation and Cann't be into the future
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Column("FiredDate", TypeName = "date")]
        [Display(Name = "Fired On")]
        [CurrentDate(ErrorMessage = "Fired Date can not be into the future")]
        public DateTime? FiredDate { get; set; }

        //Cann't be null validation, so db assigns auto generated value
        [Required]
        [Column("ModifiedDate", TypeName = "datetime")]
        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Required]
        [Column("TimesModified", TypeName = "int(1)")]
        [Display(Name = "Times Modified")]
        public int TimesModified { get; set; }

        //Fired date cann't be less than HiredDate validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FiredDate < HiredDate)
            {
                yield return new ValidationResult("Can not Fire before Hire!", new[] { "FiredDate" });
            }

        }
 
    }
}
