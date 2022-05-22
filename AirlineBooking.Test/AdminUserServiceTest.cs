using Xunit;
using AirlineBooking.Services;
using AirlineBooking.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;


namespace AirlineBooking.Test
{
    public class AdminUserServiceTest
    {

        [Fact]
        public void TestAdminUser_NormalTest()
        {

           var dbOption = new DbContextOptionsBuilder<AirlineBookingDbContext>()
                .UseSqlServer(TestVars.ConnectionString)
                .Options;

            using (var _db = new Models.AirlineBookingDbContext(dbOption))
            {

                AdminUserService _adminUserService = new AdminUserService(_db, 
                    TestVars.LoginEmail);
                _adminUserService.Migrate();


                AdminLoginService _adminLoginService = new AdminLoginService(_db,
                    TestVars.LoginEmail);
                _adminLoginService.Migrate();


                var _email = "admin@airline.com";
                var _password = "123456";
                var _username = "Administrator";
                var _active = true;

                _adminUserService.AddAdminUser(_email,
                    _password,
                    _password,
                    _username,
                    _active);


                var _fAdminUser = _adminUserService.FindByEmail(_email, false);
                Assert.NotNull(_fAdminUser);
                if (_fAdminUser != null)
                {
                    Assert.Equal(_email, _fAdminUser.Email);
                    Assert.Equal(_username, _fAdminUser.Username);

                    var _createdAt = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd");
                    Assert.Equal(_createdAt, _fAdminUser.CreatedAt.ToString("yyyy-MM-dd"));

                    Assert.Equal(TestVars.LoginEmail, _fAdminUser.CreatedBy);

                }


                _username = "Administrator Update";
                _active = false;
                _adminUserService.UpdateAdminUser(_email,
                    _username,
                    _active);
                
                _fAdminUser = _adminUserService.FindByEmail(_email, false);
                Assert.NotNull(_fAdminUser);
                if (_fAdminUser != null)
                {
                    Assert.Equal(_email, _fAdminUser.Email);
                    Assert.Equal(_username, _fAdminUser.Username);

                    /*var _updatedAt = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd");
                    Assert.Equal(_updatedAt, _fAdminUser.UpdatedAt.ToString("yyyy-MM-dd"));*/

                    Assert.Equal(TestVars.LoginEmail, _fAdminUser.UpdatedBy);

                }

                

                var _adminLogin = _adminLoginService.Login(_email, _password);

                var _fLogin = _adminLoginService.FindByLoginID(_adminLogin.LoginID);
                if (_fLogin != null)
                {
                    Assert.Equal(_email, _fLogin.AdminUser);
                    var _createdAt = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd");
                    Assert.Equal(_createdAt, _fLogin.CreatedAt.ToString("yyyy-MM-dd"));
                    Assert.Equal(false, _fLogin.Expired);
                }


                _adminLoginService.Logout(_adminLogin.LoginID);

                _fLogin = _adminLoginService.FindByLoginID(_adminLogin.LoginID);
                if (_fLogin != null)
                {
                    Assert.Equal(true, _fLogin.Expired);
                }

            }
        }


    }
}
