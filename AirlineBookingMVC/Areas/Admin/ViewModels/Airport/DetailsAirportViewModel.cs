using System.ComponentModel.DataAnnotations;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.Airport
{
    public class DetailsAirportViewModel : BaseViewModel
    {
        [Display(Name ="Kode Bandara")]
        public string KodeAirport { get; set; } = string.Empty;

        [Display(Name = "Nama Bandara")]
        public string NamaAirport { get; set; }= string.Empty;

        [Display(Name = "Propinsi")]
        public string Propinsi { get; set; } = string.Empty;

        [Display(Name = "Kota")]
        public string Kota { get; set; } = string.Empty;

        [Display(Name = "Dibuat pada")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Dibuat oleh")]
        public string CreatedBy { get; set; } = string.Empty;

        [Display(Name = "Diubah pada")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Diubah oleh")]
        public string? UpdatedBy { get; set; } = string.Empty;
        
        public DetailsAirportViewModel() { }

        public DetailsAirportViewModel(string kodeAirport,
          string namaAiport,
          string propinsi,
          string kota)
        {
            this.KodeAirport = kodeAirport;
            this.NamaAirport = namaAiport;
            this.Propinsi = propinsi;
            this.Kota = kota;
        }
    }
}
