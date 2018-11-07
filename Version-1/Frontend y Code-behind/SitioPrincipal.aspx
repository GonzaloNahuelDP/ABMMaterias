<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SitioPrincipal.aspx.cs" Inherits="AplicacionWeb.SitioPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Materias</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        <h1>Materias</h1>

        <asp:Label ID="lblCodigo" runat="server" Text="Código"></asp:Label>
        :&nbsp;<asp:TextBox ID="txtCodigo" runat="server" OnTextChanged="TextBoxCodigo_Changed"></asp:TextBox>
        <br />

        <asp:Label ID="lblMateria" runat="server" Text="Materia"></asp:Label>
        :&nbsp;<asp:TextBox ID="txtMateria" runat="server" OnTextChanged="TextBoxMateria_Changed" Enabled="False"></asp:TextBox>
        <br />

        <asp:Label ID="lblNota" runat="server" Text="Nota"></asp:Label>
        :&nbsp;<asp:TextBox ID="txtNota" runat="server" OnTextChanged="TextBoxNota_Changed" Enabled="False"></asp:TextBox>
        <br />

        <br />
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        &nbsp;<asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" Enabled="False" />
        &nbsp;<asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" Enabled="False" />
        &nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" Enabled="False" />
        &nbsp;<asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />

        <br />
        <br />
        <b><asp:Label ID="lblMensaje" runat="server" ForeColor="#009933" Enabled="False"></asp:Label></b>
        <br />
        <br />
        <asp:GridView ID="tablaDeMaterias" runat="server" Height="182px" Width="531px" AutoGenerateColumns="False" BackColor="#CCFFCC" BorderColor="#009900" DataKeyNames="codigo" DataSourceID="DataSourceMaterias" ForeColor="Black">
            <Columns>
                <asp:BoundField DataField="codigo" HeaderText="codigo" ReadOnly="True" SortExpression="codigo" />
                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                <asp:BoundField DataField="nota" HeaderText="nota" SortExpression="nota" />
            </Columns>
            <EditRowStyle ForeColor="White" />
        </asp:GridView>
            <asp:SqlDataSource ID="DataSourceMaterias" runat="server" ConnectionString="<%$ ConnectionStrings:materias_bdConnectionString %>" SelectCommand="SELECT * FROM [materias]"></asp:SqlDataSource>
        <br />
        </div>
    </form>
</body>
</html>