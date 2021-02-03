<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Deloitte_NF.Master" CodeBehind="NotaFiscalEditar.aspx.vb" Inherits="Deloitte.NF.Web.VB.NotaFiscalEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Editar Nota Fiscal</h2>
    <hr />

    <table>
        <tr>
            <td>Cliente
            </td>
            <td>&nbsp;
            </td>
            <td>Fornecedor
            </td>
            <td>&nbsp;
            </td>
            <td>Produto
            </td>
            <td>&nbsp;
            </td>
            <td>Quantidade
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="drpCliente" Width="410px" runat="server" CssClass="form-control"></asp:DropDownList>
            </td>
            <td>&nbsp;
            </td>
            <td>
                <asp:DropDownList ID="drpFornecedor" Width="410px" runat="server" CssClass="form-control"></asp:DropDownList>
            </td>
            <td>&nbsp;
            </td>
            <td>
                <asp:DropDownList ID="drpProduto" Width="410px" runat="server" CssClass="form-control"></asp:DropDownList>
            </td>
            <td>&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtQuantidade" runat="server" Width="100px" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="7" style="text-align: right">
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn btn-secondary" />
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnId" runat="server" Visible="false" />
    <asp:Label ID="lblMensagem" runat="server" Visible="false" CssClass="MensagemErro">lblMensagem</asp:Label>

</asp:Content>
