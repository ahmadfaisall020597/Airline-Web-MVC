using System.ComponentModel.DataAnnotations;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.Pesawat
{
    public class CreatePesawatViewModel : BaseViewModel
    {

        [Display(Name = "Kode Penerbangan")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kode Penerbangan harus diisi")]
        public string KodePenerbangan { get; set; } = string.Empty;
        
        [Display(Name = "Jenis Pesawat")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Jenis Pesawat harus diisi")]
        public string KodeJenisPesawat { get; set; }= string.Empty;
        
        [Display(Name = "Maskapai")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Maskapai harus diisi")]
        public string KodeMaskapai { get; set; } = string.Empty;

        
        [Display(Name = "Nomor Kursi")]
        public string NomorKursi { get; set; } = string.Empty;
        
        
        [Required(AllowEmptyStrings = true, ErrorMessage = "Invalid Action Type")]
        public String ActionType { get; set; }
        
        public List<EditKursiPesawatViewModel> KursiPesawats { get; set; } = new List<EditKursiPesawatViewModel>();


        
    }
}
