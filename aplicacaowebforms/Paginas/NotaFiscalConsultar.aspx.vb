Public Class NotaFiscalConsultar
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

                Consultar(True)

            Catch ex As Exception
                Throw ex
            End Try

        End If

    End Sub

    Private Sub Consultar(ByVal lblPageIndex As Boolean)

        dtgNotaFiscal.DataSource = Nothing
        dtgNotaFiscal.DataBind()

        If lblPageIndex Then
            dtgNotaFiscal.PageIndex = 0
        End If

        dtgNotaFiscal.DataSource = notaFiscal.ListarNota()
        dtgNotaFiscal.DataBind()

    End Sub

    Protected Sub DtgNotaFiscal_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles dtgNotaFiscal.PageIndexChanging

        Try

            dtgNotaFiscal.PageIndex = e.NewPageIndex

            Consultar(False)

        Catch ex As Exception

            Session("erro") = ex.Message
            Response.Redirect("../Paginas/Erro.aspx")

        End Try

    End Sub

    Protected Sub DtgNotaFiscal_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles dtgNotaFiscal.RowCreated

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer'")

        End If

    End Sub

    Protected Sub DtgNotaFiscal_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles dtgNotaFiscal.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes.Add("onclick", "javascript:document.location='../Paginas/NotaFiscalEditar.aspx?Isn=" & e.Row.Cells(0).Text & "';")
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right

        End If

    End Sub

    Protected Sub DtgNotaFiscal_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles dtgNotaFiscal.RowDeleting

        Dim title As String = "Exclusão de Nota Fiscal"
        Dim msg As String = "Deseja excluir o item?"
        Dim style As MsgBoxStyle = MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation
        Dim response As MsgBoxResult

        response = MsgBox(msg, style, title)

        If response = MsgBoxResult.Yes Then

            Dim eIndex As Integer = e.RowIndex

            notaFiscal.IdNotaFiscal = dtgNotaFiscal.Rows(e.RowIndex).Cells(0).Text

            notaFiscal.ExcluirNota()

            Consultar(True)

        End If

    End Sub

    Protected Sub DtgNotaFiscal_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles dtgNotaFiscal.RowEditing

        Response.Redirect("../Paginas/NotaFiscalEditar.aspx?Id=" + dtgNotaFiscal.Rows(e.NewEditIndex).Cells(0).Text)

    End Sub

    Protected Sub BtnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click

        Response.Redirect("../Paginas/NotaFiscalIncluir.aspx")

    End Sub

    Protected Sub BtnRelatorio_Click(sender As Object, e As EventArgs) Handles btnRelatorio.Click

        Response.Redirect("../Paginas/RelatorioNotaFiscal.aspx")

    End Sub
End Class