Public Class Produto
    Inherits Generico

    Private _fornecedor As Fornecedor
    Private _valorProduto As Double

    Public Property Fornecedor As Fornecedor
        Get
            Return _fornecedor
        End Get
        Set(value As Fornecedor)
            _fornecedor = value
        End Set
    End Property

    Public Property ValorProduto As Double
        Get
            Return _valorProduto
        End Get
        Set(value As Double)
            _valorProduto = value
        End Set
    End Property
End Class