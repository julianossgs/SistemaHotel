using MySql.Data.MySqlClient;
using SistemaHotel.Services;
using System;

namespace SistemaHotel.Dados
{
    public class Conexao
    {

        //string de conexão(conexão c/ o banco local)
        public string Cn = "Server=localhost;Database=bdHappyInHotel;Uid=root;Pwd=juliano71@;";

        public MySqlConnection Con = null;//variável que executa a conexão

        //Método p/ abrir a conexão
        public void AbrirCon()
        {
            try
            {
                Con = new MySqlConnection(Cn);
                Con.Open();
            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao abrir a conexão com o banco de dados: " + ex.Message);
            }

        }

        //Método p/ fechar a conexão
        public void FecharCon()
        {
            try
            {
                Con = new MySqlConnection(Cn);
                Con.Close();
            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao fechar a conexão com o banco de dados: " + ex.Message);
            }
        }
    }
}
