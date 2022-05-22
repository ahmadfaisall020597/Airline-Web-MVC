using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AirlineBooking.Services
{
    public class HashService
    {
        private const string SALT = "passw1";
        static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }

        public static byte[] _generateHash(string password)
        {            
            byte[] unhashedBytes = Encoding.Unicode.GetBytes(String.Concat(SALT, password));
            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashedBytes = sha256.ComputeHash(unhashedBytes);
            return hashedBytes;
        }

        public static string GenerateHash(string password)
        {
            return Convert.ToBase64String(_generateHash(password));
        }

        public static bool CompareHash(string inputPassword, string hashedPassword)
        {
            string base64Hash = hashedPassword;
            string base64AttemptedHash = GenerateHash(inputPassword);
            return base64Hash == base64AttemptedHash;
        }
    }
}
