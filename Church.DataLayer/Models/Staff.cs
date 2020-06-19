using System.ComponentModel.DataAnnotations;

namespace Church.DataLayer.Db.Entity
{
    [MetadataType(typeof(StaffMetaData))]
    public partial class Staff
    {
    }

    public partial class StaffMetaData
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Place { get; set; }
        [Display(Name = "Address")]
        [Required]
        public string Address1 { get; set; }
        [Display(Name = "Address")]
        public string Address2 { get; set; }
    }
}
