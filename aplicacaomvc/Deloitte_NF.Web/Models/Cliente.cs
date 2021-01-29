
namespace Deloitte_NF.Models
{
    /// <summary>
    /// Classe Cliente
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Obtém e informa o Sequencial do Cliente
        /// </summary>
        /// <value>Sequencial do Cliente</value>
        public int IdCliente { get; set; }

        /// <summary>
        /// Obtém e informa o Nome do Cliente
        /// </summary>
        /// <value>Nome do Cliente</value>
        public string NomeCliente { get; set; }

        /// <summary>
        /// Obtém e informa o CNPJ do Cliente
        /// </summary>
        /// <value>CNPJ do Cliente</value>
        public string CNPJCliente { get; set; }

        /// <summary>
        /// Obtém e informa o Endereço do Cliente
        /// </summary>
        /// <value>Endereço do Cliente</value>
        public string EnderecoCliente { get; set; }
    }
}