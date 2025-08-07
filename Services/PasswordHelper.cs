using System;
using System.Security.Cryptography;

namespace SistemaHotel.Services
{
    public static class PasswordHelper
    {
        // Gera salt aleatório
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // Gera hash seguro usando PBKDF2
        public static string HashPassword(string password, string salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10000);
            byte[] hash = pbkdf2.GetBytes(32); // 32 bytes = 256 bits
            return Convert.ToBase64String(hash);
        }

        // Verifica se a senha está correta
        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            var hash = HashPassword(password, storedSalt);
            return hash == storedHash;
        }
    }
}
