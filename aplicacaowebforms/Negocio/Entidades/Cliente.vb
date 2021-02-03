Public Class Cliente
    Inherits Generico

    Private _cpfCnpj As String
    Private _enderecoCliente As String

    Public Property CnpjCliente As String
        Get
            Return _cpfCnpj
        End Get
        Set(value As String)
            _cpfCnpj = value
        End Set
    End Property

    Public Property EnderecoCliente As String
        Get
            Return _enderecoCliente
        End Get
        Set(value As String)
            _enderecoCliente = value
        End Set
    End Property
End Class