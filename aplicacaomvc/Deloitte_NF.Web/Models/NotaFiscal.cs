using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Deloitte_NF.Models
{
    /// <summary>
    /// Classe Nota Fiscal
    /// </summary>
    public class NotaFiscal
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        public NotaFiscal()
        {
            Cliente = new Cliente();
            Fornecedor = new Fornecedor();
            Produto = new Produto();
        }

        /// <summary>
        /// Obtém e informa o Sequencial da Nota Fiscal
        /// </summary>
        /// <value>Sequencial da Nota Fiscal</value>
        public int IdNotaFiscal { get; set; }

        /// <summary>
        /// Obtém e informa o Cliente da Nota Fiscal
        /// </summary>
        /// <value>Cliente da Nota Fiscal</value>
        public Cliente Cliente { get; set; }

        /// <summary>
        /// Obtém e informa o Produto da Nota Fiscal
        /// </summary>
        /// <value>Produto da Nota Fiscal</value>
        public Produto Produto { get; set; }

        /// <summary>
        /// Obtém e informa o Fornecedor da Nota Fiscal
        /// </summary>
        /// <value>Fornecedor da Nota Fiscal</value>
        public Fornecedor Fornecedor { get; set; }

        /// <summary>
        /// Obtém e informa a Quantidade de Produtos da Nota Fiscal
        /// </summary>
        /// <value>Quantidade de Produtos da Nota Fiscal</value>
        public int QtdeProdutos { get; set; }

        /// <summary>
        /// Obtém e informa a Data da Nota fiscal
        /// </summary>
        /// <value>Data da Nota fiscal</value>
        public DateTime DataNotaFiscal { get; set; }

        /// <summary>
        /// Obtém e informa o Valor da Nota fiscal
        /// </summary>
        /// <value>Valor da Nota fiscal</value>
        public double ValorNotaFiscal { get; set; }

        public IEnumerable<SelectListItem> ListaClientes { get; set; }

        public IEnumerable<SelectListItem> ListaProdutos { get; set; }

        public IEnumerable<SelectListItem> ListaFornecedor { get; set; }
    }
}