using System.Net;
using System.Web.Http;
using AirlineBooking.Models;
using AirlineBooking.Services;
using AirlineBookingMVC.Areas.Admin.ViewModels.Maskapai;
using Microsoft.AspNetCore.Mvc;


namespace AirlineBookingMVC.Areas.Admin.ApiControllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/maskapai")]
    [ApiController]
    public class MaskapaiController : BaseApiController
    {
        
        public MaskapaiController(AirlineBookingDbContext db) : base(db)
        {
            
        }
        
        [Microsoft.AspNetCore.Mvc.Route("list")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public List<DetailsMaskapaiViewModel> Index()
        {
            var _listMaskapaiVM = new List<DetailsMaskapaiViewModel>();
            
            try
            {
                MaskapaiService _maskapaiService = new MaskapaiService(_db, "");
                var _maskapais = _maskapaiService.FindList();
                
                if (_maskapais != null && _maskapais.Count > 0)
                {
                    foreach (var _maskapai in _maskapais)
                    {
                        _listMaskapaiVM.Add(
                            new DetailsMaskapaiViewModel()
                            {
                                KodeMaskapai = _maskapai.KodeMaskapai,
                                NamaMaskapai = _maskapai.NamaMaskapai,
                                CreatedAt = _maskapai.CreatedAt,
                                CreatedBy = _maskapai.CreatedBy,
                                UpdatedAt = _maskapai.UpdatedAt,
                                UpdatedBy = _maskapai.UpdatedBy,
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
            
            return _listMaskapaiVM;
        }
    }
}
