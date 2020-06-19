using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Church.DataLayer.Db.Entity
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
        
    }
    public class EmployeeMetaData
    {
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Employee Name required")]
        public string Name { get; set; }
        [Display(Name = "Department")]
        [Required]
        public Nullable<int> DepartmentId { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public Nullable<int> GenderId { get; set; }
        [Required]
        [Display(Name="salary")]
        public Nullable<decimal> Salary { get; set; }
    }
}
