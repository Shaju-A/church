using System.ComponentModel.DataAnnotations;

namespace Church.DataLayer.Db.Entity
{
    [MetadataType(typeof(GenderMetaData))]
    public partial class Gender
    {

    }

    public class GenderMetaData
    {
        [Display(Name ="Gender")]
        public string Name { get; set; }
    }
}
