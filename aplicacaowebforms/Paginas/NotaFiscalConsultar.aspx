<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Deloitte_NF.Master" CodeBehind="NotaFiscalConsultar.aspx.vb" Inherits="Deloitte.NF.Web.VB.NotaFiscalConsultar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Listar Nota Fiscal</h2>
    <hr />
    <asp:Button ID="btnNovo" runat="server" Text="Novo" CssClass="btn btn-primary"/>&nbsp;
    <asp:Button ID="btnRelatorio" runat="server" Text="Relatório" CssClass="btn btn-primary"/>

    <div>
        <br />
    </div>
    <asp:GridView Width="100%" ID="dtgNotaFiscal" CssClass="table table-bordered" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="false"
        OnRowDeleting="dtgNotaFiscal_RowDeleting" OnRowEditing="dtgNotaFiscal_RowEditing">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
            <asp:BoundField DataField="Produto" HeaderText="Produto" SortExpression="Produto" />
            <asp:BoundField DataField="Fornecedor" HeaderText="Fornecedor" SortExpression="Fornecedor" />
            <asp:BoundField DataField="Qtd." HeaderText="Qtd." SortExpression="Qtd." />
            <asp:BoundField DataField="Data" HeaderText="Data" SortExpression="Data" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="deleteRow" runat="server" CommandName="Delete" Text="Excluir" CssClass="btn btn-danger" />
                    <asp:LinkButton ID="editRow" runat="server" CommandName="Edit" Text="Editar" CssClass="btn btn-primary" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" FirstPageText="Primeira" LastPageText="Última" />
    </asp:GridView>


</asp:Content>
