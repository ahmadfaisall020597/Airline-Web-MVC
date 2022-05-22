using AirlineBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineBooking.Services
{
    public class AirportGatewayService : BaseService
    {
        public AirportGatewayService(AirlineBookingDbContext db) : base(db)
        {
        }

        public void Migrate()
        {
            var _dbConn = _db.Database.GetDbConnection();
            _dbConn.Open();
            var _cmd = _dbConn.CreateCommand();
            _cmd.CommandText = "TRUNCATE TABLE airport_gateway;";
            _cmd.CommandType = System.Data.CommandType.Text;
            _cmd.ExecuteNonQuery();
            _dbConn.Close();
        }


        private void validateBase(string kodeAirport,
            string nomorGate,
            string nomorPintu)
        {
            if(string.IsNullOrEmpty(kodeAirport))
            {
                throw new ArgumentNullException("kode_airport_is_null");
            }
            if (string.IsNullOrEmpty(nomorGate))
            {
                throw new ArgumentNullException("nomor_gate_is_null");
            }

            if (string.IsNullOrEmpty(nomorPintu))
            {
                throw new ArgumentNullException("nomor_pintu_is_null");
            }
        }

        private void setValue(ref Models.AirportGatewayModel _airportGateway,
            string kodeAirport,
            string nomorGate,
            string nomorPintu)
        {
            _airportGateway.KodeAirport = kodeAirport;
            _airportGateway.NomorGate = nomorGate;
            _airportGateway.NomorPintu = nomorPintu;    
            
        }

        public long AddAirportGateway(string kodeAirport,
            string nomorGate,
            string nomorPintu)
        {
            validateBase(kodeAirport, nomorGate, nomorPintu);

            var _airportGateway = new Models.AirportGatewayModel();
            
            /*_airportGateway.IDGateway = Helpers.IDHelper.ID();
            Thread.Sleep(100);*/
            _airportGateway.CreatedAt = DateTime.Now.ToUniversalTime(); //UTC

            setValue(ref _airportGateway,
                kodeAirport,
                nomorGate,
                nomorPintu);

            _db.AirportGateways.Add(_airportGateway);
            _db.SaveChanges();

            return _airportGateway.IDGateway;

        }

        public void DeleteAirportGateway(long idGateway, string kodeAirport,
            string nomorGate,
            string nomorPintu)
        {

            validateBase(kodeAirport, nomorGate, nomorPintu);

            var _gateway = _findByID(idGateway);
            if (_gateway !=null)
            {   
                setValue(ref _gateway,
                    kodeAirport,
                    nomorGate,
                    nomorPintu);
                _db.SaveChanges();

            }
        }

        public Models.AirportGatewayModel _findByID(long idGateway)
        {
            if(idGateway <=0)
            {
                throw new ArgumentException("invalid_id_gateway");
            }
            var _fAirportGateway = _db.AirportGateways.Where(x=>x.IDGateway == idGateway).FirstOrDefault();    
            if(_fAirportGateway == null)
            {
                throw new NullReferenceException("airport_gateway_not_found");
            }
            return _fAirportGateway;
        }

        public Models.AirportGatewayModel FindByID(long idGateway)
        {
            return _findByID(idGateway); 
        }


    }
}
