using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.AdminUser;

public class DeleteAdminUserViewModel : BaseViewModel
{
    [Key]
    [Display(Name = "Email")]
    [Required(ErrorMessage = "Invalid Email")]
    [DataType(DataType.EmailAddress)]
    public string Email {  get; set; } = string.Empty;
    
}