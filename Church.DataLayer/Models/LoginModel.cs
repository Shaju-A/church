using System.ComponentModel.DataAnnotations;

namespace Church.DataLayer.Models
{
    public class LoginModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Invalid { get; set; }
    }
}
