using System.ComponentModel.DataAnnotations;

namespace WebStore5.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Lütfən istifadəçi adını daxil edin")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfən şifrəni daxil edin")]
        public string Password { get; set; }
    }
}
