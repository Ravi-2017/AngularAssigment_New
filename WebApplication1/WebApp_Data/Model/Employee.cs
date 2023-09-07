using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_Data.Model
{
    public partial class Employee
    {
        [Key]
        [Column("Emp_Id")]
        public int EmpId { get; set; }
        [Required]
        [Column("Emp_Name")]
        [StringLength(100)]
        public string EmpName { get; set; }
        [Column("Emp_Address")]
        [StringLength(100)]
        public string EmpAddress { get; set; }
    }
}
