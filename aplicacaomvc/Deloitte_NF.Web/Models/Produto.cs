
namespace Deloitte_NF.Models
{
    /// <summary>
    /// Classe Produto
    /// </summary>
    public class Produto
    {
        /// <summary>
        /// Obtém e informa o Sequencial do Produto
        /// </summary>
        /// <value>Sequencial do Produto</value>
        public int IdProduto { get; set; }

        /// <summary>
        /// Obtém e informa os Dados do Fornecedor
        /// </summary>
        /// <value>Dados do Fornecedor</value>
        public Fornecedor Fornecedor { get; set; }

        /// <summary>
        /// Obtém e informa o Nome do Produto
        /// </summary>
        /// <value>Nome do Produto</value>
        public string NomeProduto { get; set; }

        /// <summary>
        /// Obtém e informa o Valor do Produto
        /// </summary>
        /// <value>Valor do Produto</value>
        public double ValorProduto { get; set; }
    }
}