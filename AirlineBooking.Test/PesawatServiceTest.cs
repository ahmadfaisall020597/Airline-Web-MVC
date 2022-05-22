using Xunit;
using AirlineBooking.Services;
using AirlineBooking.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;


namespace AirlineBooking.Test
{  

    public class PesawatServiceTest
    {
        /*
         * Negative Test / False Test
         * 
         */
        [Fact]
        public void TestPesawat_NegativeTest()
        {

            PesawatService _scheduleService = new PesawatService(null);


            try
            {
                _scheduleService.AddPesawat("",
                    "",
                    "");
            }
            catch (Exception ex)
            {
                Assert.Equal("kode_penerbangan_kosong", ex.Message);
            }

            try
            {
                _scheduleService.AddPesawat("JT900",
                    "",
                    "");
            }
            catch (Exception ex)
            {
                Assert.Equal("kode_jenis_pesawat", ex.Message);
            }

            try
            {
                _scheduleService.AddPesawat("JT900",
                    "BOEING-737",
                    "");
            }
            catch (Exception ex)
            {
                Assert.Equal("kode_maskapai", ex.Message);
            }

        }


        /*Positive Test */

        [Fact]
        public void TestTambahPesawat_PositiveTest()
        {

            var dbOption = new DbContextOptionsBuilder<AirlineBookingDbContext>()
                .UseSqlServer(TestVars.ConnectionString)
                .Options;

            using (var _db = new Models.AirlineBookingDbContext(dbOption))
            {

                PesawatService _pesawatService = new PesawatService(_db);
                _pesawatService.Migrate();

                string _kodePenerbangan = "JT619";
                string _kodeMaskapai = "LR/LNI";
                string _kodeJenisPesawat = "BOEING-737";
                
                _pesawatService.AddPesawat(_kodePenerbangan,
                    _kodeJenisPesawat,
                    _kodeMaskapai);



                Models.PesawatModel? _fPesawat = _pesawatService.FindByKodePenerbangan(_kodePenerbangan);
                Assert.NotNull(_fPesawat);

                if (_fPesawat != null)
                {
                    Assert.Equal(_kodePenerbangan, _fPesawat.KodePenerbangan);
                    Assert.Equal(_kodeJenisPesawat, _fPesawat.KodeJenisPesawat);
                    Assert.Equal(_kodeMaskapai, _fPesawat.KodeMaskapai);
                }


                List<PesawatModel> _pesawats = _pesawatService.FindList();
                Assert.Equal(1, _pesawats.Count);


                _kodeMaskapai = "LR/LNII";
                _kodeJenisPesawat = "BOEING-777";

                _pesawatService.UpdatePesawat(_kodePenerbangan,
                    _kodeJenisPesawat,
                    _kodeMaskapai);

                _fPesawat = _pesawatService.FindByKodePenerbangan(_kodePenerbangan);
                Assert.NotNull(_fPesawat);

                if (_fPesawat != null)
                {
                    Assert.Equal(_kodePenerbangan, _fPesawat.KodePenerbangan);
                    Assert.Equal(_kodeJenisPesawat, _fPesawat.KodeJenisPesawat);
                    Assert.Equal(_kodeMaskapai, _fPesawat.KodeMaskapai);
                }

            }

        }

        [Fact]
        public void TestPesawatService_SeedingPesawats()
        {

            var dbOption = new DbContextOptionsBuilder<AirlineBookingDbContext>()
                .UseSqlServer(TestVars.ConnectionString)
                .Options;

            using (var _db = new Models.AirlineBookingDbContext(dbOption))
            {

                PesawatService _pesawatService = new PesawatService(_db);
                _pesawatService.Migrate();

                Models.PesawatModel[] _pesawats = new PesawatModel[]
                {
                    new PesawatModel("JT123", "AIRBUS-A320", "GA/GIA"),
                    new PesawatModel("JT124", "AIRBUS-A330", "ID/BTK"),
                    new PesawatModel("JT619", "BOEING-737", "LR/JNI"),
                    new PesawatModel("JT126", "BOEING-747", "QG/CTV"),
                    new PesawatModel("JT127", "BOEING-747", "SJ/SJY"),
                    new PesawatModel("JT128", "BOEING-747", "TEST"),
                    new PesawatModel("JT129", "BOEING-757", "TEST"),
                };

                for(int i = 0; i < _pesawats.Length; i++)
                {
                    _pesawatService.AddPesawat(_pesawats[i].KodePenerbangan,
                        _pesawats[i].KodeJenisPesawat,
                        _pesawats[i].KodeMaskapai);

                    Models.PesawatModel? _fPesawat = _pesawatService.FindByKodePenerbangan(_pesawats[i].KodePenerbangan);
                    Assert.NotNull(_fPesawat);

                    if (_fPesawat != null)
                    {
                        Assert.Equal(_pesawats[i].KodePenerbangan, _fPesawat.KodePenerbangan);
                        Assert.Equal(_pesawats[i].KodeJenisPesawat, _fPesawat.KodeJenisPesawat);
                        Assert.Equal(_pesawats[i].KodeMaskapai, _fPesawat.KodeMaskapai);
                    }
                }

            }

        }

    }
}