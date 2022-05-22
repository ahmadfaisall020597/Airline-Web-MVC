using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.models
{
    public class User
    {
        protected string UserID { get; set; }
        private string _password { get; set; }

        public string Email { get; set;  }
        public int UserType { get; set; }


     
        public User(string userID, string email, string password, int userType)
        {
            this.UserID = userID;
            this.Email = email;
            _password = password;
            this.UserType = userType;
        }

        public string GetPassword()
        {
            return _password;
        }
    }
}
