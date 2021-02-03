Public Class RelatorioNotaFiscal
    Inherits Page
    Private ReadOnly notaFiscal As New NotaFiscal

    Protected Sub Page_PreIniti(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

        If Page.Request.ServerVariables("http_user_agent").ToLower().Contains("safari") Then

            Page.ClientTarget = "uplevel"

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Try

                lblMensagem.Text = String.Empty
                lblMensagem.Visible = False

                ListarProdutos()

            Catch ex As Exception
                Throw ex
            End Try

        End If

    End Sub

    ''' <summary>
    ''' Método que popula o dropdown de Produtos
    ''' </summary>
    Private Sub ListarProdutos()

        Dim lista As List(Of Produto)

        lista = notaFiscal.ListarProdutos()

        drpProduto.Items.Clear()
        drpProduto.Items.Add(New ListItem With {.Value = "", .Text = ""})

        For Each produto As Produto In lista

            drpProduto.Items.Add(New ListItem With {.Value = produto.Id, .Text = produto.Nome})

        Next

    End Sub

    Protected Sub DrpProduto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpProduto.SelectedIndexChanged

        Try

            lblMensagem.Text = String.Empty
            lblMensagem.Visible = False

            If Not String.IsNullOrEmpty(drpProduto.SelectedValue) Then

                notaFiscal.Produto = New Produto With {
                    .Id = drpProduto.SelectedValue
                }

                dtgRelatorio.DataSource = notaFiscal.ListarNotasPorProduto()
                dtgRelatorio.DataBind()

            Else

                dtgRelatorio.DataSource = Nothing
                dtgRelatorio.DataBind()

            End If

        Catch ex As Exception

            lblMensagem.Text = "Nenhuma Nota Fiscal foi encontrada para o Produto selecionado."
            lblMensagem.Visible = True

        End Try

    End Sub

    Protected Sub btnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click

        Response.Redirect("../Paginas/NotaFiscalConsultar.aspx")

    End Sub
End Class