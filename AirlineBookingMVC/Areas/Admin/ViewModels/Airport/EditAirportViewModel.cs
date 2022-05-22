using System.ComponentModel.DataAnnotations;
using AirlineBookingMVC.Areas.Admin.ViewModels.AirportGateway;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.Airport
{
    public class EditAirportViewModel : BaseViewModel
    {

        [Display(Name = "Kode Bandara")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kode Bandara harus diisi")]
        public string KodeAirport { get; set; } = string.Empty;

        
        [Display(Name = "Nama Bandara")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nama Bandara harus diisi")]
        public string NamaAirport { get; set; }= string.Empty;

        [Display(Name = "Propinsi")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Propinsi harus diisi")]
        public string Propinsi { get; set; }= string.Empty;

        [Display(Name = "Kota")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kota harus diisi")]
        public string Kota { get; set; }= string.Empty;


        public List<EditAirportGatewayViewModel> Gateways { get; set; } = new List<EditAirportGatewayViewModel>();
        

        public EditAirportViewModel() { }
        public EditAirportViewModel(string kodeAirport,
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
