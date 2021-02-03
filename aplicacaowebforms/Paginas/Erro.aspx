<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Erro.aspx.vb" Inherits="Deloitte.NF.Web.VB.Erro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Nota Fiscal Web</title>
    <link href="../Estilos/Estilo.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%">
                <tr>
                    <td class="CabecalhoPagina">Erro
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td class="MensagemErro">
                        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr align="center">
                    <td>
                        <asp:Button ID="btnOK" runat="server" CssClass="Botao" Text="OK" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>