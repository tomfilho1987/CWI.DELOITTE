Public Class NotaFiscalIncluir
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

                lblMensagem.Text = ""

                CarregarListas()

            Catch ex As Exception
                Throw ex
            End Try

        End If

    End Sub

    Private Sub CarregarListas()

        'Populando dropdown de Clientes
        ListarClientes()

        'Populando dropdown de Fornecedor
        ListarFornecedores()

        'Populando dropdown de Produtos
        ListarProdutos()

    End Sub

    ''' <summary>
    ''' Método que popula o dropdown de Clientes
    ''' </summary>
    Private Sub ListarClientes()

        Dim lista As List(Of Cliente)

        lista = notaFiscal.ListarClientes()

        drpCliente.Items.Clear()
        drpCliente.Items.Add(New ListItem With {.Value = "", .Text = ""})

        For Each cliente As Cliente In lista

            drpCliente.Items.Add(New ListItem With {.Value = cliente.Id, .Text = cliente.Nome})

        Next

    End Sub

    ''' <summary>
    ''' Método que popula o dropdown de Fornecedores
    ''' </summary>
    Private Sub ListarFornecedores()

        Dim lista As List(Of Fornecedor)

        lista = notaFiscal.ListarFornecedores()

        drpFornecedor.Items.Clear()
        drpFornecedor.Items.Add(New ListItem With {.Value = "", .Text = ""})

        For Each fornecedor As Fornecedor In lista

            drpFornecedor.Items.Add(New ListItem With {.Value = fornecedor.Id, .Text = fornecedor.Nome})

        Next

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

    Protected Sub BtnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click

        Response.Redirect("../Paginas/NotaFiscalConsultar")

    End Sub

    Protected Sub BtnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        If Not ValidarCampos() Then
            Exit Sub
        End If

        notaFiscal.Cliente = New Cliente With {
            .Id = drpCliente.SelectedValue
        }

        notaFiscal.Fornecedor = New Fornecedor With {
            .Id = drpFornecedor.SelectedValue
        }

        notaFiscal.Produto = New Produto With {
            .Id = drpProduto.SelectedValue
        }

        notaFiscal.QtdeProdutos = txtQuantidade.Text

        notaFiscal.DataNotaFiscal = DateTime.Now()

        notaFiscal.AtualizarNota()

        Dim script As String = "swal('Item salvo com sucesso', { icon: 'success' }).then(function () { location.href = '../Paginas/NotaFiscalConsultar.aspx' });"

        ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "redirect", script, True)

    End Sub

    ''' <summary>
    ''' Método de validação dos campos obrigatórios
    ''' </summary>
    ''' <returns></returns>
    Private Function ValidarCampos() As Boolean

        Dim mensagemValidacao As String = String.Empty

        If drpCliente.SelectedIndex = 0 Then
            mensagemValidacao += "O campo Cliente é obrigatório. Favor Verificar!<br/>"
        End If

        If drpFornecedor.SelectedIndex = 0 Then
            mensagemValidacao += "O campo Fornecedor é obrigatório. Favor Verificar!<br/>"
        End If

        If drpProduto.SelectedIndex = 0 Then
            mensagemValidacao += "O campo Produto é obrigatório. Favor Verificar!<br/>"
        End If

        If txtQuantidade.Text = "" Or txtQuantidade.Text = "0" Then
            mensagemValidacao += "O campo Quantidade é obrigatório e não pode ser 0. Favor Verificar!<br/>"
        End If

        If String.IsNullOrEmpty(mensagemValidacao) Then
            Return True
        Else
            lblMensagem.Visible = True
            lblMensagem.Text = mensagemValidacao

            Return False
        End If

    End Function

End Class