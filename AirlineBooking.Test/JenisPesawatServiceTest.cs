using Xunit;
using AirlineBooking.Services;
using AirlineBooking.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace AirlineBooking.Test
{
    public class JenisPesawatServiceTest
    {

        [Fact]
        public void TestJenisPesawat_NormalTest()
        {

            var dbOption = new DbContextOptionsBuilder<AirlineBookingDbContext>()
                .UseSqlServer(TestVars.ConnectionString)
                .Options;

            using (var _db = new Models.AirlineBookingDbContext(dbOption))
            {

                JenisPesawatService _jenis_pesawatService = new JenisPesawatService(_db);
                _jenis_pesawatService.Migrate();

                var _kodeJenisPesawat = "BOEING-737";
                var _tahunPesawat = 2000;

                _jenis_pesawatService.AddJenisPesawat(_kodeJenisPesawat, _tahunPesawat);

                var _fJenisPesawat = _jenis_pesawatService.FindJenisPesawatByKodeJenisPesawat(_kodeJenisPesawat, true);
                Assert.NotNull(_fJenisPesawat);
                if (_fJenisPesawat != null)
                {
                    Assert.Equal(_kodeJenisPesawat, _fJenisPesawat.KodeJenisPesawat);
                    Assert.Equal(_tahunPesawat, _fJenisPesawat.TahunPesawat);                    
                }
            }
        }




        [Fact]
        public void TestJenisPesawat_SeedingJenisPesawats()
        {

            var dbOption = new DbContextOptionsBuilder<AirlineBookingDbContext>()
                .UseSqlServer(TestVars.ConnectionString)
                .Options;

            using (var _db = new Models.AirlineBookingDbContext(dbOption))
            {

                JenisPesawatService _jenis_pesawatService = new JenisPesawatService(_db);
                _jenis_pesawatService.Migrate();

                Models.JenisPesawatModel[] _jenis_pesawats = new Models.JenisPesawatModel[]
                {
                    new JenisPesawatModel("BOEING-737", 2000),
                    new JenisPesawatModel("BOEING-747", 2000),
                    new JenisPesawatModel("AIRBUS-A320", 2000),
                    new JenisPesawatModel("AIRBUS-A330", 2000),

                };

                for (int i = 0; i < _jenis_pesawats.Length; i++)
                {
                    var _jenis_pesawat = _jenis_pesawats[i];
                    var _kodeJenisPesawat = _jenis_pesawat.KodeJenisPesawat;
                    var _tahunPesawat = _jenis_pesawat.TahunPesawat;

                    _jenis_pesawatService.AddJenisPesawat(_kodeJenisPesawat, _tahunPesawat);

                    var _fJenisPesawat = _jenis_pesawatService.FindJenisPesawatByKodeJenisPesawat(_kodeJenisPesawat, true);
                    Assert.NotNull(_fJenisPesawat);
                    if (_fJenisPesawat != null)
                    {
                        Assert.Equal(_kodeJenisPesawat, _fJenisPesawat.KodeJenisPesawat);
                        Assert.Equal(_tahunPesawat, _fJenisPesawat.TahunPesawat);

                    }

                }

            }
        }

    }
}
