using System.Configuration;
using System.Data.SqlClient;

namespace Deloitte_NF.Util
{
    public class FuncoesSQL
    {
        /// <summary>
        /// Método para abertura de conexão com a base de dados
        /// </summary>
        /// <returns>Retorna a conexão</returns>
        public static void AbrirConexao(ref SqlConnection sqlConnection)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LOCALHOST"].ConnectionString);
            sqlConnection.Open();
        }

        /// <summary>
        /// Método para fechar de conexão com a base de dados
        /// </summary>
        public static void FecharConexao(SqlConnection sqlConnection)
        {
            sqlConnection.Close();
        }
    }
}