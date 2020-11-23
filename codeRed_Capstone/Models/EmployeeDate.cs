using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace codeRed_Capstone.Models
{
    [Table("employeedate")]
    public class EmployeeDate
    {
        [Key]
        [Required]
        [Column("ID", TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column("HiredDate", TypeName = "date")]
        [Display(Name = "Hired On")]
        public DateTime HiredDate { get; set; }

        [Column("FiredDate", TypeName = "date")]
        [Display(Name = "Fired On")]
        public DateTime? FiredDate { get; set; }

        [Required]
        //[Timestamp]
        [Column("ModifiedDate", TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [Required]
        [Column("EmployeeID", TypeName = "int(10)")]
        public int EmployeeID { get; set; }

        // This attribute specifies which database field is the foreign key. Typically in the child (many side of the 1-many).
        [ForeignKey(nameof(EmployeeID))]

        // InverseProperty links the two virtual properties together.
        [InverseProperty(nameof(Models.Employee.EmployeeDates))]
        public virtual Employee Employee { get; set; }

    }
}
