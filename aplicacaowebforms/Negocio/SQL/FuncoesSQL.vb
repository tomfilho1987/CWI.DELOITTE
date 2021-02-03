Imports System.Data.SqlClient

Public Class FuncoesSQL

    Public Sub AbrirConexao(ByRef connecttion As SqlConnection)

        Dim connectionString As String = ConfigurationManager.AppSettings.Get("LOCALHOST")

        connecttion = New SqlConnection(connectionString)
        connecttion.Open()

    End Sub

    Public Sub FecharConexao(ByVal connecttion As SqlConnection)
        connecttion.Close()
    End Sub

End Class