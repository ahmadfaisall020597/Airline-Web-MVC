using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.AdminUser;

public class EditAdminUserViewModel : BaseViewModel
{
    [Key]
    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email harus diisi")]
    [DataType(DataType.EmailAddress)]
    public string Email {  get; set; } = string.Empty;

    [Display(Name = "Nama User")]
    [Required(ErrorMessage = "Nama User harus diisi")]
    public string Username { get; set; } = string.Empty;    

    [Display(Name = "Aktif")]
    public bool Active { get; set; } 

}