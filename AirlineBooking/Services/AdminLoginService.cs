using AirlineBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace AirlineBooking.Services
{
    public class AdminLoginService : BaseService
    {
        public AdminLoginService(AirlineBookingDbContext db,
            string loginEmail) : base(db, loginEmail)
        {
        }

        public void Migrate()
        {
            var _dbConn = _db.Database.GetDbConnection();
            _dbConn.Open();
            var _cmd = _dbConn.CreateCommand();
            _cmd.CommandText = "TRUNCATE TABLE admin_login;";
            _cmd.CommandType = System.Data.CommandType.Text;
            _cmd.ExecuteNonQuery();
            _dbConn.Close();
        }


        private string _generateToken (string adminUserEmail)
        {
            var rawToken = adminUserEmail + Helpers.IDHelper.ID().ToString();
            return HashService.GenerateHash(rawToken);
        }


        public Models.AdminLoginModel _addAdminLogin(string adminUser)
        {

            if (string.IsNullOrEmpty(adminUser))
            {
                throw new Exception("invalid_admin_user");
            }

            var _adminLogin = new Models.AdminLoginModel();
            _adminLogin.CreatedAt = DateTime.Now.ToUniversalTime();
            _adminLogin.LoginID = _generateToken(adminUser);
            _adminLogin.AdminUser = adminUser;
            _adminLogin.Expired = false;

            _db.AdminLogins.Add(_adminLogin);
            _db.SaveChanges();

            return _adminLogin;
        }

        public Models.AdminLoginModel FindByLoginID(string loginID)
        {
            var _login = _db.AdminLogins.Where(x => x.LoginID == loginID)
                .OrderByDescending(x=>x.CreatedAt)
                .FirstOrDefault();
            if(_login == null)
            {
                throw new Exception("invalid_login_session");
            }
            return _login;
        }

        private Models.AdminLoginModel? _findByemail(string email)
        {
            return _db.AdminLogins.Where(x => x.AdminUser == email)
                .OrderByDescending(x=>x.CreatedAt)                
                .FirstOrDefault();
            
        }

        public Models.AdminLoginModel Login(string email,
            string password)
        {

            AdminUserService _adminUserService = new AdminUserService(_db, _loginEmail);

            var _adminUser = _adminUserService.FindByEmail(email, false);

            if (!HashService.CompareHash(password, _adminUser.Password))
            {
                throw new Exception("invalid_password");
            }

            var _fLogin = _findByemail(email);
            if (_fLogin == null)
            {
                var _login = _addAdminLogin(email);
                return _login;

            } else
            {
                if (_fLogin.Expired == false)
                {
                    return _fLogin;

                } else
                {
                    var _login = _addAdminLogin(email);
                    return _login;
                }
                
            }

        }


        public void Logout(string loginID)
        {
            var _login = FindByLoginID(loginID);
            if (_login != null)
            {
                _login.Expired = true;
                _db.SaveChanges();

            }
        }


    }
}
