using System.Net;
using System.Web.Http;
using AirlineBooking.Models;
using AirlineBooking.Services;
using AirlineBookingMVC.Areas.Admin.ViewModels.Pesawat;
using Microsoft.AspNetCore.Mvc;


namespace AirlineBookingMVC.Areas.Admin.ApiControllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/pesawat")]
    [ApiController]
    public class PesawatController : BaseApiController
    {
        
        public PesawatController(AirlineBookingDbContext db) : base(db)
        {
        }
        
        [Microsoft.AspNetCore.Mvc.Route("list")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public List<DetailsPesawatViewModel> Index()
        {
            var _listPesawatVM = new List<DetailsPesawatViewModel>();
            
            try
            {
                PesawatService _pesawatService = new PesawatService(_db, "");
                var _pesawats = _pesawatService.FindList();
                
                if (_pesawats != null && _pesawats.Count > 0)
                {
                    foreach (var _pesawat in _pesawats)
                    {
                        _listPesawatVM.Add(
                            new DetailsPesawatViewModel()
                            {
                                KodePenerbangan = _pesawat.KodePenerbangan,
                                KodeJenisPesawat = _pesawat.KodeJenisPesawat,
                                KodeMaskapai = _pesawat.KodeMaskapai,
                                CreatedAt = _pesawat.CreatedAt,
                                CreatedBy = _pesawat.CreatedBy,
                                UpdatedAt = _pesawat.UpdatedAt,
                                UpdatedBy = _pesawat.UpdatedBy,
                            }
                        );
                    }
                }

            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                };
                throw new HttpResponseException(resp);
            }
            
            return _listPesawatVM;
        }
    }
}
