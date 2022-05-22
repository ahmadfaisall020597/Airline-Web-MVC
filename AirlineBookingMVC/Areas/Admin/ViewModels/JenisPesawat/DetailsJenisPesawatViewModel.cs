using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.JenisPesawat;

public class DetailsJenisPesawatViewModel : BaseViewModel
{
    [Display(Name="Kode Jenis Pesawat")]
    [Required(ErrorMessage = "Kode Jenis Pesawat perlu diisi")]
    public string KodeJenisPesawat { get; set; } = string.Empty;

    [Display(Name="Tahun Pesawat")]
    public int TahunPesawat { get; set; }
    
    [Display(Name = "Dibuat pada")]
    public DateTime CreatedAt { get; set; }

    [Display(Name = "Dibuat oleh")]
    public string CreatedBy { get; set; } = string.Empty;

    [Display(Name = "Diubah pada")]
    public DateTime? UpdatedAt { get; set; }

    [Display(Name = "Diubah oleh")]
    public string? UpdatedBy { get; set; } = string.Empty;
}