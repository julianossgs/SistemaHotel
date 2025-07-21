using System;
using System.Windows.Forms;

namespace SistemaHotel.Services
{
    public class ErroMensageService
    {
        public static void ShowError(string message, string title = "Erro")
        {
            try
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Aqui você pode logar em um arquivo, mostrar um fallback, etc.
                // Evite lançar novamente para não travar a aplicação.
                // Exemplo de fallback:
                Console.WriteLine($"[MessageBox Error] {ex.Message}");
            }
        }


    }
}
