using Xunit;
using AirlineBooking.Services;
using AirlineBooking.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;


namespace AirlineBooking.Test
{
    public class AirportGatewayServiceTest
    {
        [Fact]
        public void TestAirportGateway_PositiveTest()
        {

            var dbOption = new DbContextOptionsBuilder<AirlineBookingDbContext>()
              .UseSqlServer(TestVars.ConnectionString)
              .Options;

            using (var _db = new Models.AirlineBookingDbContext(dbOption))
            {

                AirportGatewayService _airportGatewayService = new AirportGatewayService(_db);
                _airportGatewayService.Migrate();

                string _kodeAirport = "CGK";
                string _nomorGate = "7";
                string _nomorPintu = "2";
                
                var _idGateway = _airportGatewayService.AddAirportGateway(_kodeAirport, _nomorGate, _nomorPintu);

                var _fAirportGateway = _airportGatewayService.FindByID(_idGateway);
                Assert.NotNull(_fAirportGateway);
                if (_fAirportGateway != null)
                {
                    Assert.Equal(_kodeAirport, _fAirportGateway.KodeAirport);
                    Assert.Equal(_nomorGate, _fAirportGateway.NomorGate);
                    Assert.Equal(_nomorPintu, _fAirportGateway.NomorPintu);                    
                }

                
                /*_nomorGate = "6";
                _nomorPintu = "1";
                _airportGatewayService.UpdateAirportGateway(_idGateway,
                    _kodeAirport,
                    _nomorGate,
                    _nomorPintu);

                _fAirportGateway = _airportGatewayService.FindByID(_idGateway);
                Assert.NotNull(_fAirportGateway);
                if (_fAirportGateway != null)
                {
                    Assert.Equal(_kodeAirport, _fAirportGateway.KodeAirport);
                    Assert.Equal(_nomorGate, _fAirportGateway.NomorGate);
                    Assert.Equal(_nomorPintu, _fAirportGateway.NomorPintu);
                }*/

            }
        }

        [Fact]
        public void TestAirportGateway_SeedingAirportGateways()
        {

            var dbOption = new DbContextOptionsBuilder<AirlineBookingDbContext>()
              .UseSqlServer(TestVars.ConnectionString)
              .Options;

            using (var _db = new AirlineBookingDbContext(dbOption))
            {

                AirportGatewayService _airportGatewayService = new AirportGatewayService(_db);
                _airportGatewayService.Migrate();

                AirportGatewayModel[] _gates = new AirportGatewayModel[]
                {
                    new AirportGatewayModel("CGK", "1", "1"),
                    new AirportGatewayModel("CGK", "2", "1"),
                    new AirportGatewayModel("CGK", "3", "1"),
                    new AirportGatewayModel("CGK", "4", "1"),
                    new AirportGatewayModel("CGK", "5", "1"),

                    new AirportGatewayModel("DPS", "1", "1"),
                    new AirportGatewayModel("DPS", "1", "2"),

                    new AirportGatewayModel("SUB", "1", "1"),
                    new AirportGatewayModel("SUB", "2", "1"),
                    new AirportGatewayModel("SUB", "3", "1")
                };


                for(int i = 0; i < _gates.Length; i++)
                {

                    var _gate = _gates[i];
                    var _kodeAirport = _gate.KodeAirport;
                    var _nomorGate = _gate.NomorGate;
                    var _nomorPintu = _gate.NomorPintu;

                    var _idGateway = _airportGatewayService.AddAirportGateway(_kodeAirport, _nomorGate, _nomorPintu);

                    var _fAirportGateway = _airportGatewayService.FindByID(_idGateway);
                    Assert.NotNull(_fAirportGateway);
                    if (_fAirportGateway != null)
                    {
                        Assert.Equal(_kodeAirport, _fAirportGateway.KodeAirport);
                        Assert.Equal(_nomorGate, _fAirportGateway.NomorGate);
                        Assert.Equal(_nomorPintu, _fAirportGateway.NomorPintu);

                    }
                }
                
            }
        }

    }
}
