using System.Text.Encodings.Web;
using System.Web;
using AirlineBooking.Models;
using AirlineBooking.Services;
using AirlineBookingMVC.AppConfig;
using AirlineBookingMVC.Areas.Admin.ViewModels.Airport;
using AirlineBookingMVC.Areas.Admin.ViewModels.AirportGateway;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AirlineBookingMVC.Areas.Admin.Controllers;

[Area("Admin")]
public class AirportController : BaseController
{
    public AirportController(AirlineBookingDbContext db) : base(db)
    {
    }

    public IActionResult Edit(string id, CreateAirportViewModel pEditAirportVM)
    {
        try
        {
            _setLoginID();
            id = _decodeUrl(id);
            
            AirportService _airportService = new AirportService(_db, _loginID);
            var _airport = _airportService.FindAirportByKodeAirport(id, false);
            var _editAirportVM = new CreateAirportViewModel()
            {
                KodeAirport = _airport.KodeAirport,
                NamaAirport = _airport.NamaAirport,
                Propinsi = _airport.Propinsi,
                Kota = _airport.Kota,
                t = pEditAirportVM.t
            };
            foreach (var _g in _airport.Gateways)
            {
                _editAirportVM.Gateways.Add(new EditAirportGatewayViewModel()
                {
                    NomorGate = _g.NomorGate,
                    NomorPintu = _g.NomorPintu,
                });
            }
            
            return View("Edit", _editAirportVM);
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }
        return View("Edit", pEditAirportVM);
    }
    
    public IActionResult Create(CreateAirportViewModel pCreateAirportVM)
    {
        return View("Create", pCreateAirportVM);
    }

    [HttpPost]
    public IActionResult Update(CreateAirportViewModel pEditAirportVM)
    {
        try
        {
            var _actionType = pEditAirportVM.ActionType;
            if (_actionType == "AddGateway")
            {
                if (string.IsNullOrEmpty(pEditAirportVM.NomorGate))
                {
                    throw new Exception("Nomor Gate perlu diisi");
                }
                if (string.IsNullOrEmpty(pEditAirportVM.NomorGate))
                {
                    throw new Exception("Nomor Gate perlu diisi");
                }
                pEditAirportVM.Gateways.Add(new EditAirportGatewayViewModel()
                {
                    NomorGate =pEditAirportVM.NomorGate,
                    NomorPintu = pEditAirportVM.NomorPintu
                });
                pEditAirportVM.NomorGate = "";
                pEditAirportVM.NomorPintu = "";
                
                return View("Edit", pEditAirportVM);

            }
            else
            {
                _setLoginID();
                var _gateways = _mappingGatewaysFromViewModel(pEditAirportVM.Gateways);
                
                AirportService _airportService = new AirportService(_db, _loginID);
                _airportService.UpdateAirport(pEditAirportVM.KodeAirport,
                    pEditAirportVM.NamaAirport,
                    pEditAirportVM.Propinsi,
                    pEditAirportVM.Kota,
                    _gateways);
                

                var _listAirportVM = new ListAirportViewModel()
                {
                    Message = "Data sudah diubah",
                    t = pEditAirportVM.t,
                };
                return RedirectToAction("List", _listAirportVM);
            }

        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View("Edit", pEditAirportVM);
    }


    private List<AirportGatewayModel> _mappingGatewaysFromViewModel(List<EditAirportGatewayViewModel> pGateways)
    {
        var _gateways = new List<AirportGatewayModel>();
        foreach (var g in pGateways)
        {
            _gateways.Add(new AirportGatewayModel()
            {
                NomorGate = g.NomorGate,
                NomorPintu = g.NomorPintu,
            });
        }

        return _gateways;
    }
    
    [HttpPost]
    public IActionResult Insert(CreateAirportViewModel pCreateAirportVM)
    {
        try
        {
            var _actionType = pCreateAirportVM.ActionType;
            if (_actionType == "AddGateway")
            {
                if (string.IsNullOrEmpty(pCreateAirportVM.NomorGate))
                {
                    throw new Exception("Nomor Gate perlu diisi");
                }
                if (string.IsNullOrEmpty(pCreateAirportVM.NomorGate))
                {
                    throw new Exception("Nomor Gate perlu diisi");
                }
                pCreateAirportVM.Gateways.Add(new EditAirportGatewayViewModel()
                {
                    NomorGate =pCreateAirportVM.NomorGate,
                    NomorPintu = pCreateAirportVM.NomorPintu
                });
                pCreateAirportVM.NomorGate = "";
                pCreateAirportVM.NomorPintu = "";
                return View("Create", pCreateAirportVM);

            } 
            else
            {
                _setLoginID();
                AirportService _airportService = new AirportService(_db, _loginID);

                var _gateways = _mappingGatewaysFromViewModel(pCreateAirportVM.Gateways);
                
                _airportService.AddAirport(pCreateAirportVM.KodeAirport,
                    pCreateAirportVM.NamaAirport,
                    pCreateAirportVM.Propinsi,
                    pCreateAirportVM.Kota,
                    _gateways);

                var _listAirportVM = new ListAirportViewModel()
                {
                    Message = "Data sudah tersimpan",
                    t = pCreateAirportVM.t,
                };
                return RedirectToAction("List", _listAirportVM);
            }
           
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View("Create", pCreateAirportVM);
        
    }

    
    [HttpPost]
    public IActionResult Delete(DeleteAirportViewModel pDeleteAirportVM)
    {
        ListAirportViewModel _listAirportVM = new ListAirportViewModel();
        _listAirportVM.t = pDeleteAirportVM.t;
        try
        {
            if (ModelState.IsValid)
            {
                _setLoginID();
                AirportService _airportService = new AirportService(_db, _loginID);
                _airportService.DeleteAirport(pDeleteAirportVM.KodeAirport);

                _listAirportVM.Message = "Data sudah dihapus";
                return RedirectToAction("List", _listAirportVM);
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View("List", _listAirportVM);
        
    }
    
    public IActionResult List(ListAirportViewModel pListAirportVM)
    {
        try
        {
            _setLoginID();
            AirportService _airportService = new AirportService(_db, _loginID);
            var _airports = _airportService.FindList();

            var _listAirportVM = new ListAirportViewModel();
            _listAirportVM.UpdateTokenAndMessage(pListAirportVM.t, pListAirportVM.Message);
                
            if (_airports != null && _airports.Count > 0)
            {
                foreach (var _airport in _airports)
                {
                    _listAirportVM.Airports.Add(
                        new DetailsAirportViewModel()
                        {
                            KodeAirport = _airport.KodeAirport,
                            NamaAirport = _airport.NamaAirport,
                            Propinsi = _airport.Propinsi,
                            Kota = _airport.Kota,
                            CreatedAt = _airport.CreatedAt,
                            CreatedBy = _airport.CreatedBy,
                            UpdatedAt = _airport.UpdatedAt,
                            UpdatedBy = _airport.UpdatedBy,
                        }
                    );
                }
            }
            
            return View("List", _listAirportVM);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return View("List", pListAirportVM);
    }
    
}