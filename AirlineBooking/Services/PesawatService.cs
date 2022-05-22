using AirlineBooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace AirlineBooking.Services
{
    public class PesawatService : BaseService
    {
        public PesawatService(AirlineBookingDbContext db, string loginID) : base(db, loginID)
        {
        }

        public void Migrate()
        {
            var _dbConn = _db.Database.GetDbConnection();
            _dbConn.Open();
            var _cmd = _dbConn.CreateCommand();
            _cmd.CommandText = "TRUNCATE TABLE pesawat;";
            _cmd.CommandType = System.Data.CommandType.Text;
            _cmd.ExecuteNonQuery();
            _dbConn.Close();
        }


        private void validateBase(string kodePenerbangan,
            string kodeJenisPesawat,
            string kodeMaskapai,
            List<KursiPesawatModel> kursiPesawats)
        {
            if(string.IsNullOrEmpty(kodePenerbangan))
            {
                throw new Exception("kode_penerbangan_kosong");
            }
            if (string.IsNullOrEmpty(kodeJenisPesawat))
            {
                throw new Exception("kode_jenis_pesawat");
            }
            if (string.IsNullOrEmpty(kodeMaskapai))
            {
                throw new Exception("kode_maskapai");
            }

            if (kursiPesawats == null)
            {
                throw new Exception("kursi_pesawat_is_required");
            }

            if (kursiPesawats.Count == 0)
            {
                throw new Exception("kursi_pesawat_is_required");
            }

            foreach (var kp in kursiPesawats)
            {
                if (string.IsNullOrEmpty(kp.NomorKursi))
                {
                    throw new Exception("nomor_kursi_is_required");
                }
            }
            
        }

        private void setValue(ref PesawatModel pesawat,
            string kodePenerbangan,
            string kodeJenisPesawat,
            string kodeMaskapai)
        {

            pesawat.KodePenerbangan = kodePenerbangan;
            pesawat.KodeJenisPesawat = kodeJenisPesawat;            
            pesawat.KodeMaskapai = kodeMaskapai;

        }

        public void AddPesawat(string kodePenerbangan,
            string kodeJenisPesawat,
            string kodeMaskapai,
            List<KursiPesawatModel> kursiPesawats)
        {

            try
            {
                validateBase(kodePenerbangan, 
                    kodeJenisPesawat,
                    kodeMaskapai,
                    kursiPesawats);

                var _pesawat = new PesawatModel();
                _pesawat.CreatedAt = DateTime.Now.ToUniversalTime();
                _pesawat.CreatedBy = _loginEmail;
                setValue(ref _pesawat, kodePenerbangan, kodeJenisPesawat,
                    kodeMaskapai);
                
                foreach (var kp in kursiPesawats)
                {
                    kp.CreatedAt = DateTime.UtcNow;
                    kp.CreatedBy = _loginEmail;
                }
                _pesawat.KursiPesawats = kursiPesawats;
                _pesawat.Maskapai = null;
                _pesawat.JenisPesawat = null;

                _db.Pesawats.Add(_pesawat);
                
                /*_db.Entry(_pesawat.Maskapai).State = EntityState.Detached;
                _db.Entry(_pesawat.JenisPesawat).State = EntityState.Detached;*/
                _db.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public void _insertKursiPesawats(List<KursiPesawatModel> kursiPesawats)
        {
            foreach (var kp in kursiPesawats)
            {
               
            }
        }
        public void UpdatePesawat(string kodePenerbangan,
            string kodeJenisPesawat,
            string kodeMaskapai,
            List<KursiPesawatModel> kursiPesawats)
        {
            try
            {
                validateBase(kodePenerbangan, 
                    kodeJenisPesawat,
                    kodeMaskapai,
                    kursiPesawats);
            
                var _pesawat = _findByKodePenerbangan(kodePenerbangan);
                _pesawat.KodeJenisPesawat = kodeJenisPesawat;            
                _pesawat.KodeMaskapai = kodeMaskapai;
                _pesawat.UpdatedAt = DateTime.Now.ToUniversalTime();
                _pesawat.UpdatedBy = _loginEmail;

                _pesawat.KursiPesawats.RemoveAll(x => x.KodePenerbangan.Equals(kodePenerbangan));
                    
                foreach (var kp in kursiPesawats)
                {
                    kp.CreatedAt = DateTime.UtcNow;
                    kp.CreatedBy = _loginEmail;
                }
                _pesawat.KursiPesawats.AddRange(kursiPesawats);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public void DeletePesawat(string kodePenerbangan)
        {
            try
            {
                if (String.IsNullOrEmpty(kodePenerbangan))
                {
                    throw new Exception("invalid_kode_penerbangan");
                }
            
                var _pesawat = _findByKodePenerbangan(kodePenerbangan);
                _db.Pesawats.Remove(_pesawat);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        
        private Models.PesawatModel _findByKodePenerbangan(string kodePenerbangan)
        {
            if (string.IsNullOrEmpty(kodePenerbangan))
            {
                throw new Exception("kode_penerbangan_is_required");
            }

            var _fPesawat = _db.Pesawats.
                Include("KursiPesawats").
                FirstOrDefault(x => x.KodePenerbangan.ToLower()
                .Equals(kodePenerbangan));
            
            if(_fPesawat == null)
            {
                throw new Exception("pesawat_not_found");
            }
            return _fPesawat;
        }


        public Models.PesawatModel FindByKodePenerbangan(string kodePenerbangan)
        {
            if (string.IsNullOrEmpty(kodePenerbangan))
            {
                throw new Exception("kode_penerbangan_is_required");
            }

            var _fPesawat = _db.Pesawats
                .Include("Maskapai")
                .Include("JenisPesawat")
                .Include("KursiPesawats")
                .AsNoTracking()
                .FirstOrDefault(x => x.KodePenerbangan.ToLower().Equals(kodePenerbangan));
            
            if(_fPesawat == null)
            {
                throw new Exception("pesawat_not_found");
            }
            return _fPesawat;
        }

        public List<PesawatModel> FindList()
        {
            return _db.Pesawats
                .ToList();
        }


    }
}
