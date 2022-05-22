using AirlineBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineBooking.Services
{
    public class MaskapaiService : BaseService
    {
        public MaskapaiService(AirlineBookingDbContext db, string loginID) : base(db, loginID)
        {
        }

        public void Migrate()
        {
            var _dbConn = _db.Database.GetDbConnection();
            _dbConn.Open();
            var _cmd = _dbConn.CreateCommand();
            _cmd.CommandText = "TRUNCATE TABLE maskapai;";
            _cmd.CommandType = System.Data.CommandType.Text;
            _cmd.ExecuteNonQuery();
            _dbConn.Close();
        }


        private void _validateBase(string kodeMaskapai,
            string namaMaskapai)
        {
            if(string.IsNullOrEmpty(kodeMaskapai))
            {
                throw new Exception("kode_maskapai_kosong");
            }
            if (string.IsNullOrEmpty(namaMaskapai))
            {
                throw new Exception("nama_maskapai_kosong");
            }            
        }

        private void _setValue(ref Models.MaskapaiModel _maskapai,
            string kodeMaskapai,
            string namaMaskapai)
        {

            _maskapai.KodeMaskapai = kodeMaskapai;
            _maskapai.NamaMaskapai = namaMaskapai;            

        }

        public void AddMaskapai(string kodeMaskapai,
            string namaMaskapai)
        {

            _validateBase(kodeMaskapai, namaMaskapai);

            var _maskapai = new Models.MaskapaiModel();
            _maskapai.CreatedAt = DateTime.Now.ToUniversalTime();
            _maskapai.CreatedBy = _loginEmail;

            _setValue(ref _maskapai, kodeMaskapai, namaMaskapai);

            _db.Maskapaies.Add(_maskapai);

            _db.SaveChanges();

        }

        
        public void UpdateMaskapai(string kodeMaskapai,
            string namaMaskapai)
        {

            try
            {
                _validateBase(kodeMaskapai, namaMaskapai);
                var _maskapai = _findByKodeMaskapai(kodeMaskapai, false);
                if (_maskapai != null)
                {
                    _maskapai.NamaMaskapai = namaMaskapai;
                    _maskapai.UpdatedAt = DateTime.Now.ToUniversalTime();
                    _maskapai.UpdatedBy = _loginEmail;
                    _db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            
            
        }
        
        public void DeleteMaskapai(string kodeMaskapai)
        {
            if (string.IsNullOrEmpty(kodeMaskapai))
            {
                throw new Exception("invalid_kode_maskapai");
            }
            
            var _maskapai = _findByKodeMaskapai(kodeMaskapai, false);
            if (_maskapai != null)
            {
                _db.Maskapaies.Remove(_maskapai);
                _db.SaveChanges();
            }
            
            
        }
        private Models.MaskapaiModel _findByKodeMaskapai(string kodeMaskapai, bool noTracking)
        {
            if(string.IsNullOrEmpty(kodeMaskapai))
            {
                throw new ArgumentNullException("kode_maskapai_is_null");
            }

            Models.MaskapaiModel _fMaskapai;
            if (noTracking)
            {
                _fMaskapai = _db.Maskapaies.AsNoTracking()
                    .FirstOrDefault(x => x.KodeMaskapai.ToLower().Equals(kodeMaskapai.ToLower()));
            }
            else
            {
                _fMaskapai = _db.Maskapaies.FirstOrDefault(x => x.KodeMaskapai.ToLower().Equals(kodeMaskapai.ToLower()));
            }
            
            if(_fMaskapai == null)
            {
                throw new NullReferenceException("maskapai_not_found");
            }
            return _fMaskapai;
        }

        public Models.MaskapaiModel FindMaskapaiByKodeMaskapai(string kodeMaskapai, bool noTracking)
        {
            return _findByKodeMaskapai(kodeMaskapai, noTracking);
        }

        public List<Models.MaskapaiModel> FindList()
        {
            return _db.Maskapaies.ToList();
        }
        
    }
}
