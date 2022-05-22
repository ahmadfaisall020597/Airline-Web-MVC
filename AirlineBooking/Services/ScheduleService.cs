using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace AirlineBooking.Services
{
    public class ScheduleService : BaseService
    {

        private CultureInfo _cultureInfo;


        /*Constructors*/
        public ScheduleService(Models.AirlineBookingDbContext db, string loginID):base(db, loginID)
        {   
            _cultureInfo = CultureInfo.InvariantCulture;
        }
      
        public void Migrate()
        {
            var _dbConn = _db.Database.GetDbConnection();
            _dbConn.Open();
            var _cmd = _dbConn.CreateCommand();
            _cmd.CommandText = "TRUNCATE TABLE schedule;";
            _cmd.CommandType = System.Data.CommandType.Text;
            _cmd.ExecuteNonQuery();
            _dbConn.Close();   
            
        }

        private DateTime[] parseTglJamKeberangkatanKedatangan(string tglJamKeberangkatan,            
            string tglJamKedatangan)
        {
            DateTime[] result = new DateTime[4];

            //_jamKedatangan
            result[0] = DateTime.ParseExact(tglJamKeberangkatan, "yyyy-MM-dd HH:mm", _cultureInfo);            
            result[1] = DateTime.ParseExact(tglJamKedatangan, "yyyy-MM-dd HH:mm", _cultureInfo);
            return result;
        }

        private void validateBase(string kodeMaskapai,
            string kodePenerbangan,
            string kodeAirportAsal,
            string kodeAirportTujuan,
            string tglKeberangkatan,
            /*string jamKeberangkatan,*/

            string tglKedatangan,
            /*string jamKedatangan,*/

            int batasBagasi,
            int batasBagasiKabin,
            decimal hargaTiket) {


            if(string.IsNullOrEmpty(kodeMaskapai))
            {
                throw new Exception("kode_maskapai_kosong");
            }

            if (string.IsNullOrEmpty(kodePenerbangan))
            {
                throw new Exception("kode_penerbangan_kosong");
            }
            if (string.IsNullOrEmpty(kodeAirportAsal))
            {
                throw new Exception("kode_airport_asal_kosong");
            }
            if (string.IsNullOrEmpty(kodeAirportTujuan))
            {
                throw new Exception("kode_airport_tujuan_kosong");
            }
            if (string.IsNullOrEmpty(tglKeberangkatan))
            {
                throw new Exception("tgl_keberangkatan_kosong");
            }          
            if (string.IsNullOrEmpty(tglKedatangan))
            {
                throw new Exception("tgl_kedatangan_kosong");
            }
            if(batasBagasi <0)
            {
                throw new Exception("batas_bagasi_harus_lebih_besar_atau_sama_dengan_nol");
            }
            if (batasBagasiKabin < 0)
            {
                throw new Exception("batas_bagasi_kabin_harus_lebih_besar_atau_sama_dengan_nol");
            }
            if (hargaTiket < 0)
            {
                throw new Exception("harga tiket harus lebih besar atau sama dengan nol");
            }

        }

        private void validateID(long scheduleID)
        {
            if(scheduleID==0)
            {
                throw new Exception("invalid_schedule_id");
            }
        }

        private void setValue(ref Models.ScheduleModel _schedule,
            string kodeMaskapai,
            string kodePenerbangan,
            string kodeAirportAsal,
            string kodeAirportTujuan,
            DateTime tglKeberangkatan,       
            DateTime tglKedatangan,            

            int batasBagasi,
            int batasBagasiKabin,
            
            decimal hargaTiket)

        {
            _schedule.KodeMaskapai = kodeMaskapai;
            _schedule.KodePenerbangan = kodePenerbangan;
            _schedule.KodeAirportAsal = kodeAirportAsal;
            _schedule.KodeAirportTujuan = kodeAirportTujuan;
            _schedule.TglKeberangkatan = tglKeberangkatan;            
            _schedule.TglKedatangan = tglKedatangan;            
            _schedule.BatasBagasi = batasBagasi;
            _schedule.BatasBagasiKabin = batasBagasiKabin;
            _schedule.HargaTiket = hargaTiket;
        }


        public long TambahSchedule(string kodeMaskapai,
            string kodePenerbangan,
            string kodeAirportAsal,
            string kodeAirportTujuan,
            string tglKeberangkatan,            
            string tglKedatangan,            
            int batasBagasi,
            int batasBagasiKabin,
            decimal hargaTiket)
        {

            this.validateBase(kodeMaskapai,
                    kodePenerbangan,
                    kodeAirportAsal,
                    kodeAirportTujuan,                    
                    tglKeberangkatan,
                    tglKedatangan,
                    batasBagasi,
                    batasBagasiKabin,
                    hargaTiket);

            var dt = parseTglJamKeberangkatanKedatangan(tglKeberangkatan,                    
                    tglKedatangan);

            DateTime _tglKeberangkatan = dt[0];            
            DateTime _tglKedatangan = dt[1];            

            var _schedule = new Models.ScheduleModel();
            _schedule.CreatedAt = DateTime.UtcNow;
            _schedule.CreatedBy = _loginEmail;
            
            setValue(ref _schedule,
                kodeMaskapai,
                    kodePenerbangan,
                    kodeAirportAsal,
                    kodeAirportTujuan,
                    _tglKeberangkatan,                    
                    _tglKedatangan,                    
                    batasBagasi,
                    batasBagasiKabin,
                    hargaTiket);

            _schedule.Maskapai = null;
            _schedule.Pesawat = null;
            _schedule.AirportAsal = null;
            _schedule.AirportTujuan = null;

            _db.Schedules.Add(_schedule);
            _db.SaveChanges();

            return _schedule.ScheduleID;

        }

        public void UpdateSchedule(long scheduleID,
            string kodeMaskapai,
            string kodePenerbangan,
            string kodeAirportAsal,
            string kodeAirportTujuan,
            string tglKeberangkatan,            
            string tglKedatangan,            
            int batasBagasi,
            int batasBagasiKabin,
            decimal hargaTiket)
        {

            validateID(scheduleID);

            this.validateBase(kodeMaskapai,
                  kodePenerbangan,
                  kodeAirportAsal,
                  kodeAirportTujuan,
                  tglKeberangkatan,                  
                  tglKedatangan,                  
                  batasBagasi,
                  batasBagasiKabin,
                  hargaTiket);

            var dt = parseTglJamKeberangkatanKedatangan(tglKeberangkatan,                 
                 tglKedatangan);

            DateTime _tglKeberangkatan = dt[0];
            DateTime _jamKeberangkatan = dt[1];
            DateTime _tglKedatangan = dt[2];
            DateTime _jamKedatangan = dt[3];

            var _fSchedule = findByID(scheduleID);

            setValue(ref _fSchedule,
                kodeMaskapai,
                    kodePenerbangan,
                    kodeAirportAsal,
                    kodeAirportTujuan,
                    _tglKeberangkatan,                    
                    _tglKedatangan,                    
                    batasBagasi,
                    batasBagasiKabin,
                    hargaTiket);
            
            _fSchedule.Maskapai = null;
            _fSchedule.Pesawat = null;
            _fSchedule.AirportAsal = null;
            _fSchedule.AirportTujuan = null;


            _db.SaveChanges();

        }

        public void DeleteSchedule(long scheduleID)
        {
            validateID(scheduleID);

            var _fSchedule = findByID(scheduleID);
            if(_fSchedule != null)
            {
                _db.Schedules.Remove(_fSchedule);
                _db.SaveChanges();
            }
        }

        public Models.ScheduleModel? findByID(long scheduleID)
        {
            /*
             * LINQ
             * First => temukan yang pertama, jika tidak ketemu error
             * FirstOrDefault => temukan yang pertama, jika tidak ketemu return null             
             */
            /*var _fSchedule = _schedules.Where(x => x.ScheduleID == scheduleID).FirstOrDefault();*/
            var _fSchedule = _db.Schedules.Where(x => x.ScheduleID == scheduleID).FirstOrDefault(); 
            if (_fSchedule == null)
            {
                throw new Exception("schedule_not_found");
            }
            return _fSchedule;
        }


        public Models.ScheduleModel? FindScheduleByID(long scheduleID)
        {
            return findByID(scheduleID);
        }

        public List<Models.ScheduleModel> FindSchedules()
        {
            return _db.Schedules.
                Include("Maskapai").
                Include("Pesawat").
                Include("AirportAsal").
                Include("AirportTujuan").
                ToList();           
        }


    }
}
