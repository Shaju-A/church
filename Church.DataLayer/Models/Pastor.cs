using System.ComponentModel.DataAnnotations;

namespace Church.DataLayer.Db.Entity
{
    [MetadataType(typeof(PastorMetaData))]
    public partial class Pastor
    {
    }
    public class PastorMetaData
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        
        [Required]
        [Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; }
        [Display(Name = "Created By")]
        public int? CreatedBy { get; set; }
        [Display(Name = "Updated By")]
        public int? UpdatedBy { get; set; }
    }
}
