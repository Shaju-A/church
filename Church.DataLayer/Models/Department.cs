using System.ComponentModel.DataAnnotations;

namespace Church.DataLayer.Db.Entity
{
    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department
    {

    }
    public class DepartmentMetaData
    {
        [Display(Name ="Department")]
        public string Name { get; set; }
    }
}
