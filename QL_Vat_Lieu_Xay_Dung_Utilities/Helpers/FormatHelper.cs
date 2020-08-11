using System;
using System.Security.Cryptography;
using System.Text;

namespace QL_Vat_Lieu_Xay_Dung_Utilities.Helpers
{
    public class FormatHelper
    {
        public static string HashPasswordInOldFormat(string password)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var data = Encoding.ASCII.GetBytes(password);
            var sha1data = sha1.ComputeHash(data);
            return Convert.ToBase64String(sha1data);
        }
    }
}