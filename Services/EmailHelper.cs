using System.Text.RegularExpressions;

namespace SistemaHotel.Services
{
    public static class EmailHelper
    {
        /// Valida se o e-mail informado está em formato válido.

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Regex RFC 5322 simplificada
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }
    }
}
