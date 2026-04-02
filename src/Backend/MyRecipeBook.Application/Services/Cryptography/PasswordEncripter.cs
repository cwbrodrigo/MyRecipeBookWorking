using MyRecipeBook.Application.Services.AutoMapper;
using System.Security.Cryptography;
using System.Text;
namespace MyRecipeBook.Application.Services.Cryptography
{
    public class PasswordEncripter : IPasswordEncripter
    {
        private readonly IPasswordEncripter _encripter;
        public string Encrypt(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                100_000,
                HashAlgorithmName.SHA256,
                32);

            return $"{Convert.ToHexString(salt)}:{Convert.ToHexString(hash)}";
        }

        private static string StringBytes(byte[] bytes)
        {
            var stringBuilder = new StringBuilder();
            foreach (var b in bytes)
            {
                stringBuilder.Append(b.ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
