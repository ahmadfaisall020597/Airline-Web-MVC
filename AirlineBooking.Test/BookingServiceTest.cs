using Xunit;
using AirlineBooking.Services;
using AirlineBooking.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;


namespace AirlineBooking.Test
{
    public class BookingServiceTest
    {
        /*
         * Negative Test / False Test
         * 
         */
        [Fact]
        public void TestBookingService_NegativeTest()
        {
            BookingService _bookingService = new BookingService(null);
            try
            {
                _bookingService.NewBooking(0, null);
            }
            catch (Exception ex)
            {
                Assert.Equal("invalid_schedule_id", ex.Message);
            }
            try
            {
                _bookingService.NewBooking(1, null);
            }
            catch (Exception ex)
            {
                Assert.Equal("penumpang_harus_diisi", ex.Message);
            }
        }


        /*Positive Test */
        [Fact]
        public void TestBookingService_NormalTest()
        {


            var dbOption = new DbContextOptionsBuilder<AirlineBookingDbContext>()
                .UseSqlServer(TestVars.ConnectionString)
                .Options;

            using (var _db = new Models.AirlineBookingDbContext(dbOption))
            {

                BookingService _bookingService = new BookingService(_db);
                _bookingService.Migrate();

                long _scheduleID = 1;    
                
                List<Models.BookingPenumpangModel> _penumpangs = new List<Models.BookingPenumpangModel>();
                _penumpangs.Add(new Models.BookingPenumpangModel("10401777777", "Mr", "Fathan"));
                _penumpangs.Add(new Models.BookingPenumpangModel("10401777778", "Mr", "Susanto"));

                var _kodeBooking = _bookingService.NewBooking(_scheduleID, _penumpangs);

                var _booking = _bookingService.FindByKodeBooking(_kodeBooking);
                Assert.NotNull(_booking);
                if(_booking!=null)
                {
                    ScheduleService _scheduleService = new ScheduleService(_db);
                    var _schedule = _scheduleService.FindScheduleByID(_scheduleID);

                    Assert.Equal(_schedule.KodeMaskapai, _booking.KodeMaskapai);
                    Assert.Equal(_schedule.KodePenerbangan, _booking.KodePenerbangan);
                    Assert.Equal(_schedule.KodeAirportAsal, _booking.KodeAirportAsal);
                    Assert.Equal(_schedule.KodeAirportTujuan, _booking.KodeAirportTujuan);
                    Assert.Equal(_schedule.TglKeberangkatan, _booking.TglKeberangkatan);
                    Assert.Equal(_schedule.TglKedatangan, _booking.TglKedatangan);
                    Assert.Equal(_schedule.BatasBagasi, _booking.BatasBagasi);
                    Assert.Equal(_schedule.BatasBagasiKabin, _booking.BatasBagasiKabin);

                    Assert.Equal(_schedule.HargaTiket, _booking.HargaTiket);
                    Assert.Equal(_penumpangs.Count, _booking.JumlahPenumpang);
                    Assert.Equal(BookingService.BOOKING_STATUS_BOOKED, _booking.StatusBooking);

                    Assert.Equal(_schedule.HargaTiket * _penumpangs.Count, _booking.Total);

                    for ( int i = 0; i < _penumpangs.Count; i++)
                    {
                        var _bp = _booking.Penumpangs[i];
                        var _p = _penumpangs[i];

                        Assert.Equal(_p.KTP, _bp.KTP);
                        Assert.Equal(_p.NamaPenumpang, _bp.NamaPenumpang);
                        Assert.Equal(_p.Title, _bp.Title);

                    }
                }

                var _methodBayar = BookingService.METHOD_BAYAR_CASH;
                decimal _jumlahBayar = 750000;

                var _kodePembayaran = _bookingService.Pay(_kodeBooking, _methodBayar, _jumlahBayar);
                _booking = _bookingService.FindByKodeBooking(_kodeBooking);
                Assert.NotNull(_booking);
                if (_booking != null)
                {
                    Assert.Equal(_methodBayar, _booking.MetodeBayar);
                    Assert.Equal(_jumlahBayar, _booking.JumlahBayar);
                    Assert.Equal(BookingService.BOOKING_STATUS_PAID, _booking.StatusBooking);
                }


                _booking.Penumpangs[0].NomorKursi = "1A";
                _booking.Penumpangs[1].NomorKursi = "1B";
                
                _ = _bookingService.CheckIn(_kodeBooking, _booking.Penumpangs);


                var _booking2 = _bookingService.FindByKodeBooking(_kodeBooking);
                Assert.NotNull(_booking);
                if (_booking != null)
                {
                    Assert.Equal(_booking.Penumpangs[0].NomorKursi, _booking2.Penumpangs[0].NomorKursi);
                    Assert.Equal(_booking.Penumpangs[1].NomorKursi, _booking2.Penumpangs[1].NomorKursi);

                    Assert.Equal(BookingService.BOOKING_STATUS_CHECKED_IN, _booking.StatusBooking);
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