using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Deloitte_NF.Models;


namespace Deloitte_NF.Controllers
{
    public class NotaFiscalController : Controller
    {
        // GET: NotaFiscal
        public ActionResult Index(string msgSucesso = "")
        {
            using (NotaFiscalModel model = new NotaFiscalModel())
            {
                List<NotaFiscal> lista = model.ListarNota();

                if (!string.IsNullOrEmpty(msgSucesso))
                {
                    ViewBag.MsgSucesso = msgSucesso;
                }

                return View(lista);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            NotaFiscal notaFiscal = new NotaFiscal();

            using (NotaFiscalModel acoes = new NotaFiscalModel())
            {
                if (id > 0)
                {
                    notaFiscal = acoes.ObterNota(id);
                }

                notaFiscal.ListaClientes = this.ListarClientes();

                notaFiscal.ListaFornecedor = this.ListarFornecedores();

                notaFiscal.ListaProdutos = this.ListarProdutos();
            }

            return View("Create", notaFiscal);
        }

        [HttpPost]
        public ActionResult Create(NotaFiscal nota)
        {
            // FAZER VALIDAÇÃO DOS DADOS
            using (NotaFiscalModel model = new NotaFiscalModel())
            {
                nota.DataNotaFiscal = DateTime.Now;

                if (nota.IdNotaFiscal > 0)
                {
                    model.AtualizarNota(nota);
                }
                else
                {
                    model.IncluirNota(nota);
                }
            }

            return Json("Item salvo com sucesso", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Remove(NotaFiscal nota)
        {
            using (NotaFiscalModel model = new NotaFiscalModel())
            {
                model.ExcluirNota(nota);

                return Json("Item removido com sucesso", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Relatorio(int id = 0)
        {
            List<NotaFiscal> lista = new List<NotaFiscal>();

            using (NotaFiscalModel acoes = new NotaFiscalModel())
            {
                if (id > 0)
                {
                    lista = acoes.ListarNotasPorProduto(id);
                }
            }

            return View("Relatorio", lista);
        }

        /// <summary>
        /// Método de listagem de clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        private IList<SelectListItem> ListarClientes()
        {
            IList<SelectListItem> listaRetorno = new List<SelectListItem>();

            using (NotaFiscalModel acoes = new NotaFiscalModel())
            {
                var lista = acoes.ListarClientes();

                foreach (var item in lista)
                {
                    listaRetorno.Add(new SelectListItem() { Text = item.NomeCliente, Value = item.IdCliente.ToString() });
                }
            }

            return listaRetorno;
        }

        /// <summary>
        /// Método de listagem de Fornecedores
        /// </summary>
        /// <returns>Lista de Fornecedores</returns>
        private IList<SelectListItem> ListarFornecedores()
        {
            IList<SelectListItem> listaRetorno = new List<SelectListItem>();

            using (NotaFiscalModel acoes = new NotaFiscalModel())
            {
                var lista = acoes.ListarFornecedores();

                foreach (var item in lista)
                {
                    listaRetorno.Add(new SelectListItem() { Text = item.NomeFornecedor, Value = item.IdFornecedor.ToString() });
                }
            }

            return listaRetorno;
        }

        /// <summary>
        /// Método de listagem de Produtos
        /// </summary>
        /// <returns>Lista de Produtos</returns>
        private IList<SelectListItem> ListarProdutos()
        {
            IList<SelectListItem> listaRetorno = new List<SelectListItem>();

            using (NotaFiscalModel acoes = new NotaFiscalModel())
            {
                var lista = acoes.ListarProdutos();

                foreach (var item in lista)
                {
                    listaRetorno.Add(new SelectListItem() { Text = item.NomeProduto, Value = item.IdProduto.ToString() });
                }
            }

            return listaRetorno;
        }
    }
}