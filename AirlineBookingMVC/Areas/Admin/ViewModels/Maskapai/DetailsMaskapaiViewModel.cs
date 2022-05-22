using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.Maskapai;

public class DetailsMaskapaiViewModel : BaseViewModel
{
    
    [Display(Name = "Kode Maskapai")]
    public string KodeMaskapai { get; set; } = string.Empty;

    [Display(Name = "Nama Maskapai")] 
    public string NamaMaskapai { get; set; } = string.Empty;


    [Display(Name = "Dibuat pada")]
    public DateTime CreatedAt { get; set; }

    [Display(Name = "Dibuat oleh")]
    public string CreatedBy { get; set; } = string.Empty;

    [Display(Name = "Diubah pada")]
    public DateTime? UpdatedAt { get; set; }

    [Display(Name = "Diubah oleh")]
    public string? UpdatedBy { get; set; } = string.Empty;
}