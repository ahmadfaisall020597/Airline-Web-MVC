using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace AirlineBooking.Services
{
    public class BookingService : BaseService
    {

        
        public const int BOOKING_STATUS_BOOKED = 1;
        public const int BOOKING_STATUS_PAID = 2;
        public const int BOOKING_STATUS_CHECKED_IN = 3;


        public const int METHOD_BAYAR_CREDIT_CARD = 1;
        public const int METHOD_BAYAR_CASH = 2;
        public const int METHOD_BAYAR_TRANSFER = 3;


        public BookingService(Models.AirlineBookingDbContext db) :base (db) { }

        public void Migrate()
        {

            var _dbConn = _db.Database.GetDbConnection();
            _dbConn.Open();
            var _cmd = _dbConn.CreateCommand();
            _cmd.CommandText = "TRUNCATE TABLE booking;";
            _cmd.CommandType = System.Data.CommandType.Text;
            _cmd.ExecuteNonQuery();

            _cmd = _dbConn.CreateCommand();
            _cmd.CommandText = "TRUNCATE TABLE booking_penumpang;";
            _cmd.CommandType = System.Data.CommandType.Text;
            _cmd.ExecuteNonQuery();

            _dbConn.Close();
        }

        private string createKodeBooking()
        {
            return Helpers.IDHelper.ID().ToString();
        }

        public Models.BookingModel FindByKodeBooking (string kodeBooking)
        {

            var _booking = _db.Bookings.Where(x => x.KodeBooking.ToLower().Equals(kodeBooking.ToLower()))
                .Include("Penumpangs")
                .FirstOrDefault();
            if (_booking == null)
            {
                throw new Exception("booking_not_found");
            }

            return _booking;
        }

        public string NewBooking(long scheduleID, List<Models.BookingPenumpangModel> penumpangs)
        {           

            if (scheduleID <= 0)
            {
                throw new Exception("invalid_schedule_id");
            }

            if(penumpangs == null)
            {
                throw new Exception("penumpang_harus_diisi");
            }
            foreach(var p in penumpangs) {
                if (p.KTP =="")
                {
                    throw new Exception("ktp_invalid");
                }
                if(p.NamaPenumpang == "")
                {
                    throw new Exception("nama_penumpang_harus_diisi");
                }
                if(p.Title == "")
                {
                    throw new Exception("title_harus_diisi");
                }
            }


            var _schedule = _db.Schedules
                .Include(x=>x.AirportAsal)
                .Include(x=>x.AirportTujuan)
                .Include(x => x.Maskapai)
                .FirstOrDefault(s => s.ScheduleID == scheduleID);  

            if(_schedule == null)
            {
                throw new Exception("schedule_not_found");
            }


            var _booking = new Models.BookingModel();
            _booking.KodeBooking = createKodeBooking();

            _booking.KodeAirportAsal = _schedule.KodeAirportAsal;
            _booking.NamaAirportAsal = _schedule.AirportAsal.NamaAirport;

            _booking.KodeAirportTujuan = _schedule.KodeAirportTujuan;
            _booking.NamaAirportTujuan = _schedule.AirportTujuan.NamaAirport;

            _booking.TglKeberangkatan = _schedule.TglKeberangkatan;
            _booking.TglKedatangan = _schedule.TglKedatangan;
            _booking.Durasi =  _schedule.TglKedatangan.Subtract(_schedule.TglKeberangkatan).TotalHours;

            _booking.KodeMaskapai = _schedule.KodeMaskapai;
            _booking.NamaMaskapai = _schedule.Maskapai.NamaMaskapai;

            _booking.KodePenerbangan = _schedule.KodePenerbangan;
            _booking.BatasBagasi = _schedule.BatasBagasi;
            _booking.BatasBagasiKabin = _schedule.BatasBagasiKabin;

            _booking.HargaTiket = _schedule.HargaTiket;
            _booking.JumlahPenumpang = penumpangs.Count;
            _booking.Total = _booking.HargaTiket * _booking.JumlahPenumpang;

            _booking.StatusBooking = BOOKING_STATUS_BOOKED;

            _db.Bookings.Add(_booking);


            foreach(var p in penumpangs)
            {
                var _penumpang = new Models.BookingPenumpangModel();
                _penumpang.KodeBooking = _booking.KodeBooking;
                _penumpang.KTP = p.KTP;
                _penumpang.Title = p.Title;
                _penumpang.NamaPenumpang = p.NamaPenumpang;
                _db.BookingPenumpangs.Add(_penumpang);

            }

            _db.SaveChanges();
            return _booking.KodeBooking;



        }

        public string Pay(string kodeBooking,
            int metodeBayar,
            decimal jumlahBayar)
        {
            if(string.IsNullOrEmpty(kodeBooking))
            {
                throw new Exception("invalid_kode_booking");
            }

            if(metodeBayar <=0)
            {
                throw new Exception("invalid_metode_bayar");
            }
            if(jumlahBayar <=0)
            {
                throw new Exception("jumlah_bayar_harus_lebih_besar_dari_nol");
            }

            var _booking = FindByKodeBooking(kodeBooking);
            if(_booking!=null)
            {
                if(jumlahBayar < _booking.Total)
                {
                    throw new Exception("jumlah_bayar_tidak_valid");
                }

                if(_booking.StatusBooking != BOOKING_STATUS_BOOKED )
                {
                    throw new Exception("cannot_pay_booking");
                }

                _booking.MetodeBayar = metodeBayar;
                _booking.JumlahBayar = jumlahBayar;
                _booking.KodePembayaran = Helpers.IDHelper.ID().ToString();
                _booking.StatusBooking = BOOKING_STATUS_PAID;
                _db.SaveChanges();

                return _booking.KodePembayaran;
            }

            return "";

        }

        public string CheckIn(string kodeBooking,
            List<Models.BookingPenumpangModel> inputPenumpangs)
        {

            if (string.IsNullOrEmpty(kodeBooking))
            {
                throw new Exception("invalid_kode_booking");
            }

            for (int i = 0; i < inputPenumpangs.Count; i++)
            {
                var p = inputPenumpangs[i];
                if (string.IsNullOrEmpty(p.KTP))
                {
                    throw new Exception("invalid_ktp");
                }
                if (string.IsNullOrEmpty(p.NomorKursi))
                {
                    throw new Exception("invalid_nomor_kursi");
                }
            }

            var _booking = FindByKodeBooking(kodeBooking);
            if (_booking != null)
            {
                if (_booking.StatusBooking != BOOKING_STATUS_PAID)
                {
                    throw new Exception("cannot_check_in");
                }

                for (int i = 0; i < inputPenumpangs.Count; i++)
                {
                    var p = inputPenumpangs[i];
                    var _bp = _booking.Penumpangs.Where(x => x.KTP == p.KTP && x.KodeBooking == kodeBooking)
                        .FirstOrDefault();
                    if (_bp != null)
                    {
                        _bp.NomorKursi = p.NomorKursi;
                    }
                }

                _booking.KodeCheckIn = Helpers.IDHelper.ID().ToString();
                _booking.StatusBooking = BOOKING_STATUS_CHECKED_IN;
                _db.SaveChanges();

                return _booking.KodeCheckIn;

            }

            return "";


        }
    }
}
