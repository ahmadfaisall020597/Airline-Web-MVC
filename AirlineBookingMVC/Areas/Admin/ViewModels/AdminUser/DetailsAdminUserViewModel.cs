using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.AdminUser;

public class DetailsAdminUserViewModel : BaseViewModel
{
    [Key]
    [Display(Name = "Email")]
    public string Email {  get; set; } = string.Empty;

    [Display(Name = "Nama User")]
    public string Username { get; set; } = string.Empty;    

    [Display(Name = "Aktif")]
    public string Active { get; set; } = string.Empty;

    [Display(Name = "Dibuat pada")]
    public DateTime CreatedAt { get; set; }

    [Display(Name = "Dibuat oleh")]
    public string CreatedBy { get; set; } = string.Empty;

    [Display(Name = "Diubah pada")]
    public DateTime? UpdatedAt { get; set; }

    [Display(Name = "Diubah oleh")]
    public string? UpdatedBy { get; set; }
}