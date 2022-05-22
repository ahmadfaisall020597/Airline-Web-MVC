namespace AirlineBookingMVC.Areas.Admin.ViewModels.Shared;

public class DeleteConfirmViewModel : BaseViewModel
{
    public string Action { get; set; } = string.Empty;
    public string Area { get; set; } = string.Empty;
    public string Controller { get; set; } = string.Empty;
    public string ID { get; set; } = string.Empty;
    public string IDName { get; set; } = string.Empty;
    
    
}