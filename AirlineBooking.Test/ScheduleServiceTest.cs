using Xunit;
using AirlineBooking.Services;
using AirlineBooking.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;


namespace AirlineBooking.Test
{
    /*
     * developer new project
     * developer maintenance project
     * QA Developer / Test Developer
     * Lead Technical 
     */
    public class ScheduleServiceTest
    {
        /*
         * Negative Test / False Test
         * 
         */
        [Fact]
        public void TestSchedule_NegativeTest()
        {

            ScheduleService _scheduleService = new ScheduleService(null);

            string _kodeMaskapai = "";
            string _kodePenerbangan = "";
            string _kodeAirportAsal = "";
            string _kodeAirportTujuan = "";
            string _tglKeberangkatan = "";
          
            string _tglKedatangan = "";
         
            int _batasBagasi = -1;
            int _batasBagasiKabin = -1;
            decimal _hargaTiket = -1;


            try
            {
                _scheduleService.TambahSchedule(_kodeMaskapai,
                    _kodePenerbangan,
                    _kodeAirportAsal,
                    _kodeAirportTujuan,
                    _tglKeberangkatan,                    
                    _tglKedatangan,                    
                    _batasBagasi,
                    _batasBagasiKabin,
                    _hargaTiket);
            }
            catch (Exception ex)
            {
                Assert.Equal("kode_maskapai_kosong", ex.Message);
            }


            _kodeMaskapai = "LR/LNI";
            try
            {
                _scheduleService.TambahSchedule(_kodeMaskapai,
                   _kodePenerbangan,
                   _kodeAirportAsal,
                   _kodeAirportTujuan,
                   _tglKeberangkatan,                   
                   _tglKedatangan,                   
                   _batasBagasi,
                   _batasBagasiKabin,
                    _hargaTiket);
            }
            catch (Exception ex)
            {
                Assert.Equal("kode_penerbangan_kosong", ex.Message);
            }


           
            _kodePenerbangan = "JT619";
            try
            {
                _scheduleService.TambahSchedule(_kodeMaskapai,
                   _kodePenerbangan,
                   _kodeAirportAsal,
                   _kodeAirportTujuan,
                   _tglKeberangkatan,                   
                   _tglKedatangan,                   
                   _batasBagasi,
                   _batasBagasiKabin,
                    _hargaTiket);
            }
            catch (Exception ex)
            {
                Assert.Equal("kode_airport_asal_kosong", ex.Message);
            }



          
            _kodeAirportAsal = "CGK";
            try
            {
                _scheduleService.TambahSchedule(_kodeMaskapai,
                   _kodePenerbangan,
                   _kodeAirportAsal,
                   _kodeAirportTujuan,
                   _tglKeberangkatan,                   
                   _tglKedatangan,                   
                   _batasBagasi,
                   _batasBagasiKabin,
                    _hargaTiket);
            }
            catch (Exception ex)
            {
                Assert.Equal("kode_airport_tujuan_kosong", ex.Message);
            }



        
            _kodeAirportTujuan = "DPS";
            try
            {
                _scheduleService.TambahSchedule(_kodeMaskapai,
                   _kodePenerbangan,
                   _kodeAirportAsal,
                   _kodeAirportTujuan,
                   _tglKeberangkatan,                   
                   _tglKedatangan,                   
                   _batasBagasi,
                   _batasBagasiKabin,
                    _hargaTiket);
            }
            catch (Exception ex)
            {
                Assert.Equal("tgl_keberangkatan_kosong", ex.Message);
            }



            _tglKeberangkatan = "2022-02-24";
           
            try
            {
                _scheduleService.TambahSchedule(_kodeMaskapai,
                   _kodePenerbangan,
                   _kodeAirportAsal,
                   _kodeAirportTujuan,
                   _tglKeberangkatan,                   
                   _tglKedatangan,                   
                   _batasBagasi,
                   _batasBagasiKabin,
                    _hargaTiket);
            }
            catch (Exception ex)
            {
                Assert.Equal("tgl_kedatangan_kosong", ex.Message);
            }



            _tglKedatangan = "2022-02-24";         

            try
            {
                _scheduleService.TambahSchedule(_kodeMaskapai,
                   _kodePenerbangan,
                   _kodeAirportAsal,
                   _kodeAirportTujuan,
                   _tglKeberangkatan,                   
                   _tglKedatangan,                   
                   _batasBagasi,
                   _batasBagasiKabin,
                    _hargaTiket);
            }
            catch (Exception ex)
            {
                Assert.Equal("batas_bagasi_harus_lebih_besar_atau_sama_dengan_nol", ex.Message);
            }


            
            _batasBagasi = 20;
            try
            {
                _scheduleService.TambahSchedule(_kodeMaskapai,
                   _kodePenerbangan,
                   _kodeAirportAsal,
                   _kodeAirportTujuan,
                   _tglKeberangkatan,                   
                   _tglKedatangan,                   
                   _batasBagasi,
                   _batasBagasiKabin,
                    _hargaTiket);
            }
            catch (Exception ex)
            {
                Assert.Equal("batas_bagasi_kabin_harus_lebih_besar_atau_sama_dengan_nol", ex.Message);
            }


            _batasBagasiKabin = 7;
            _tglKeberangkatan = "2022-02-3 25:00";
            try
            {
                _scheduleService.TambahSchedule(_kodeMaskapai,
                  _kodePenerbangan,
                  _kodeAirportAsal,
                  _kodeAirportTujuan,
                  _tglKeberangkatan,                  
                  _tglKedatangan,                  
                  _batasBagasi,
                  _batasBagasiKabin,
                    _hargaTiket);
            }
            catch (Exception ex)
            {
                /*String '2022-02-3' was not recognized as a valid DateTime.*/
                Assert.Contains("was not recognized as a valid DateTime", ex.Message);
            }
                     

            _tglKedatangan = "2022-13-01 :00";
            try
            {
                _scheduleService.TambahSchedule(_kodeMaskapai,
                  _kodePenerbangan,
                  _kodeAirportAsal,
                  _kodeAirportTujuan,
                  _tglKeberangkatan,                  
                  _tglKedatangan,                  
                  _batasBagasi,
                  _batasBagasiKabin,
                    _hargaTiket);
            }
            catch (Exception ex)
            {
                Assert.Contains("was not recognized as a valid DateTime", ex.Message);
            }

        }


