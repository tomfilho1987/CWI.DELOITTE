
namespace Deloitte_NF.Models
{
    /// <summary>
    /// Classe Fornecedor
    /// </summary>
    public class Fornecedor
    {
        /// <summary>
        /// Obtém e informa o Sequencial do Fornecedor
        /// </summary>
        /// <value>Sequencial do Fornecedor</value>
        public int IdFornecedor { get; set; }

        /// <summary>
        /// Obtém e informa o Nome do Fornecedor
        /// </summary>
        /// <value>Nome do Fornecedor</value>
        public string NomeFornecedor { get; set; }

        /// <summary>
        /// Obtém e informa o CPF/CNPJ do Fornecedor
        /// </summary>
        /// <value>CPF/CNPJ do Fornecedor</value>
        public string CNPJFornecedor { get; set; }

        /// <summary>
        /// Obtém e informa o Endereço do Fornecedor
        /// </summary>
        /// <value>Endereço do Fornecedor</value>
        public string EnderecoFornecedor { get; set; }
    }
}