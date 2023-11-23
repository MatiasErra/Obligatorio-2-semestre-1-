<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPersonas.aspx.cs" Inherits="Obligatorio2asp.Presentacion.frmPersonas" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p style="height: 65px">
        &nbsp;</p>
    <p style="height: 45px">
    <asp:Label ID="Label4" runat="server" Text="Gestor de Alumnos" Font-Bold="True"></asp:Label></p>
    <p>
        <asp:Label ID="Label1" width="80px" runat="server" Text="Id" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="txtId" width="125px" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" width="80px" Text="Nombre" 
            Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txtNombre" width="128px" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label3" width="80px"  runat="server" Text="Apellido" 
            Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txtApellido" width="131px" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label5" width="80px" runat="server" Text="Nacionalidad" Font-Bold="True"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtNacionalidad" width="112px" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label6" width="80px" runat="server" Text="Fecha de nacimiento" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txtFechaDeNac" width="112px" runat="server"></asp:TextBox>
    </p>
      <asp:Label ID="Label7" width="80px" runat="server" Text="Fecha de Fallecido" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txtFallecido" width="112px" runat="server"></asp:TextBox>
    <p>
    <p>
        <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBaja" runat="server" Text="Baja" OnClick="btnBaja_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMensajes" runat="server" Text="."></asp:Label>
</p>
    <p>
        <asp:ListBox ID="lstAutor" runat="server" Width="322px"></asp:ListBox>
        <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" OnClick="btnSeleccionar_Click" />
</p>
    <p>
        &nbsp;</p>
</asp:Content>

