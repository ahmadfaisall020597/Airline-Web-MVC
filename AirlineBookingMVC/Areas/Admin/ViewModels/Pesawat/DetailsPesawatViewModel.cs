using System.ComponentModel.DataAnnotations;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.Pesawat
{
    public class DetailsPesawatViewModel : BaseViewModel
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

        [Display(Name = "Dibuat pada")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Dibuat oleh")]
        public string CreatedBy { get; set; } = string.Empty;

        [Display(Name = "Diubah pada")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Diubah oleh")]
        public string? UpdatedBy { get; set; } = string.Empty;

        
    }
}
