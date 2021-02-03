using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using Deloitte_NF.Util;

namespace Deloitte_NF.Models
{
    public class NotaFiscalModel : IDisposable
    {
        /// <summary>
        /// SqlConnection - connection
        /// </summary>
        private SqlConnection connection = new SqlConnection();

        /// <summary>
        /// SqlCommand - command
        /// </summary>
        private readonly SqlCommand command = new SqlCommand();

        /// <summary>
        /// SqlDataReader - dataReader
        /// </summary>
        private SqlDataReader dataReader;

        /// <summary>
        /// CultureInfo cultura
        /// </summary>
        private readonly CultureInfo cultura = new CultureInfo("pt-BR");

        public NotaFiscalModel()
        {
        }

        /// <summary>
        /// Método de listagem de notas fiscais
        /// </summary>
        /// <returns>Lista das notas fiscais</returns>
        public List<NotaFiscal> ListarNota()
        {
            List<NotaFiscal> listaRetorno = new List<NotaFiscal>();

            try
            {
                FuncoesSQL.AbrirConexao(ref connection);

                command.Connection = connection;
                command.CommandText = "EXECUTE ListarNotaFiscal ";

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    NotaFiscal notaFiscal = new NotaFiscal
                    {
                        // Dados da nota fiscal
                        IdNotaFiscal = int.Parse(dataReader["NF_ID"].ToString()),
                        QtdeProdutos = int.Parse(dataReader["NF_QTDE"].ToString()),
                        DataNotaFiscal = DateTime.Parse(dataReader["NF_DATA"].ToString(), cultura),
                        ValorNotaFiscal = double.Parse(dataReader["NF_VAL"].ToString(), cultura)
                    };

                    // Dados do cliente da nota fiscal
                    Cliente cliente = new Cliente()
                    {
                        IdCliente = int.Parse(dataReader["CLI_ID"].ToString()),
                        NomeCliente = dataReader["CLI_NOME"].ToString()
                    };
                    notaFiscal.Cliente = cliente;

                    // Dados do produto da nota fiscal
                    Produto produto = new Produto
                    {
                        IdProduto = int.Parse(dataReader["PROD_ID"].ToString()),
                        NomeProduto = dataReader["PROD_NOME"].ToString()
                    };
                    notaFiscal.Produto = produto;

                    // Dados do fornecedor da nota fiscal
                    Fornecedor fornecedor = new Fornecedor
                    {
                        IdFornecedor = int.Parse(dataReader["FOR_ID"].ToString()),
                        NomeFornecedor = dataReader["FOR_NOME"].ToString()
                    };
                    notaFiscal.Fornecedor = fornecedor;

                    listaRetorno.Add(notaFiscal);
                }

                dataReader.Close();

                return listaRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    FuncoesSQL.AbrirConexao(ref connection);
                }
            }
        }

        /// <summary>
        /// Método de obtenção de nota fiscal por Identificador
        /// </summary>
        /// <param name="id">Identificador da Nota Fiscal</param>
        /// <returns>Nota fiscal pesquisada</returns>
        public NotaFiscal ObterNota(int id)
        {
            NotaFiscal notaFiscal = new NotaFiscal();

            try
            {
                FuncoesSQL.AbrirConexao(ref connection);

                command.Connection = connection;
                command.CommandText = "EXECUTE ListarNotaFiscal ";

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    if (int.Parse(dataReader["NF_ID"].ToString()) == id)
                    {
                        // Dados da nota fiscal
                        notaFiscal = new NotaFiscal
                        {
                            IdNotaFiscal = int.Parse(dataReader["NF_ID"].ToString()),
                            QtdeProdutos = int.Parse(dataReader["NF_QTDE"].ToString()),
                            DataNotaFiscal = DateTime.Parse(dataReader["NF_DATA"].ToString(), cultura),
                            ValorNotaFiscal = double.Parse(dataReader["NF_VAL"].ToString(), cultura)
                        };

                        // Dados do cliente da nota fiscal
                        Cliente cliente = new Cliente
                        {
                            IdCliente = int.Parse(dataReader["CLI_ID"].ToString()),
                            NomeCliente = dataReader["CLI_NOME"].ToString()
                        };
                        notaFiscal.Cliente = cliente;

                        // Dados do produto da nota fiscal
                        Produto produto = new Produto
                        {
                            IdProduto = int.Parse(dataReader["PROD_ID"].ToString()),
                            NomeProduto = dataReader["PROD_NOME"].ToString()
                        };
                        notaFiscal.Produto = produto;

                        // Dados do fornecedor da nota fiscal
                        Fornecedor fornecedor = new Fornecedor
                        {
                            IdFornecedor = int.Parse(dataReader["FOR_ID"].ToString()),
                            NomeFornecedor = dataReader["FOR_NOME"].ToString()
                        };
                        notaFiscal.Fornecedor = fornecedor;

                        break;
                    }
                }

                dataReader.Close();

                return notaFiscal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    FuncoesSQL.FecharConexao(connection);
                }
            }
        }

        /// <summary>
        /// Método de listagem de Notas Fiscais por Produto
        /// </summary>
        /// <param name="id">Identificador do Produto</param>
        /// <returns>Listagem de Notas Fiscais por Produto</returns>
        public List<NotaFiscal> ListarNotasPorProduto(int id)
        {
            List<NotaFiscal> lista = new List<NotaFiscal>();

            try
            {
                FuncoesSQL.AbrirConexao(ref connection);

                command.Connection = connection;

                command.Parameters.Clear();
                command.CommandText = "EXEC ListarNotasPorProduto @idProd ";
                command.Parameters.Add("@idProd", SqlDbType.Int).Value = id;
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    NotaFiscal notaFiscal = new NotaFiscal
                    {
                        Cliente = new Cliente(),
                        Produto = new Produto(),
                        Fornecedor = new Fornecedor()
                    };

                    notaFiscal.Produto.NomeProduto = dataReader["PROD_NOME"].ToString();
                    notaFiscal.QtdeProdutos = int.Parse(dataReader["NF_QTDE"].ToString());
                    notaFiscal.DataNotaFiscal = DateTime.Parse(dataReader["NF_DATA"].ToString(), cultura);

                    lista.Add(notaFiscal);
                }

                dataReader.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    FuncoesSQL.FecharConexao(connection);
                }
            }
        }

        /// <summary>
        /// Método de inclusão de Nota Fiscal
        /// </summary>
        /// <param name="notaFiscal">Nova nota fiscal</param>
        public void IncluirNota(NotaFiscal notaFiscal)
        {
            try
            {
                FuncoesSQL.AbrirConexao(ref connection);

                command.Connection = connection;

                Produto produto = ConsultarProduto(notaFiscal.Produto.IdProduto);

                command.Parameters.Clear();
                command.CommandText = "EXEC IncluirNotaFiscal @cliente_id, @produto_id, @fornecedor_id, @qtde_produto, @valor_nota, @data_nota ";

                // Identificador do cliente
                command.Parameters.Add("@cliente_id", SqlDbType.Int).Value = notaFiscal.Cliente.IdCliente;

                // Identificador do produto
                command.Parameters.Add("@produto_id", SqlDbType.Int).Value = notaFiscal.Produto.IdProduto;

                // Identificador do fornecedor
                command.Parameters.Add("@fornecedor_id", SqlDbType.Int).Value = notaFiscal.Fornecedor.IdFornecedor;

                // Quantidade de produtos
                command.Parameters.Add("@qtde_produto", SqlDbType.Int).Value = notaFiscal.QtdeProdutos;

                // Valor da nota
                command.Parameters.Add("@valor_nota", SqlDbType.Decimal).Value = notaFiscal.QtdeProdutos * (produto.ValorProduto);

                // Data da nota
                command.Parameters.Add("@data_nota", SqlDbType.Date).Value = notaFiscal.DataNotaFiscal;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    FuncoesSQL.FecharConexao(connection);
                }
            }
        }

        /// <summary>
        /// Método de exclusão de nota fiscal
        /// </summary>
        /// <param name="notaFiscal">Nota Fiscal</param>
        public void ExcluirNota(NotaFiscal notaFiscal)
        {
            try
            {
                FuncoesSQL.AbrirConexao(ref connection);

                command.Connection = connection;

                command.Parameters.Clear();
                command.CommandText = "EXEC ExcluirNotaFiscal @nota_id ";

                command.Parameters.Add("@nota_id", SqlDbType.Int).Value = notaFiscal.IdNotaFiscal;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    FuncoesSQL.FecharConexao(connection);
                }
            }
        }

        /// <summary>
        /// Método de atualização de Nota Fiscal
        /// </summary>
        /// <param name="notaFiscal">Nota fiscal</param>
        public void AtualizarNota(NotaFiscal notaFiscal)
        {
            try
            {
                FuncoesSQL.AbrirConexao(ref connection);

                command.Connection = connection;

                Produto produto = ConsultarProduto(notaFiscal.Produto.IdProduto);

                command.Parameters.Clear();
                command.CommandText = "EXEC AtualizarNotaFiscal @nota_id, @cliente_id, @produto_id, @fornecedor_id, @qtde_produto, @valor_nota, @data_nota ";

                // Identificador da nota
                command.Parameters.Add("@nota_id", SqlDbType.Int).Value = notaFiscal.IdNotaFiscal;

                // Identificador do cliente
                command.Parameters.Add("@cliente_id", SqlDbType.Int).Value = notaFiscal.Cliente.IdCliente;

                // Identificador do produto
                command.Parameters.Add("@produto_id", SqlDbType.Int).Value = notaFiscal.Produto.IdProduto;

                // Identificador do fornecedor
                command.Parameters.Add("@fornecedor_id", SqlDbType.Int).Value = notaFiscal.Fornecedor.IdFornecedor;

                // Quantidade de produtos
                command.Parameters.Add("@qtde_produto", SqlDbType.Int).Value = notaFiscal.QtdeProdutos;

                // Valor da nota
                command.Parameters.Add("@valor_nota", SqlDbType.Decimal).Value = notaFiscal.QtdeProdutos * (produto.ValorProduto);

                // Data da nota
                command.Parameters.Add("@data_nota", SqlDbType.Date).Value = notaFiscal.DataNotaFiscal;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    FuncoesSQL.FecharConexao(connection);
                }
            }
        }

        /// <summary>
        /// Método de listagem de clientes
        /// </summary>
        /// <returns>Lista de Clientes</returns>
        public List<Cliente> ListarClientes()
        {
            List<Cliente> listaRetorno = new List<Cliente>();

            try
            {
                FuncoesSQL.AbrirConexao(ref connection);

                command.Connection = connection;

                command.CommandText = "EXEC ListarClientes";
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        IdCliente = (int)dataReader["cli_id"],
                        NomeCliente = (string)dataReader["cli_nome"]
                    };

                    listaRetorno.Add(cliente);
                }

                dataReader.Close();

                return listaRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    FuncoesSQL.FecharConexao(connection);
                }
            }
        }

        /// <summary>
        /// Método de listagem dos produtos
        /// </summary>
        /// <returns>Lista de Produtos</returns>
        public List<Produto> ListarProdutos()
        {
            List<Produto> listaRetorno = new List<Produto>();

            try
            {
                FuncoesSQL.AbrirConexao(ref connection);

                command.Connection = connection;

                command.CommandText = "EXEC ListarProdutos";
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Produto produto = new Produto
                    {
                        IdProduto = (int)dataReader["prod_id"],
                        NomeProduto = (string)dataReader["prod_nome"],
                        ValorProduto = double.Parse(dataReader["prod_val"].ToString(), cultura)
                    };

                    listaRetorno.Add(produto);
                }

                dataReader.Close();

                return listaRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    FuncoesSQL.FecharConexao(connection);
                }
            }
        }

        /// <summary>
        /// Método de listagem dos fornecedores
        /// </summary>
        /// <returns>Lista de Fornecedores</returns>
        public List<Fornecedor> ListarFornecedores()
        {
            List<Fornecedor> listaRetorno = new List<Fornecedor>();

            try
            {
                FuncoesSQL.AbrirConexao(ref connection);

                command.Connection = connection;

                command.CommandText = "EXEC ListarFornecedores";
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Fornecedor fornecedor = new Fornecedor
                    {
                        IdFornecedor = (int)dataReader["for_id"],
                        NomeFornecedor = (string)dataReader["for_nome"]
                    };

                    listaRetorno.Add(fornecedor);
                }

                dataReader.Close();

                return listaRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    FuncoesSQL.FecharConexao(connection);
                }
            }
        }

        /// <summary>
        /// Método de pesquisa de produto por Sequencial do Produto
        /// </summary>
        /// <param name="id">Sequencial do Produto</param>
        /// <returns>Retorna o produto pesquisado</returns>
        private Produto ConsultarProduto(int id)
        {
            Produto produto = new Produto();

            try
            {
                command.Parameters.Clear();
                command.CommandText = "EXEC ConsultarProduto @produto_id";
                command.Parameters.Add("@produto_id", SqlDbType.Int).Value = id;

                dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    produto.IdProduto = (int)dataReader["prod_id"];
                    produto.NomeProduto = (string)dataReader["prod_nome"];
                    produto.ValorProduto = double.Parse(dataReader["prod_val"].ToString(), cultura);
                }

                dataReader.Close();

                return produto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Dispose da conexão
        /// </summary>
        public void Dispose()
        {
            connection.Close();
        }
    }
}