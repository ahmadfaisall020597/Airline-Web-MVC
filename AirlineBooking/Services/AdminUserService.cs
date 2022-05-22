using System.ComponentModel.Design;
using AirlineBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace AirlineBooking.Services
{
    public class AdminUserService : BaseService
    {
        public AdminUserService(AirlineBookingDbContext db,
            string loginEmail) : base(db, loginEmail)
        {
        }

        public void Migrate()
        {
            var _dbConn = _db.Database.GetDbConnection();
            _dbConn.Open();
            var _cmd = _dbConn.CreateCommand();
            _cmd.CommandText = "TRUNCATE TABLE admin_user;";
            _cmd.CommandType = System.Data.CommandType.Text;
            _cmd.ExecuteNonQuery();
            _dbConn.Close();
        }


        private void validateBase(string email,
            string password,
            string confirmPassword,
            string username)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("email_is_required");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("password_is_required");
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                throw new Exception("confirm_password_is_required");
            }

            if (!password.Equals(confirmPassword))
            {
                throw new Exception("password_must_be_matched_with_confirm_password");
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new Exception("username_is_required");
            }
        }

        private void setValue(ref Models.AdminUserModel _adminUser,
            string email,
            string password,
            string username,
            bool active
        )
        {
            _adminUser.Email = email;

            var _hashPass = HashService.GenerateHash(password);
            _adminUser.Password = _hashPass;
            _adminUser.Username = username;
            _adminUser.Active = active;
        }

        public void DeleteAdminUser(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("email_is_required");
            }

            var _adminUser = _findByEmail(email, true);
            if (_adminUser != null)
            {
                _db.AdminUsers.Remove(_adminUser);
                _db.SaveChanges();
            }
        }


        public void UpdateAdminUser(string email,
            string username,
            bool active)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("email_is_required");
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new Exception("username_is_required");
            }

            var _adminUser = _findByEmail(email, true);
            if (_adminUser != null)
            {
                _adminUser.UpdatedAt = DateTime.Now.ToUniversalTime();
                _adminUser.UpdatedBy = _loginEmail;
                _adminUser.Username = username;
                _adminUser.Active = active;
                _db.SaveChanges();
            }
        }

        public Models.AdminUserModel AddAdminUser(string email,
            string password,
            string confirmPassword,
            string username,
            bool active)
        {
            validateBase(email,
                password,
                confirmPassword,
                username);

            var _adminUser = new Models.AdminUserModel();
            _adminUser.CreatedAt = DateTime.Now.ToUniversalTime();
            _adminUser.CreatedBy = _loginEmail;

            setValue(ref _adminUser,
                email,
                password,
                username,
                active);

            _db.AdminUsers.Add(_adminUser);

            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                if (e.InnerException.Message.Contains("duplicate key"))
                {
                    throw new Exception("Email sudah terdaftar");
                }
                else
                {
                    throw;
                }
            }

            return _adminUser;
        }

        private Models.AdminUserModel _findByEmail(string email, bool noTracking)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("email_is_required");
            }

            AdminUserModel _fAdminUser;
            if (noTracking)
            {
                _fAdminUser = _db.AdminUsers
                    .FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()));    
            }
            else
            {
                _fAdminUser = _db.AdminUsers.AsNoTracking()
                    .FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()));
            }

            if (_fAdminUser == null)
            {
                throw new Exception("Invalid User");
            }

            return _fAdminUser;
        }

        public Models.AdminUserModel FindByEmail(string email, bool noTracking)
        {
            return _findByEmail(email, noTracking);
        }

        public List<Models.AdminUserModel> FindList()
        {
            return _db.AdminUsers.AsNoTracking().ToList();
        }
    }
}