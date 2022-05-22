using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.Maskapai;

public class EditMaskapaiViewModel : BaseViewModel
{
    [Display(Name = "Kode Maskapai")]
    public string KodeMaskapai { get; set; } = string.Empty;

    [Display(Name = "Nama Maskapai")]
    public string NamaMaskapai { get; set; } = string.Empty;


}