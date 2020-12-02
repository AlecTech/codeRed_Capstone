using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using codeRed_Capstone.Common;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc;

namespace codeRed_Capstone.Models
{
    [Table("employee")]
    public class Employee : IValidatableObject
    {
        public DateTime ValidationValidFrom { get; set; }

        [Key]
        [Required]
        [Column("ID", TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Can not have numbers or special characters")]
        [Column("FirstName", TypeName = "varchar(60)")]
        [MaxLength(60, ErrorMessage = "Lenght can not exceed 50 characters")]
        //[Remote(action: "VerifyName", controller: "Users", AdditionalFields = nameof(LastName))]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Can not have numbers or special characters")]
        [Column("LastName", TypeName = "varchar(60)")]
        [MaxLength(60, ErrorMessage = "Lenght can not exceed 50 characters")]
        //[Remote(action: "VerifyName", controller: "Users", AdditionalFields = nameof(FirstName))]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // [RegularExpression(@"^([\w\.\-] +)@([\w\-] +)((\.(\w){2, 3})+)$")]
        [Required(ErrorMessage = "The email address is required")]
        //[Unique]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", 
            ErrorMessage = "Invalid Email Format")]
        [Column("Email", TypeName = "varchar(100)")]
        //Dec 1 adding validation if email exists
        //[Remote("CheckEmailAddress", "Validation")]
       
        public string Email { get; set; }
      
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone format should be: (###)###-####")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(###)###-####}")]
        [Column("Phone", TypeName = "varchar(20)")]
        public string Phone { get; set; }

        [Required]
        [Range(16, 100)]
        [Column("Age", TypeName = "int(1)")]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Can not have numbers or special characters")]
        [Column("City", TypeName = "varchar(100)")]
        public string City { get; set; }

        [Required]
        [Column("Department", TypeName = "varchar(100)")]
        public string Department { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Column("HiredDate", TypeName = "date")]
        [Display(Name = "Hired On")]
        [CurrentDate]
        public DateTime HiredDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Column("FiredDate", TypeName = "date")]
        [Display(Name = "Fired On")]
        [CurrentDate]
        public DateTime? FiredDate { get; set; }

        [Required]
        [Column("ModifiedDate", TypeName = "datetime")]
        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FiredDate < HiredDate)
            {
                yield return new ValidationResult("Can not Fire before Hire!", new[] { "FiredDate" });
            }

        }
        //[AcceptVerbs("GET", "POST")]
        //public IActionResult VerifyName(string FirstName, string LastName)
        //{
        //    if (!_userService.VerifyName(FirstName, LastName))
        //    {
        //        return Json($"A user named {FirstName} {LastName} already exists.");
        //    }

        //    return Json(true);
        //}
    }
}
