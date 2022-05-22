using System.ComponentModel.DataAnnotations;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.Pesawat
{
    public class DeletePesawatViewModel : BaseViewModel
    {

        [Display(Name = "Kode Penerbangan")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kode Penerbangan harus diisi")]
        public string KodePenerbangan { get; set; } = string.Empty;
        
    }
}
