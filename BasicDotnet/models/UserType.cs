using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.models
{
    public class UserType
    {
        public const int EMPLOYEE = 1;
        public const int ADMIN = 2;

        public static string ToString(int userType)
        {
            switch(userType)
            {
                case EMPLOYEE:
                    return "Employee";

                case ADMIN:
                    return "Admin";

                default:
                    throw new Exception("invalid_user_type");
            }
        }
    }
}
