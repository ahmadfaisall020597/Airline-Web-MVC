using System.ComponentModel.DataAnnotations;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.Login
{
    public class LoginViewModel : BaseViewModel
    {
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email harus diisi")]

        /*abc @gmail.com*/
        [RegularExpression(@"[\w.\-_]+\@[\w]+\.[\w]+", ErrorMessage = "Email tidak valid")]
        /*[DataType(DataType.EmailAddress, ErrorMessage ="Invalid Email")]*/
        public string Email { get; set; } = string.Empty;


        [Display(Name = "Kata Sandi")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="Kata Sandi harus diisi")]
        [StringLength(6, MinimumLength = 6, ErrorMessage ="Kata Sandi harus 6 karakter")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
