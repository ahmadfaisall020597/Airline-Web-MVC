using System.ComponentModel.DataAnnotations;

namespace AirlineBookingMVC.Areas.Admin.ViewModels
{
    public class BaseViewModel
    {
        [Required(AllowEmptyStrings = true)]
        public string t { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = true)]
        public string Message { get; set; }= string.Empty;

        public void UpdateTokenAndMessage(string t, string msg)
        {
            this.t = t;
            this.Message = msg;
        }
    }
}
