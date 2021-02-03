Public Class Generico

    Private _id As Short
    Private _nome As String

    Public Property Id As Short
        Get
            Return _id
        End Get
        Set(value As Short)
            _id = value
        End Set
    End Property

    Public Property Nome As String
        Get
            Return _nome
        End Get
        Set(value As String)
            _nome = value
        End Set
    End Property
End Class