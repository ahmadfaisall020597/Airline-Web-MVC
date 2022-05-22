using AirlineBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineBooking.Services
{
    public class JenisPesawatService : BaseService
    {
        public JenisPesawatService(AirlineBookingDbContext db, string loginID) : base(db, loginID)
        {
        }

        public void Migrate()
        {
            var _dbConn = _db.Database.GetDbConnection();
            _dbConn.Open();
            var _cmd = _dbConn.CreateCommand();
            _cmd.CommandText = "TRUNCATE TABLE jenis_pesawat;";
            _cmd.CommandType = System.Data.CommandType.Text;
            _cmd.ExecuteNonQuery();
            _dbConn.Close();
        }


        private void validateBase(string kodeJenisPesawat,
            int tahunPesawat)
        {
            if(string.IsNullOrEmpty(kodeJenisPesawat))
            {
                throw new Exception("kode_jenis_pesawat_kosong");
            }
            if(tahunPesawat <=0)
            {
                throw new Exception("tahun_pesawat_must_be_greater_than_zero");
            }            
        }

        private void setValue(ref Models.JenisPesawatModel _jenis_pesawat,
            string kodeJenisPesawat,
            int tahunPesawat)
        {

            _jenis_pesawat.KodeJenisPesawat = kodeJenisPesawat;

            _jenis_pesawat.TahunPesawat = tahunPesawat;            

        }

        public void AddJenisPesawat(string kodeJenisPesawat,
            int tahunPesawat)
        {

            try
            {
                validateBase(kodeJenisPesawat, tahunPesawat);

                var _jenis_pesawat = new Models.JenisPesawatModel();
                _jenis_pesawat.CreatedAt = DateTime.UtcNow;
                _jenis_pesawat.CreatedBy = _loginEmail;

                setValue(ref _jenis_pesawat, kodeJenisPesawat, tahunPesawat);

                _db.JenisPesawats.Add(_jenis_pesawat);

                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            

        }
        
       
        
        public void UpdateJenisPesawat(string kodeJenisPesawat,
            int tahunPesawat)
        {

            validateBase(kodeJenisPesawat, tahunPesawat);
            var _jenis_pesawat = _findByKodeJenisPesawat(kodeJenisPesawat, false);
            _jenis_pesawat.TahunPesawat = tahunPesawat;
            _jenis_pesawat.UpdatedAt = DateTime.UtcNow;
            _jenis_pesawat.UpdatedBy = _loginEmail;
            _db.SaveChanges();

        }
        
        public void DeleteJenisPesawat(string kodeJenisPesawat)
        {
            if (string.IsNullOrEmpty(kodeJenisPesawat))
            {
                throw new Exception("invalid_kode_jenis_pesawat");
            }
            var _jenisPesawat = _findByKodeJenisPesawat(kodeJenisPesawat, false);
            _db.JenisPesawats.Remove(_jenisPesawat);
            _db.SaveChanges();

        }

        private Models.JenisPesawatModel _findByKodeJenisPesawat(string kodeJenisPesawat, bool asNoTracking)
        {
            if(string.IsNullOrEmpty(kodeJenisPesawat))
            {
                throw new ArgumentNullException("kode_jenis_pesawat_is_null");
            }

            JenisPesawatModel _fJenisPesawat;
            if (asNoTracking)
            {
                _fJenisPesawat = _db.JenisPesawats.AsNoTracking()
                    .FirstOrDefault(x => x.KodeJenisPesawat.ToLower().Equals(kodeJenisPesawat));
            }
            else
            {
                _fJenisPesawat = _db.JenisPesawats
                    .FirstOrDefault(x => x.KodeJenisPesawat.ToLower().Equals(kodeJenisPesawat));
            }

            
            if(_fJenisPesawat == null)
            {
                throw new NullReferenceException("jenis_pesawat_not_found");
            }
            return _fJenisPesawat;
        }

        public Models.JenisPesawatModel FindJenisPesawatByKodeJenisPesawat(string kodeJenisPesawat,
            bool asNoTracking)
        {
            return _findByKodeJenisPesawat(kodeJenisPesawat, asNoTracking);
        }

        public List<JenisPesawatModel> FindList()
        {
            return _db.JenisPesawats.ToList();
        }
    }
}
