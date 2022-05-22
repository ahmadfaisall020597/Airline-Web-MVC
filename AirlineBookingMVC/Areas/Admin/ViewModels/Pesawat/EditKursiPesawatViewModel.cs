using System.ComponentModel.DataAnnotations;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.Pesawat
{
    public class EditKursiPesawatViewModel : BaseViewModel
    {
        [Display(Name = "Nomor Kursi")]
        public string NomorKursi { get; set; } = string.Empty;

        
    }
}
