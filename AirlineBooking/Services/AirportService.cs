using AirlineBooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AirlineBooking.Services
{
    public class AirportService : BaseService
    {
        public AirportService(AirlineBookingDbContext db, string loginID) : base(db, loginID)
        {
        }

        public void Migrate()
        {
            var _dbConn = _db.Database.GetDbConnection();
            _dbConn.Open();
            var _cmd = _dbConn.CreateCommand();
            _cmd.CommandText = "TRUNCATE TABLE airport;";
            _cmd.CommandType = System.Data.CommandType.Text;
            _cmd.ExecuteNonQuery();
            
            _cmd = _dbConn.CreateCommand();
            _cmd.CommandText = "TRUNCATE TABLE airport_gateway;";
            _cmd.CommandType = System.Data.CommandType.Text;
            _cmd.ExecuteNonQuery();
            _dbConn.Close();
        }


        private void validateBase(string kodeAirport,
            string namaAirport,
            string propinsi,
            string kota,
            List<AirportGatewayModel> gateways)
        {
            if(string.IsNullOrEmpty(kodeAirport))
            {
                throw new Exception("kode_airport_kosong");
            }
            if (string.IsNullOrEmpty(namaAirport))
            {
                throw new Exception("nama_airport_kosong");
            }
            if (string.IsNullOrEmpty(propinsi))
            {
                throw new Exception("propinsi_kosong");
            }
            if (string.IsNullOrEmpty(kota))
            {
                throw new Exception("kota_kosong");
            }

            if (gateways == null)
            {
                throw new Exception("gateway_is_required");
            }

            if (gateways.Count == 0)
            {
                throw new Exception("gateway_is_required");
            }

            foreach (var g in gateways)
            {
                if (string.IsNullOrEmpty(g.NomorGate))
                {
                    throw new Exception("nomor_gate_is_required");
                }
                if (string.IsNullOrEmpty(g.NomorPintu))
                {
                    throw new Exception("nomor_pintu_is_required");
                }
            }
            
        }

        private void setValue(ref Models.AirportModel _airport,
            string kodeAirport,
            string namaAirport,
            string propinsi,
            string kota)
        {
            _airport.KodeAirport = kodeAirport;
            _airport.NamaAirport = namaAirport;
            _airport.Propinsi = propinsi;
            _airport.Kota = kota;
        }

        public void AddAirport(string kodeAirport,
            string namaAirport,
            string propinsi,
            string kota,
            List<AirportGatewayModel> gateways)
        
        {
            
            validateBase(kodeAirport, namaAirport, propinsi, kota, gateways);

            var _airport = new Models.AirportModel();
            _airport.CreatedAt = DateTime.Now.ToUniversalTime();
            _airport.CreatedBy = _loginEmail;
            
            setValue(ref _airport, kodeAirport, namaAirport, propinsi, kota);
            
            var _tr = _db.Database.BeginTransaction();

            try
            {
                _db.Airports.Add(_airport);
                _db.SaveChanges();
            
                _insertAirportGateways(_tr, _airport.KodeAirport,
                    gateways);
                
                _tr.Commit();
            }
            catch (Exception e)
            {
                _tr.Rollback();
                if (e.InnerException.Message.Contains("PK_airport"))
                {
                    throw new Exception("Kode Airport duplikat");
                }
                else if (e.InnerException.Message.Contains("uq_airport_nama_airport"))
                {
                    throw new Exception("Nama Airport duplikat");
                }
                else
                {
                    throw;    
                }
                
            }
        }


        private void _insertAirportGateways(IDbContextTransaction tr,
            string kodeAirport,
            List<AirportGatewayModel> gateways)
        {
            foreach (var gateway in gateways)
            {
                try
                {
                    var _airportGateway = new Models.AirportGatewayModel();
                    _airportGateway.CreatedAt = DateTime.Now.ToUniversalTime(); //UTC
                    _airportGateway.KodeAirport = kodeAirport;
                    _airportGateway.NomorGate = gateway.NomorGate;
                    _airportGateway.NomorPintu = gateway.NomorPintu;
                    _airportGateway.CreatedAt = DateTime.Now.ToUniversalTime();
                    _airportGateway.CreatedBy = _loginEmail;

                    _db.AirportGateways.Add(_airportGateway);
                    _db.SaveChanges();
                }
                catch (Exception e)
                {
                    if (e.InnerException.Message.Contains("uq_airport_gateway"))
                    {
                        throw new Exception("Gateway duplikat");
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
        }

        private void _removeAirportGateways(IDbContextTransaction tr,
            string kodeAirport)
        {
            var _gateways = _db.AirportGateways.Where(x => x.KodeAirport.Equals(kodeAirport))
                .ToList();
            _db.AirportGateways.RemoveRange(_gateways);
            _db.SaveChanges();

        }
        public void UpdateAirport(string kodeAirport,
            string namaAirport,
            string propinsi,
            string kota,
            List<AirportGatewayModel> gateways)
        
        {
            
            validateBase(kodeAirport, namaAirport, propinsi, kota, gateways);
            
            var _airport = _findByKodeAirport(kodeAirport, false);
            if (_airport != null)
            {

                var _tr = _db.Database.BeginTransaction();

                try
                {
                    
                    _airport.NamaAirport = namaAirport;
                    _airport.Propinsi = propinsi;
                    _airport.Kota = kota;
                    _airport.UpdatedAt = DateTime.Now.ToUniversalTime();
                    _airport.UpdatedBy = _loginEmail;
                
                    _db.SaveChanges();   
                
                    _removeAirportGateways(_tr, _airport.KodeAirport);

                    _insertAirportGateways(_tr, _airport.KodeAirport,
                        gateways);
                    
                    _tr.Commit();
                }
                catch (Exception e)
                {
                    _tr.Rollback();
                    Console.WriteLine(e);
                    throw;
                }
                
            }
            
        }
        
        public void DeleteAirport(string kodeAirport)
        {
            if (string.IsNullOrEmpty(kodeAirport))
            {
                throw new Exception("invalid_kode_airport");
            }
            var _airport = _findByKodeAirport(kodeAirport, false);
            if (_airport != null)
            {
                _db.Airports.Remove(_airport);
                _db.SaveChanges();    
            }
            
        }
        private Models.AirportModel _findByKodeAirport(string kodeAirport, bool asNoTracking)
        {
            if(string.IsNullOrEmpty(kodeAirport))
            {
                throw new ArgumentNullException("kode_airport_is_null");
            }

            Models.AirportModel _fAirport;
            if (asNoTracking)
            {
                _fAirport = _db.Airports.AsNoTracking()
                    .FirstOrDefault(x => x.KodeAirport.ToLower().Equals(kodeAirport));
            }
            else
            {
                 _fAirport = _db.Airports
                    .FirstOrDefault(x => x.KodeAirport.ToLower().Equals(kodeAirport));    
            }
            
            if(_fAirport == null)
            {
                throw new NullReferenceException("airport_not_found");
            }
            return _fAirport;
        }

        public Models.AirportModel FindAirportByKodeAirport(string kodeAirport, bool asNoTracking)
        {
            if(string.IsNullOrEmpty(kodeAirport))
            {
                throw new ArgumentNullException("kode_airport_is_null");
            }
            var _fAirport = _db.Airports.
                Include("Gateways").
                AsNoTracking().
                FirstOrDefault(x => x.KodeAirport.ToLower().Equals(kodeAirport));
            
            if(_fAirport == null)
            {
                throw new NullReferenceException("airport_not_found");
            }
            return _fAirport;
        }

        
        public List<Models.AirportModel> FindList()
        {
            return _db.Airports.ToList();
        }

    }
}