        /*Positive Test */

        [Fact]
        public void TestTambahSchedule_PositiveTest()
        {

            var dbOption = new DbContextOptionsBuilder<AirlineBookingDbContext>()
                .UseSqlServer(TestVars.ConnectionString)
                .Options;

            using (var _db = new Models.AirlineBookingDbContext(dbOption))
            {

                ScheduleService _scheduleService = new ScheduleService(_db);
                _scheduleService.Migrate();

                string _kodeMaskapai = "LR/LNI";
                string _kodePenerbangan = "JT619";
                string _kodeAirportAsal = "CGK";
                string _kodeAirportTujuan = "DPS";
                string _tglKeberangkatan = "2022-02-24 08:00 AM";                
                string _tglKedatangan = "2022-02-24 10:00 AM";                
                int _batasBagasi = 20;
                int _batasBagasiKabin = 7;
                decimal _hargaTiket = 370000;


                var _scheduleID = _scheduleService.TambahSchedule(_kodeMaskapai,
                    _kodePenerbangan,
                    _kodeAirportAsal,
                    _kodeAirportTujuan,
                    _tglKeberangkatan,                    
                    _tglKedatangan,                    
                    _batasBagasi,
                    _batasBagasiKabin,
                    _hargaTiket);


                Models.ScheduleModel? _fSchedule = _scheduleService.FindScheduleByID(_scheduleID);
                Assert.NotNull(_fSchedule);

                if (_fSchedule != null)
                {
                    Assert.Equal(_kodeMaskapai, _fSchedule.KodeMaskapai);
                    Assert.Equal(_kodePenerbangan, _fSchedule.KodePenerbangan);
                    Assert.Equal(_kodeAirportAsal, _fSchedule.KodeAirportAsal);
                    Assert.Equal(_kodeAirportTujuan, _fSchedule.KodeAirportTujuan);

                    Assert.Equal(_tglKeberangkatan, _fSchedule.TglKeberangkatan.ToString("yyyy-MM-dd hh:mm tt"));
                    Assert.Equal(_tglKedatangan, _fSchedule.TglKedatangan.ToString("yyyy-MM-dd hh:mm tt"));                    

                    Assert.Equal(_batasBagasi, _fSchedule.BatasBagasi);
                    Assert.Equal(_batasBagasiKabin, _fSchedule.BatasBagasiKabin);

                    Assert.Equal(_hargaTiket, _fSchedule.HargaTiket);

                }

            }

        }


