using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaHotel.Services
{
    public static class InputValidator
    {
        // Apenas números com ou sem vírgula
        public static void OnlyNumericInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Se o usuário já digitou uma vírgula, não permite outra
            TextBox txt = sender as TextBox;
            if (e.KeyChar == ',' && txt != null && txt.Text.Contains(','))
            {
                e.Handled = true;
            }
        }

        // Apenas inteiros (sem vírgula)
        public static void OnlyIntegerInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
