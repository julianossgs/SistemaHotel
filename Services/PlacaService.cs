using System.Text.RegularExpressions;

namespace SistemaHotel.Services
{
    public static class PlacaService
    {
        public static bool IsPlacaValida(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return false;

            placa = placa.ToUpper().Replace("-", "").Trim();

            // Limite de caracteres: deve ter exatamente 7 após tratamento
            if (placa.Length != 7)
                return false;

            var regexAntiga = new Regex(@"^[A-Z]{3}[0-9]{4}$");
            var regexMercosul = new Regex(@"^[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2}$");

            return regexAntiga.IsMatch(placa) || regexMercosul.IsMatch(placa);
        }
    }
}
