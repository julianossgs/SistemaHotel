using System.Windows.Forms;

namespace SistemaHotel.Services
{
    internal class ControlHelper
    {
        /// <summary>
        /// Limpa todos os TextBox informados.
        /// </summary>
        public static void ClearTextBoxes(params TextBox[] textBoxes)
        {
            foreach (var txt in textBoxes)
            {
                txt.Clear();
            }
        }

        /// Limpa o texto de todos os controles recebidos (TextBox e MaskedTextBox) e coloca o foco no primeiro controle.

        public static void ClearAndFocus(Control focusControl, params Control[] controls)
        {
            foreach (var ctrl in controls)
            {
                if (ctrl is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (ctrl is MaskedTextBox maskedTextBox)
                {
                    maskedTextBox.Clear();
                }
            }

            if (focusControl != null)
            {
                focusControl.Focus();
            }
        }
    }
}
