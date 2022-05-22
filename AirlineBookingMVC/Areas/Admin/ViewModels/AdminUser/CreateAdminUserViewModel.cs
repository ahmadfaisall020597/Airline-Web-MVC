using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.AdminUser;

public class CreateAdminUserViewModel : BaseViewModel
{
    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email harus diisi")]
    [DataType(DataType.EmailAddress)]
    public string Email {  get; set; } = string.Empty;

    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password harus diisi")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    
    [Display(Name = "Konfirmasi Password")]
    [Required(ErrorMessage = "Konfirmasi Password harus diisi")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = string.Empty;
    
    [Display(Name = "Nama User")]
    [Required(ErrorMessage = "Nama User harus diisi")]
    public string Username { get; set; } = string.Empty;    

    [Display(Name = "Aktif")]
    public bool Active { get; set; } 

}