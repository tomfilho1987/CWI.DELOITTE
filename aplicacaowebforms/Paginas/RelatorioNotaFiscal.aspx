<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Deloitte_NF.Master" CodeBehind="RelatorioNotaFiscal.aspx.vb" Inherits="Deloitte.NF.Web.VB.RelatorioNotaFiscal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Relatório de Nota Fiscal por Produto</h2>
    <hr />

    <table>
        <tr>
            <td>Produto
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="drpProduto" Width="410px" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpProduto_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
    </table>
    <div>
        <br />
    </div>
    <asp:GridView Width="100%" ID="dtgRelatorio" CssClass="table table-bordered" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Produto" HeaderText="Produto" SortExpression="Produto" />
            <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" SortExpression="Quantidade" />
            <asp:BoundField DataField="Data" HeaderText="Data" SortExpression="Data" />
        </Columns>
        <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" FirstPageText="Primeira" LastPageText="Última" />
    </asp:GridView>
    <asp:Label ID="lblMensagem" runat="server"></asp:Label>
    <table style="width: 100%">
        <tr>
            <td style="text-align: right">
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn btn-secondary" />
            </td>
        </tr>
    </table>
</asp:Content>
