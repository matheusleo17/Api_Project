using FluentValidation.Internal;
using System.Security.Cryptography;
using System.Text;

namespace api2._0.Application.Services.Criptography
{
    public class PasswordCryptography
    {
        public string Encrypt(string password) 
        {
            var keyadd = "ABC";
            var newpassword = $"p{password}{keyadd}";
            var bytes = Encoding.UTF8.GetBytes(newpassword);
            var hashBytes = SHA512.HashData(bytes);

            return StringBytes(hashBytes);
        }

        public static string StringBytes(byte[] bytes)
        {
            var sb = new StringBuilder();

            foreach(byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}
