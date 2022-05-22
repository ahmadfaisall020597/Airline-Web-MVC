using AirlineBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineBooking.Services
{
    public class KursiPesawatService : BaseService
    {
        public KursiPesawatService(AirlineBookingDbContext db) : base(db)
        {
        }

        public void Migrate()
        {
            var _dbConn = _db.Database.GetDbConnection();
            _dbConn.Open();
            var _cmd = _dbConn.CreateCommand();
            _cmd.CommandText = "TRUNCATE TABLE kursi_pesawat;";
            _cmd.CommandType = System.Data.CommandType.Text;
            _cmd.ExecuteNonQuery();
            _dbConn.Close();
        }


        private void validateBase(string kodePenerbangan,
            string nomorKursi)
        {
            if(string.IsNullOrEmpty(kodePenerbangan))
            {
                throw new Exception("kode_penerbangan_kosong");
            }
            if (string.IsNullOrEmpty(nomorKursi))
            {
                throw new Exception("nomor_kursi_kosong");
            }
        }

        private void setValue(ref Models.KursiPesawatModel _kursiPesawat,
            string kodePenerbangan,
            string nomorKursi)
        {

            _kursiPesawat.KodePenerbangan = kodePenerbangan;
            _kursiPesawat.NomorKursi = nomorKursi;            
        }

        public long AddKursiPesawat(string kodePenerbangan,
            string nomorKursi)
        {

            validateBase(kodePenerbangan, nomorKursi);

            var _kursiPesawat = new Models.KursiPesawatModel();

            setValue(ref _kursiPesawat, kodePenerbangan, nomorKursi);

            _db.KursiPesawats.Add(_kursiPesawat);

            _db.SaveChanges();

            return _kursiPesawat.IDKursiPesawat;

        }

        private Models.KursiPesawatModel findByIDKursi(long idKursi)
        {
            if (idKursi <=0)            
            {
                throw new ArgumentNullException("invalid_id_kursi");
            }

            var _fKursiPesawat = _db.KursiPesawats?.Where(x => x.IDKursiPesawat == idKursi).FirstOrDefault();
            if(_fKursiPesawat == null)
            {
                throw new NullReferenceException("kursi_pesawat_not_found");
            }
            return _fKursiPesawat;
        }


        public Models.KursiPesawatModel FindKursiByID(long idKursi)
        {
            return findByIDKursi(idKursi);
        }

    }
}
