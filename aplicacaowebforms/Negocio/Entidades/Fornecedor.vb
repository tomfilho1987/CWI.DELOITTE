Public Class Fornecedor
    Inherits Generico

    Private _cnpjFornecedor As String
    Private __enderecoFornecedor As String

    Public Property CnpjFornecedor As String
        Get
            Return _cnpjFornecedor
        End Get
        Set(value As String)
            _cnpjFornecedor = value
        End Set
    End Property

    Public Property EnderecoFornecedor As String
        Get
            Return __enderecoFornecedor
        End Get
        Set(value As String)
            __enderecoFornecedor = value
        End Set
    End Property
End Class