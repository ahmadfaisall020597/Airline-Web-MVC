using Xunit;
using AirlineBooking.Services;
using AirlineBooking.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;


namespace AirlineBooking.Test
{
    public class MaskapaiServiceTest
    {
        [Fact]
        public void TestMaskapai_NormalTest()
        {

           var dbOption = new DbContextOptionsBuilder<AirlineBookingDbContext>()
                .UseSqlServer(TestVars.ConnectionString)
                .Options;

            using (var _db = new Models.AirlineBookingDbContext(dbOption))
            {

                MaskapaiService _maskapaiService = new MaskapaiService(_db, TestVars.LoginEmail);
                _maskapaiService.Migrate();

                var _kodeMaskapai = "LR/JNI";
                var _namaMaskapai = "Lion Air";

                _maskapaiService.AddMaskapai(_kodeMaskapai, _namaMaskapai);

                var _fMaskapai = _maskapaiService.FindMaskapaiByKodeMaskapai(_kodeMaskapai, true);
                Assert.NotNull(_fMaskapai);
                if (_fMaskapai != null)
                {
                    Assert.Equal(_kodeMaskapai, _fMaskapai.KodeMaskapai);
                    Assert.Equal(_namaMaskapai, _fMaskapai.NamaMaskapai);                    
                }
            }
        }




        [Fact]
        public void TestMaskapai_SeedingMaskapais()
        {

            var dbOption = new DbContextOptionsBuilder<AirlineBookingDbContext>()
                 .UseSqlServer(TestVars.ConnectionString)
                 .Options;

            using (var _db = new Models.AirlineBookingDbContext(dbOption))
            {

                MaskapaiService _maskapaiService = new MaskapaiService(_db, TestVars.LoginEmail);
                _maskapaiService.Migrate();

                Models.MaskapaiModel[] _maskapais = new Models.MaskapaiModel[]
                {
                    new MaskapaiModel("LR/JNI", "LION AIR"),
                    new MaskapaiModel("QG/CTV", "CITILINK"),
                    new MaskapaiModel("GA/GIA", "GARUDA INDONESIA"),
                    new MaskapaiModel("ID/BTK", "BATIK AIR"),
                    new MaskapaiModel("SJ/SJY", "SRIWIJAYA AIR")
                    
                };

                for (int i = 0; i < _maskapais.Length; i++)
                {
                    var _maskapai = _maskapais[i];
                    var _kodeMaskapai = _maskapai.KodeMaskapai;
                    var _namaMaskapai = _maskapai.NamaMaskapai;               

                    _maskapaiService.AddMaskapai(_kodeMaskapai, _namaMaskapai);

                    var _fMaskapai = _maskapaiService.FindMaskapaiByKodeMaskapai(_kodeMaskapai, true);
                    Assert.NotNull(_fMaskapai);
                    if (_fMaskapai != null)
                    {
                        Assert.Equal(_kodeMaskapai, _fMaskapai.KodeMaskapai);
                        Assert.Equal(_namaMaskapai, _fMaskapai.NamaMaskapai);
                        
                    }
                }


            }
        }

    }
}
