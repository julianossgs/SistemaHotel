using System;
using System.IO;
using System.Windows.Forms;

namespace SistemaHotel.Services
{
    public static class LogService
    {
        private static readonly string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        /// <summary>
        /// Grava um log de erro com stack trace e mostra mensagem padrão ao usuário.
        /// </summary>
        public static void LogError(Exception ex, string acao = null)
        {
            try
            {
                string data = DateTime.Now.ToString("yyyy-MM-dd");
                string logFile = Path.Combine(logDirectory, $"erro_{data}.txt");

                if (!Directory.Exists(logDirectory))
                    Directory.CreateDirectory(logDirectory);

                string cabecalho = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}]";
                string mensagem = !string.IsNullOrEmpty(acao) ? $"AÇÃO: {acao}\n" : "";
                string log = $"{cabecalho}\n{mensagem}ERRO: {ex.Message}\nSTACK: {ex.StackTrace}\n---------------------------\n";

                File.AppendAllText(logFile, log);
            }

            catch
            {
                // Ignora erros ao tentar registrar o log
            }

            // Mensagem padrão ao usuário
            MessageBox.Show("Erro da aplicação! Entre em contato com o suporte através do nº (35)98898-1198",
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        /// <summary>
        /// Grava um log de sucesso, sem mostrar mensagem ao usuário.
        /// </summary>
        public static void LogSucesso(string mensagem)
        {
            try
            {
                string data = DateTime.Now.ToString("yyyy-MM-dd");
                string logFile = Path.Combine(logDirectory, $"sucesso_{data}.txt");

                if (!Directory.Exists(logDirectory))
                    Directory.CreateDirectory(logDirectory);

                string log = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] SUCESSO: {mensagem}\n";
                File.AppendAllText(logFile, log);
            }
            catch
            {

            }
        }
    }
}