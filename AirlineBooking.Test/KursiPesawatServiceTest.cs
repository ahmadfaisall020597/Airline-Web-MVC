using Xunit;
using AirlineBooking.Services;
using AirlineBooking.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace AirlineBooking.Test
{
    public class KursiPesawatServiceTest
    {


        [Fact]
        public void TestKursiPesawat_NormalTest()
        {

            var dbOption = new DbContextOptionsBuilder<AirlineBookingDbContext>()
                .UseSqlServer(TestVars.ConnectionString)
                .Options;

            using (var _db = new Models.AirlineBookingDbContext(dbOption))
            {
                KursiPesawatService _kursiPesawatService = new KursiPesawatService(_db);
                _kursiPesawatService.Migrate();

                var _kodePenerbangan = "JT619";
                var _nomorKursi = "1A";

                var _idKursi = _kursiPesawatService.AddKursiPesawat(_kodePenerbangan, _nomorKursi);

                var _fKursiPesawat = _kursiPesawatService.FindKursiByID(_idKursi);
                Assert.NotNull(_fKursiPesawat);
                if (_fKursiPesawat != null)
                {
                    Assert.Equal(_kodePenerbangan, _fKursiPesawat.KodePenerbangan);
                    Assert.Equal(_nomorKursi, _fKursiPesawat.NomorKursi);                    
                }
            }
        }




        [Fact]
        public void TestKursiPesawat_SeedingKursiPesawats()
        {

            var dbOption = new DbContextOptionsBuilder<AirlineBookingDbContext>()
                .UseSqlServer(TestVars.ConnectionString)
                .Options;

            using (var _db = new Models.AirlineBookingDbContext(dbOption))
            {

                KursiPesawatService _jenis_pesawatService = new KursiPesawatService(_db);
                _jenis_pesawatService.Migrate();

                Models.KursiPesawatModel[] _jenis_pesawats = new Models.KursiPesawatModel[]
                {
                    new KursiPesawatModel("JT619", "1A"),
                    new KursiPesawatModel("JT619", "1B"),
                    new KursiPesawatModel("JT619", "1C"),
                    new KursiPesawatModel("JT619", "1D"),
                    new KursiPesawatModel("JT619", "1E"),
                    new KursiPesawatModel("JT619", "1F"),

                    new KursiPesawatModel("JT619", "2A"),
                    new KursiPesawatModel("JT619", "2B"),
                    new KursiPesawatModel("JT619", "2C"),
                    new KursiPesawatModel("JT619", "2D"),
                    new KursiPesawatModel("JT619", "2E"),
                    new KursiPesawatModel("JT619", "2F"),


                    new KursiPesawatModel("JT620", "1A"),
                    new KursiPesawatModel("JT620", "1B"),
                    new KursiPesawatModel("JT620", "1C"),

                };

                for (int i = 0; i < _jenis_pesawats.Length; i++)
                {
                    var _jenis_pesawat = _jenis_pesawats[i];
                    var _kodePenerbangan = _jenis_pesawat.KodePenerbangan;
                    var _nomorKursi = _jenis_pesawat.NomorKursi;

                    var _idKursi = _jenis_pesawatService.AddKursiPesawat(_kodePenerbangan, _nomorKursi);

                    var _fKursiPesawat = _jenis_pesawatService.FindKursiByID(_idKursi);
                    Assert.NotNull(_fKursiPesawat);
                    if (_fKursiPesawat != null)
                    {
                        Assert.Equal(_kodePenerbangan, _fKursiPesawat.KodePenerbangan);
                        Assert.Equal(_nomorKursi, _fKursiPesawat.NomorKursi);

                    }

                }

            }
        }

    }
}
