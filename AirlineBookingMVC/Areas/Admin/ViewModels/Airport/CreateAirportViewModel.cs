using System.ComponentModel.DataAnnotations;
using AirlineBookingMVC.Areas.Admin.ViewModels.AirportGateway;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.Airport
{
    public class CreateAirportViewModel : BaseViewModel
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
        
        
        
        [Display(Name = "Nomor Gate")]
        /*[Required(AllowEmptyStrings = false, ErrorMessage = "Nomor Gate harus diisi")]*/
        public string NomorGate { get; set; } = string.Empty;
        
        [Display(Name = "Nomor Pintu")]
        /*[Required(AllowEmptyStrings = false, ErrorMessage = "Nomor Pintu harus diisi")]*/
        public string NomorPintu { get; set; } = string.Empty;
        
        
        [Required(AllowEmptyStrings = true, ErrorMessage = "Invalid Action Type")]
        public String ActionType { get; set; }
        
        public List<EditAirportGatewayViewModel> Gateways { get; set; } = new List<EditAirportGatewayViewModel>();


        
    }
}
