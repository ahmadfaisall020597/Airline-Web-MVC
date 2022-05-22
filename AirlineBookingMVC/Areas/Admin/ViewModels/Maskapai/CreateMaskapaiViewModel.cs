using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.Maskapai;

public class CreateMaskapaiViewModel : BaseViewModel
{
    [Display(Name="Kode Maskapai")]
    [Required(ErrorMessage = "Kode Maskapai perlu diisi")]
    public string KodeMaskapai { get; set; } = string.Empty;

    [Display(Name="Nama Maskapai")]
    [Required(ErrorMessage = "Nama Maskapai perlu diisi")]
    public string NamaMaskapai { get; set; } = string.Empty;

}