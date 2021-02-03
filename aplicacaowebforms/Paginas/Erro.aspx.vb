Public Class Erro
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim erro As Exception

        If Not IsPostBack Then

            If TypeOf (Session("erro")) Is Exception Then

                erro = CType(Session("erro"), Exception)

                lblMensagem.Text = "Descrição: " & erro.Message

            Else

                lblMensagem.Text = Convert.ToString(Session("erro"))

            End If

        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Unload

        Session("erro") = String.Empty

    End Sub

    Protected Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click



    End Sub

End Class