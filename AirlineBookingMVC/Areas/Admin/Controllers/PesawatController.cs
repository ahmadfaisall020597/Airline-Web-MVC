using AirlineBooking.Models;
using AirlineBooking.Services;
using AirlineBookingMVC.Areas.Admin.ViewModels.Pesawat;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingMVC.Areas.Admin.Controllers;

[Area("Admin")]
public class PesawatController : BaseController
{
    public PesawatController(AirlineBookingDbContext db) : base(db)
    {
    }

    public IActionResult Edit(string id, CreatePesawatViewModel pEditPesawatVM)
    {
        try
        {
            ViewBag.FormMode = "Edit";
            _setLoginID();
            id = _decodeUrl(id);

            PesawatService _pesawatService = new PesawatService(_db, _loginID);
            var _pesawat = _pesawatService.FindByKodePenerbangan(id);
            var _editPesawatVM = new CreatePesawatViewModel()
            {
                KodePenerbangan = _pesawat.KodePenerbangan,
                KodeJenisPesawat = _pesawat.KodeJenisPesawat,
                KodeMaskapai = _pesawat.KodeMaskapai,
                t = pEditPesawatVM.t
            };
            foreach (var _kp in _pesawat.KursiPesawats)
            {
                _editPesawatVM.KursiPesawats.Add(new EditKursiPesawatViewModel()
                {
                    NomorKursi = _kp.NomorKursi,
                });
            }

            return View("Create", _editPesawatVM);
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View("Create", pEditPesawatVM);
    }

    public IActionResult Create(CreatePesawatViewModel pCreatePesawatVM)
    {
        ViewBag.FormMode = "Create";
        return View("Create", pCreatePesawatVM);
    }

    [HttpPost]
    public IActionResult Update(CreatePesawatViewModel pEditPesawatVM)
    {
        try
        {
            ViewBag.FormMode = "Edit";
            var _actionType = pEditPesawatVM.ActionType;
            if (_actionType == "AddKursi")
            {
                return View("Create", _addKursi(pEditPesawatVM));
            }
            else
            {
                _setLoginID();
                var _kursiPesawats = _mappingKursiPesawatsFromViewModel(pEditPesawatVM.KursiPesawats);

                PesawatService _pesawatService = new PesawatService(_db, _loginID);
                _pesawatService.UpdatePesawat(pEditPesawatVM.KodePenerbangan,
                    pEditPesawatVM.KodeJenisPesawat,
                    pEditPesawatVM.KodeMaskapai,
                    _kursiPesawats);


                var _listPesawatVM = new ListPesawatsViewModel()
                {
                    Message = "Data sudah diubah",
                    t = pEditPesawatVM.t,
                };
                return RedirectToAction("List", _listPesawatVM);
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View("Create", pEditPesawatVM);
    }


    private List<KursiPesawatModel> _mappingKursiPesawatsFromViewModel(List<EditKursiPesawatViewModel> pKursiPesawats)
    {
        var _gateways = new List<KursiPesawatModel>();
        foreach (var g in pKursiPesawats)
        {
            _gateways.Add(new KursiPesawatModel()
            {
                NomorKursi = g.NomorKursi,
            });
        }

        return _gateways;
    }

    private CreatePesawatViewModel _addKursi(CreatePesawatViewModel pCreatePesawatVM)
    {
        if (string.IsNullOrEmpty(pCreatePesawatVM.NomorKursi))
        {
            throw new Exception("Nomor Gate perlu diisi");
        }

        if (string.IsNullOrEmpty(pCreatePesawatVM.NomorKursi))
        {
            throw new Exception("Nomor Gate perlu diisi");
        }

        pCreatePesawatVM.KursiPesawats.Add(new EditKursiPesawatViewModel()
        {
            NomorKursi = pCreatePesawatVM.NomorKursi,
        });
        pCreatePesawatVM.NomorKursi = "";
        return pCreatePesawatVM; 
    }
    
    [HttpPost]
    public IActionResult Insert(CreatePesawatViewModel pCreatePesawatVM)
    {
        try
        {
            ViewBag.FormMode = "Create";
            var _actionType = pCreatePesawatVM.ActionType;
            if (_actionType == "AddKursi")
            {
                return View("Create", _addKursi(pCreatePesawatVM));
            }
            else
            {
                _setLoginID();
                PesawatService _pesawatService = new PesawatService(_db, _loginID);

                var _kursiPesawats = _mappingKursiPesawatsFromViewModel(pCreatePesawatVM.KursiPesawats);
                _pesawatService.AddPesawat(pCreatePesawatVM.KodePenerbangan,
                    pCreatePesawatVM.KodeJenisPesawat,
                    pCreatePesawatVM.KodeMaskapai,
                    _kursiPesawats
                );
                
                var _listPesawatVM = new ListPesawatsViewModel()
                {
                    Message = "Data sudah tersimpan",
                    t = pCreatePesawatVM.t,
                };
                return RedirectToAction("List", _listPesawatVM);
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View("Create", pCreatePesawatVM);
    }


    [HttpPost]
    public IActionResult Delete(DeletePesawatViewModel pDeletePesawatVM)
    {
        ListPesawatsViewModel _listPesawatVM = new ListPesawatsViewModel();
        _listPesawatVM.t = pDeletePesawatVM.t;
        try
        {
            if (ModelState.IsValid)
            {
                _setLoginID();
                PesawatService _pesawatService = new PesawatService(_db, _loginID);
                _pesawatService.DeletePesawat(pDeletePesawatVM.KodePenerbangan);

                _listPesawatVM.Message = "Data sudah dihapus";
                return RedirectToAction("List", _listPesawatVM);
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View("List", _listPesawatVM);
    }

    public IActionResult List(ListPesawatsViewModel pListPesawatVM)
    {
        try
        {
            _setLoginID();
            PesawatService _pesawatService = new PesawatService(_db, _loginID);
            var _pesawats = _pesawatService.FindList();

            var _listPesawatVM = new ListPesawatsViewModel();
            _listPesawatVM.UpdateTokenAndMessage(pListPesawatVM.t, pListPesawatVM.Message);

            if (_pesawats != null && _pesawats.Count > 0)
            {
                foreach (var _pesawat in _pesawats)
                {
                    _listPesawatVM.Pesawats.Add(
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

            return View("List", _listPesawatVM);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return View("List", pListPesawatVM);
    }
}