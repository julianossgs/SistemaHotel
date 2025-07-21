using System;
using System.Windows.Forms;

namespace SistemaHotel.Services
{
    public class SucessoMensageService
    {
        public static void ShowSuccess(string message, string title = "Sucesso")
        {
            try
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Aqui você pode logar em um arquivo, mostrar um fallback, etc.
                Console.WriteLine($"[MessageBox Success Error] {ex.Message}");
            }
        }
    }
}
