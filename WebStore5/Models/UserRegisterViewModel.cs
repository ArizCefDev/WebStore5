using System.ComponentModel.DataAnnotations;

namespace WebStore5.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Lütfən istifadəçi adını daxil edin")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfən şifrəni daxil edin")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfən təkrar şifrəni daxil edin")]
        [Compare("Password", ErrorMessage = "Şifrələr uyğun deyil")]
        public string ConfirmPassword { get; set; }
    }
}