        [Fact]
        public void TestTambahSchedule_SeedingSchedules()
        {
            var dbOption = new DbContextOptionsBuilder<AirlineBookingDbContext>()
                .UseSqlServer(TestVars.ConnectionString)
                .Options;

            using (var _db = new Models.AirlineBookingDbContext(dbOption))
            {

                ScheduleService _scheduleService = new ScheduleService(_db);
                _scheduleService.Migrate();

                List<ScheduleModel> _schedules = new List<ScheduleModel>();
                _schedules.Add(new ScheduleModel()
                {
                    KodeMaskapai = "LR/JNI",
                    KodePenerbangan = "JT619",
                    KodeAirportAsal = "CGK",
                    KodeAirportTujuan = "DPS",
                    StrTglKeberangkatan = "2022-03-04 08:00 AM",
                    StrTglKedatangan = "2022-03-04 10:00 AM",
                    BatasBagasi = 20,
                    BatasBagasiKabin = 7,
                    HargaTiket = 375000
                });

                _schedules.Add(new ScheduleModel()
                {
                    KodeMaskapai = "LR/JNI",
                    KodePenerbangan = "JT619",
                    KodeAirportAsal = "CGK",
                    KodeAirportTujuan = "DPS",
                    StrTglKeberangkatan = "2022-03-04 10:30 AM",
                    StrTglKedatangan = "2022-03-04 12:00 AM",
                    BatasBagasi = 20,
                    BatasBagasiKabin = 7,
                    HargaTiket = 475000
                });


                for (int i = 0; i < _schedules.Count; i++)
                {

                    var _schedule = _schedules[i];
                    var _kodeMaskapai = _schedule.KodeMaskapai;
                    var _kodePenerbangan = _schedule.KodePenerbangan;
                    var _kodeAirportAsal = _schedule.KodeAirportAsal;
                    var _kodeAirportTujuan = _schedule.KodeAirportTujuan;
                    var _tglKeberangkatan = _schedule.StrTglKeberangkatan;
                    var _tglKedatangan = _schedule.StrTglKedatangan;
                    var _batasBagasi = _schedule.BatasBagasi;
                    var _batasBagasiKabin = _schedule.BatasBagasiKabin;
                    var _hargaTiket = _schedule.HargaTiket;

                    var _scheduleID = _scheduleService.TambahSchedule(_kodeMaskapai,
                   _kodePenerbangan,
                   _kodeAirportAsal,
                   _kodeAirportTujuan,
                   _tglKeberangkatan,
                   _tglKedatangan,
                   _batasBagasi,
                   _batasBagasiKabin,
                   _hargaTiket);


                    Models.ScheduleModel? _fSchedule = _scheduleService.FindScheduleByID(_scheduleID);
                    Assert.NotNull(_fSchedule);

                    if (_fSchedule != null)
                    {
                        Assert.Equal(_kodeMaskapai, _fSchedule.KodeMaskapai);
                        Assert.Equal(_kodePenerbangan, _fSchedule.KodePenerbangan);
                        Assert.Equal(_kodeAirportAsal, _fSchedule.KodeAirportAsal);
                        Assert.Equal(_kodeAirportTujuan, _fSchedule.KodeAirportTujuan);

                        Assert.Equal(_tglKeberangkatan, _fSchedule.TglKeberangkatan.ToString("yyyy-MM-dd hh:mm tt"));
                        Assert.Equal(_tglKedatangan, _fSchedule.TglKedatangan.ToString("yyyy-MM-dd hh:mm tt"));

                        Assert.Equal(_batasBagasi, _fSchedule.BatasBagasi);
                        Assert.Equal(_batasBagasiKabin, _fSchedule.BatasBagasiKabin);
                        Assert.Equal(_hargaTiket, _fSchedule.HargaTiket);

                    }

                }


            }


        }


    }
}