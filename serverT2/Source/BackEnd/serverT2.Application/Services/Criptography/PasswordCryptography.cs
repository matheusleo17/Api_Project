using FluentValidation.Internal;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;

namespace serverT2.Application.Services.Criptography
{
    public class PasswordCryptography
    {
        private readonly string _additionalKey;
        public PasswordCryptography(string additionalKey) { 
            _additionalKey = additionalKey;
        }
        public string Encrypt(string password) 
        {
            var newpassword = $"p{password}{_additionalKey}";
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
