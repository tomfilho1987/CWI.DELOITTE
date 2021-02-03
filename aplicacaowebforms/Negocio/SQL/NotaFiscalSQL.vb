Imports System.Data.SqlClient
Imports System.Globalization

Public Class NotaFiscalSQL

    Private connection As New SqlConnection
    Private command As New SqlCommand
    Private dataReader As SqlDataReader
    Private funcaoSQL As New FuncoesSQL
    Private funcao As New Funcao
    Private ReadOnly cultura As New CultureInfo("pt-BR")

    ''' <summary>
    ''' Método de listagem de notas fiscais
    ''' </summary>
    ''' <returns>Lista das notas fiscais</returns>
    Public Function ListarNota() As DataTable

        Dim arl As New ArrayList
        Dim nvc As NameValueCollection

        Try

            funcaoSQL.AbrirConexao(connection)

            command.Connection = connection
            command.CommandText = "EXECUTE ListarNotaFiscal "

            dataReader = command.ExecuteReader()

            Do While dataReader.Read

                nvc = New NameValueCollection From {
                    {"ID", dataReader("NF_ID").ToString()},
                    {"Cliente", dataReader("CLI_NOME").ToString()},
                    {"Produto", dataReader("PROD_NOME").ToString()},
                    {"Fornecedor", dataReader("FOR_NOME").ToString()},
                    {"Qtd.", dataReader("NF_QTDE").ToString()},
                    {"Data", Convert.ToDateTime(dataReader("NF_DATA").ToString()).ToString("dd/MM/yyyy")},
                    {"Valor", Double.Parse(dataReader("NF_VAL").ToString(), cultura)}
                }

                arl.Add(nvc)

            Loop

            dataReader.Close()

        Catch ex As Exception

            Throw ex

        Finally

            funcaoSQL.FecharConexao(connection)

        End Try

        Return funcao.ConverterResultado(arl)

    End Function

    ''' <summary>
    ''' Método de listagem de clientes
    ''' </summary>
    ''' <returns>Lista de Clientes</returns>
    Public Function ListarClientes() As List(Of Cliente)

        Dim listaRetorno As New List(Of Cliente)

        Try

            funcaoSQL.AbrirConexao(connection)

            command.Connection = connection

            command.CommandText = "EXEC ListarClientes"
            dataReader = command.ExecuteReader()

            Do While dataReader.Read

                Dim cliente As New Cliente With {
                    .Id = Short.Parse(dataReader("cli_id")),
                    .Nome = dataReader("cli_nome").ToString()
                }

                listaRetorno.Add(cliente)

            Loop

            dataReader.Close()

            Return listaRetorno

        Catch ex As Exception

            Throw ex

        Finally

            funcaoSQL.FecharConexao(connection)

        End Try

    End Function

    ''' <summary>
    ''' Método de listagem de Fornecedor
    ''' </summary>
    ''' <returns>Lista de Fornecedor</returns>
    Public Function ListarFornecedores() As List(Of Fornecedor)

        Dim listaRetorno As New List(Of Fornecedor)

        Try

            funcaoSQL.AbrirConexao(connection)

            command.Connection = connection

            command.CommandText = "EXEC ListarFornecedores"
            dataReader = command.ExecuteReader()

            Do While dataReader.Read

                Dim fornecedor As New Fornecedor With {
                    .Id = Short.Parse(dataReader("for_id")),
                    .Nome = dataReader("for_nome").ToString()
                }

                listaRetorno.Add(fornecedor)

            Loop

            dataReader.Close()

            Return listaRetorno

        Catch ex As Exception

            Throw ex

        Finally

            funcaoSQL.FecharConexao(connection)

        End Try

    End Function

    ''' <summary>
    ''' Método de listagem de Produto
    ''' </summary>
    ''' <returns>Lista de Produto</returns>
    Public Function ListarProdutos() As List(Of Produto)

        Dim listaRetorno As New List(Of Produto)

        Try

            funcaoSQL.AbrirConexao(connection)

            command.Connection = connection

            command.CommandText = "EXEC ListarProdutos"
            dataReader = command.ExecuteReader()

            Do While dataReader.Read

                Dim produto As New Produto With {
                    .Id = Short.Parse(dataReader("prod_id")),
                    .Nome = dataReader("prod_nome").ToString()
                }

                listaRetorno.Add(produto)

            Loop

            dataReader.Close()

            Return listaRetorno

        Catch ex As Exception

            Throw ex

        Finally

            funcaoSQL.FecharConexao(connection)

        End Try

    End Function

    ''' <summary>
    ''' Método de obtenção de nota fiscal por Identificador
    ''' </summary>
    ''' <returns>Nota fiscal pesquisada</returns>
    Public Function ObterNota(ByVal notaFiscal As NotaFiscal) As NameValueCollection

        Dim nvc As NameValueCollection = Nothing

        Try

            funcaoSQL.AbrirConexao(connection)

            command.Connection = connection

            command.CommandText = "EXEC ListarNotaFiscal"
            dataReader = command.ExecuteReader()

            Do While dataReader.Read

                If Convert.ToInt32(dataReader("NF_ID")) = notaFiscal.IdNotaFiscal Then
                    nvc = New NameValueCollection From {
                        {"CLI_ID", dataReader("CLI_ID").ToString()},
                        {"PROD_ID", dataReader("PROD_ID").ToString()},
                        {"FOR_ID", dataReader("FOR_ID").ToString()},
                        {"NF_QTDE", dataReader("NF_QTDE").ToString()}
                    }

                    Exit Do

                End If

            Loop

            dataReader.Close()

            Return nvc

        Catch ex As Exception

            Throw ex

        Finally

            funcaoSQL.FecharConexao(connection)

        End Try

    End Function

    ''' <summary>
    ''' Método de inclusão de Nota Fiscal
    ''' </summary>
    ''' <param name="notaFiscal">Nota Fiscal</param>
    Public Sub IncluirNota(notaFiscal As NotaFiscal)

        Try

            funcaoSQL.AbrirConexao(connection)

            command.Connection = connection

            Dim produto As Produto = ConsultarProduto(notaFiscal.Produto.Id)

            command.Parameters.Clear()
            command.CommandText = "EXEC IncluirNotaFiscal @cliente_id, @produto_id, @fornecedor_id, @qtde_produto, @valor_nota, @data_nota "

            ' Identificador da nota
            command.Parameters.Add("@nota_id", SqlDbType.Int).Value = notaFiscal.IdNotaFiscal

            ' Identificador do cliente
            command.Parameters.Add("@cliente_id", SqlDbType.Int).Value = notaFiscal.Cliente.Id

            ' Identificador do produto
            command.Parameters.Add("@produto_id", SqlDbType.Int).Value = notaFiscal.Produto.Id

            ' Identificador do fornecedor
            command.Parameters.Add("@fornecedor_id", SqlDbType.Int).Value = notaFiscal.Fornecedor.Id

            ' Quantidade de produtos
            command.Parameters.Add("@qtde_produto", SqlDbType.Int).Value = notaFiscal.QtdeProdutos

            ' Valor da nota
            command.Parameters.Add("@valor_nota", SqlDbType.Decimal).Value = notaFiscal.QtdeProdutos * (produto.ValorProduto)

            ' Data da nota
            command.Parameters.Add("@data_nota", SqlDbType.Date).Value = notaFiscal.DataNotaFiscal

            command.ExecuteNonQuery()

        Catch ex As Exception

            Throw ex

        Finally

            funcaoSQL.FecharConexao(connection)

        End Try

    End Sub

    ''' <summary>
    ''' Método de atualização de Nota Fiscal
    ''' </summary>
    Public Sub AtualizarNota(ByVal notaFiscal As NotaFiscal)

        Try

            funcaoSQL.AbrirConexao(connection)

            command.Connection = connection

            Dim produto As Produto = ConsultarProduto(notaFiscal.Produto.Id)

            command.Parameters.Clear()
            command.CommandText = "EXEC AtualizarNotaFiscal @nota_id, @cliente_id, @produto_id, @fornecedor_id, @qtde_produto, @valor_nota, @data_nota "

            ' Identificador da nota
            command.Parameters.Add("@nota_id", SqlDbType.Int).Value = notaFiscal.IdNotaFiscal

            ' Identificador do cliente
            command.Parameters.Add("@cliente_id", SqlDbType.Int).Value = notaFiscal.Cliente.Id

            ' Identificador do produto
            command.Parameters.Add("@produto_id", SqlDbType.Int).Value = notaFiscal.Produto.Id

            ' Identificador do fornecedor
            command.Parameters.Add("@fornecedor_id", SqlDbType.Int).Value = notaFiscal.Fornecedor.Id

            ' Quantidade de produtos
            command.Parameters.Add("@qtde_produto", SqlDbType.Int).Value = notaFiscal.QtdeProdutos

            ' Valor da nota
            command.Parameters.Add("@valor_nota", SqlDbType.Decimal).Value = notaFiscal.QtdeProdutos * (produto.ValorProduto)

            ' Data da nota
            command.Parameters.Add("@data_nota", SqlDbType.Date).Value = notaFiscal.DataNotaFiscal

            command.ExecuteNonQuery()

        Catch ex As Exception

            Throw ex

        Finally

            funcaoSQL.FecharConexao(connection)

        End Try

    End Sub

    ''' <summary>
    ''' Método de exclusão de nota fiscal
    ''' </summary>
    ''' <param name="notaFiscal">Nota Fiscal a ser exluida</param>
    Public Sub ExcluirNota(ByVal notaFiscal As NotaFiscal)

        Try

            funcaoSQL.AbrirConexao(connection)

            command.Connection = connection

            command.Parameters.Clear()
            command.CommandText = "EXEC ExcluirNotaFiscal @nota_id "

            command.Parameters.Add("@nota_id", SqlDbType.Int).Value = notaFiscal.IdNotaFiscal

            command.ExecuteNonQuery()

        Catch ex As Exception

            Throw ex

        Finally

            funcaoSQL.FecharConexao(connection)

        End Try

    End Sub

    ''' <summary>
    ''' Método de pesquisa de produto por Sequencial do Produto
    ''' </summary>
    ''' <param name="id">Sequencial do Produto</param>
    ''' <returns>Retorna o produto pesquisado</returns>
    Private Function ConsultarProduto(ByVal id As Short) As Produto

        Dim produto As Produto = Nothing

        Try

            funcaoSQL.AbrirConexao(connection)

            command.Connection = connection

            command.Parameters.Clear()
            command.CommandText = "EXEC ConsultarProduto @produto_id"
            command.Parameters.Add("@produto_id", SqlDbType.Int).Value = id

            dataReader = command.ExecuteReader()

            If dataReader.Read Then

                produto = New Produto With {
                    .Id = Short.Parse(dataReader("prod_id").ToString()),
                    .Nome = dataReader("prod_nome").ToString(),
                    .ValorProduto = Double.Parse(dataReader("prod_val").ToString(), cultura)
                }

            End If

            dataReader.Close()

            Return produto

        Catch ex As Exception

            Throw ex

        End Try

    End Function

    ''' <summary>
    ''' Método de listagem de Notas Fiscais por Produto
    ''' </summary>
    ''' <param name="notaFiscal">Nota Fiscal</param>
    ''' <returns>Listagem de Notas Fiscais por Produto</returns>
    Public Function ListarNotasPorProduto(ByVal notaFiscal As NotaFiscal) As DataTable

        Dim arl As New ArrayList
        Dim nvc As NameValueCollection

        Try

            funcaoSQL.AbrirConexao(connection)

            command.Connection = connection

            command.Parameters.Clear()
            command.CommandText = "EXEC ListarNotasPorProduto @idProd "
            command.Parameters.Add("@idProd", SqlDbType.Int).Value = notaFiscal.Produto.Id

            dataReader = command.ExecuteReader()

            Do While dataReader.Read

                nvc = New NameValueCollection From {
                    {"Produto", dataReader("PROD_NOME").ToString()},
                    {"Quantidade", dataReader("NF_QTDE").ToString()},
                    {"Data", Convert.ToDateTime(dataReader("NF_DATA").ToString()).ToString("dd/MM/yyyy")}
                }

                arl.Add(nvc)

            Loop

            dataReader.Close()

        Catch ex As Exception

            Throw ex

        Finally

            funcaoSQL.FecharConexao(connection)

        End Try

        Return funcao.ConverterResultado(arl)

    End Function

End Class