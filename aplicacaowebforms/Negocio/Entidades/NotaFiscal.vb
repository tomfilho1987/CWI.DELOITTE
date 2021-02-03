Public Class NotaFiscal

    Private _idNotaFiscal As Short
    Private _cliente As Cliente
    Private _produto As Produto
    Private _fornecedor As Fornecedor
    Private _qtdeProdutos As Short
    Private _dataNotaFiscal As DateTime
    Private _valorNotaFiscal As Double

    Public Property IdNotaFiscal As Short
        Get
            Return _idNotaFiscal
        End Get
        Set(value As Short)
            _idNotaFiscal = value
        End Set
    End Property

    Public Property Cliente As Cliente
        Get
            Return _cliente
        End Get
        Set(value As Cliente)
            _cliente = value
        End Set
    End Property

    Public Property Produto As Produto
        Get
            Return _produto
        End Get
        Set(value As Produto)
            _produto = value
        End Set
    End Property

    Public Property Fornecedor As Fornecedor
        Get
            Return _fornecedor
        End Get
        Set(value As Fornecedor)
            _fornecedor = value
        End Set
    End Property

    Public Property QtdeProdutos As Short
        Get
            Return _qtdeProdutos
        End Get
        Set(value As Short)
            _qtdeProdutos = value
        End Set
    End Property

    Public Property DataNotaFiscal As Date
        Get
            Return _dataNotaFiscal
        End Get
        Set(value As Date)
            _dataNotaFiscal = value
        End Set
    End Property

    Public Property ValorNotaFiscal As Double
        Get
            Return _valorNotaFiscal
        End Get
        Set(value As Double)
            _valorNotaFiscal = value
        End Set
    End Property

    ''' <summary>
    ''' Método de listagem de notas fiscais
    ''' </summary>
    ''' <returns>Lista das notas fiscais</returns>
    Public Function ListarNota() As DataTable

        Dim notaFiscalSql As NotaFiscalSQL = New NotaFiscalSQL()

        Return notaFiscalSql.ListarNota()

    End Function

    ''' <summary>
    ''' Método de exclusão de nota fiscal
    ''' </summary>
    Public Sub ExcluirNota()

        Dim notaFiscalSql As NotaFiscalSQL = New NotaFiscalSQL()

        notaFiscalSql.ExcluirNota(Me)

    End Sub

    ''' <summary>
    ''' Método de listagem de clientes
    ''' </summary>
    ''' <returns>Lista de Clientes</returns>
    Public Function ListarClientes() As List(Of Cliente)

        Dim notaFiscalSql As NotaFiscalSQL = New NotaFiscalSQL()

        Return notaFiscalSql.ListarClientes()

    End Function

    ''' <summary>
    ''' Método de listagem de Fornecedores
    ''' </summary>
    ''' <returns>Lista de Fornecedores</returns>
    Public Function ListarFornecedores() As List(Of Fornecedor)

        Dim notaFiscalSql As NotaFiscalSQL = New NotaFiscalSQL()

        Return notaFiscalSql.ListarFornecedores()

    End Function

    ''' <summary>
    ''' Método de listagem de Produto
    ''' </summary>
    ''' <returns>Lista de Produtos</returns>
    Public Function ListarProdutos() As List(Of Produto)

        Dim notaFiscalSql As NotaFiscalSQL = New NotaFiscalSQL()

        Return notaFiscalSql.ListarProdutos()

    End Function

    ''' <summary>
    ''' Método de inclusão de Nota Fiscal
    ''' </summary>
    Public Sub IncluirNota()

        Dim notaFiscalSql As NotaFiscalSQL = New NotaFiscalSQL()

        notaFiscalSql.IncluirNota(Me)

    End Sub

    ''' <summary>
    ''' Método de obtenção de nota fiscal por Identificador
    ''' </summary>
    ''' <returns>Nota fiscal pesquisada</returns>
    Public Function ObterNota() As NameValueCollection

        Dim notaFiscalSql As NotaFiscalSQL = New NotaFiscalSQL()

        Return notaFiscalSql.ObterNota(Me)

    End Function

    ''' <summary>
    ''' Método de atualização de Nota Fiscal
    ''' </summary>
    Public Sub AtualizarNota()

        Dim notaFiscalSql As NotaFiscalSQL = New NotaFiscalSQL()

        notaFiscalSql.AtualizarNota(Me)

    End Sub

    ''' <summary>
    ''' Método de listagem de Notas Fiscais por Produto
    ''' </summary>
    ''' <returns>Listagem de Notas Fiscais por Produto</returns>
    Public Function ListarNotasPorProduto() As DataTable

        Dim notaFiscalSql As New NotaFiscalSQL

        Return notaFiscalSql.ListarNotasPorProduto(Me)

    End Function

End Class