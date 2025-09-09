using serverT2.Application.Services.Criptography;

namespace CommonTesteUtilities.Cryptography
{
    public class PasswordEncripterBuilder
    {
        public static PasswordCryptography Build()
        {
            return new PasswordCryptography("abc1234");
        }
    }
}
