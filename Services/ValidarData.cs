using System;
using System.Windows.Forms;

namespace SistemaHotel.Services
{
    public static class ValidarData
    {

        //Método para validar a data de um DateTimePicker
        public static bool IsValidDate(this DateTimePicker picker)
        {
            DateTime dataSelecionada = picker.Value.Date;

            // 🔹 Exemplo de regra: não permitir datas antes de hoje
            if (dataSelecionada < DateTime.Today)
            {
                MessageBox.Show("Não é permitido informar uma data retroativa.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                picker.Focus();
                return false;
            }

            // 🔹 Bloqueia datas futuras
            if (dataSelecionada > DateTime.Today)
            {
                MessageBox.Show("Não é permitido informar uma data futura.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                picker.Focus();
                return false;
            }

            // 🔹 Exemplo de regra: ano mínimo
            if (dataSelecionada.Year < 1900 || dataSelecionada.Year > DateTime.Now.Year + 10)
            {
                MessageBox.Show("Ano inválido! Digite um ano entre 1900 e o limite permitido.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                picker.Focus();
                return false;
            }

            return true;
        }
    }
}
