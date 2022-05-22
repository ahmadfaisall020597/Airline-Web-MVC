using Xunit;
using AirlineBooking.Services;
using AirlineBooking.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace AirlineBooking.Test
{
    public class AirportServiceTest
    {

        [Fact]
        public void TestAirport_PositiveTest()
        {

            var dbOption = new DbContextOptionsBuilder<AirlineBookingDbContext>()
               .UseSqlServer(TestVars.ConnectionString)
               .Options;

            using (var _db = new Models.AirlineBookingDbContext(dbOption))
            {

                AirportService _airportService = new AirportService(_db, TestVars.LoginEmail);
                _airportService.Migrate();

                string _kodeAirport = "CGK";
                string _namaAirport = "Soekarno Hatta";
                string _propinsi = "Banten";
                string _kota = "Tangerang";

                List<Models.AirportGatewayModel> _gateways = new List<AirportGatewayModel>();
                _gateways.Add(new AirportGatewayModel("", "1", "A"));
                _gateways.Add(new AirportGatewayModel("", "2", "A"));
                _gateways.Add(new AirportGatewayModel("", "3", "A"));
                _gateways.Add(new AirportGatewayModel("", "4", "A"));
                _gateways.Add(new AirportGatewayModel("", "5", "A"));
                _gateways.Add(new AirportGatewayModel("", "6", "A"));
                _gateways.Add(new AirportGatewayModel("", "7", "A"));
                
                _airportService.AddAirport(_kodeAirport, 
                    _namaAirport, 
                    _propinsi, 
                    _kota,
                    _gateways);

                var _fAirport = _airportService.FindAirportByKodeAirport(_kodeAirport, true);
                Assert.NotNull(_fAirport);
                if (_fAirport != null)
                {
                    Assert.Equal(_kodeAirport, _fAirport.KodeAirport);
                    Assert.Equal(_namaAirport, _fAirport.NamaAirport);
                    Assert.Equal(_propinsi, _fAirport.Propinsi);
                    Assert.Equal(_kota, _fAirport.Kota);
                    
                    Assert.Equal(_gateways.Count, _fAirport.Gateways.Count);
                    
                }
                
                _gateways = new List<AirportGatewayModel>();
                _gateways.Add(new AirportGatewayModel("", "1", "A"));
                _airportService.UpdateAirport(_fAirport.KodeAirport,
                    _namaAirport, 
                    _propinsi, 
                    _kota,
                    _gateways);
                
                
                _fAirport = _airportService.FindAirportByKodeAirport(_kodeAirport, true);
                Assert.NotNull(_fAirport);
                if (_fAirport != null)
                {
                    Assert.Equal(_kodeAirport, _fAirport.KodeAirport);
                    Assert.Equal(_namaAirport, _fAirport.NamaAirport);
                    Assert.Equal(_propinsi, _fAirport.Propinsi);
                    Assert.Equal(_kota, _fAirport.Kota);
                    Assert.Equal(_gateways.Count, _fAirport.Gateways.Count);
                }
                
            }
        }


        /*[Fact]
        public void TestAirport_SeedingAirports()
        {
            var dbOption = new DbContextOptionsBuilder<AirlineBookingDbContext>()
              .UseSqlServer(TestVars.ConnectionString)
              .Options;

            using (var _db = new Models.AirlineBookingDbContext(dbOption))
            {

                AirportService _airportService = new AirportService(_db, TestVars.LoginEmail);
                _airportService.Migrate();

                Models.AirportModel[] _aiports = new Models.AirportModel[]
                {
                    new AirportModel("CGK", "Soekarnoa-Hatta", "Banten", "Tangerang"),
                    new AirportModel("DPS", "Ngurah Rai", "Bali", "Denpasar"),
                    new AirportModel("SUB", "Juanda", "Jawa Timur", "Sidoarjo"),
                    new AirportModel("SOC", "Adisumarmo", "Jawa Tengah", "Boyolali Regency"),
                };

                for (int i = 0; i < _aiports.Length; i++)
                {
                    var _airport = _aiports[i];
                    var _kodeAirport = _airport.KodeAirport;
                    var _namaAirport = _airport.NamaAirport;
                    var _propinsi = _airport.Propinsi;
                    var _kota = _airport.Kota;

                    _airportService.AddAirport(_kodeAirport, _namaAirport, _propinsi, _kota);

                    var _fAirport = _airportService.FindAirportByKodeAirport(_kodeAirport, true);
                    Assert.NotNull(_fAirport);
                    if (_fAirport != null)
                    {
                        Assert.Equal(_kodeAirport, _fAirport.KodeAirport);
                        Assert.Equal(_namaAirport, _fAirport.NamaAirport);
                        Assert.Equal(_propinsi, _fAirport.Propinsi);
                        Assert.Equal(_kota, _fAirport.Kota);
                    }
                }


            }
        }*/

    }
}
