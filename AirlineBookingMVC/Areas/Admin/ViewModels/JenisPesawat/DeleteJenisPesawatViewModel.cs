using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.JenisPesawat;

public class DeleteJenisPesawatViewModel : BaseViewModel
{
    [Display(Name="Kode Jenis Pesawat")]
    [Required(ErrorMessage = "Kode Jenis Pesawat perlu diisi")]
    public string KodeJenisPesawat { get; set; } = string.Empty;

}