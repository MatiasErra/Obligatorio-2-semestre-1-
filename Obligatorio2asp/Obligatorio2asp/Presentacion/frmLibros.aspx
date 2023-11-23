<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmLibros.aspx.cs" Inherits="Obligatorio2asp.Presentacion.frmLibros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p style="height: 65px">
        &nbsp;</p>
    <p style="height: 45px">
    <asp:Label ID="Label4" runat="server" Text="Gestor de Libros" Font-Bold="True"></asp:Label></p>
    <p>
        <asp:Label ID="Label1" width="80px" runat="server" Text="Id" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="txtId" width="125px" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" width="80px" Text="Titulo" 
            Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txtTitulo" width="128px" runat="server"></asp:TextBox>
    </p>
     <p>
        <asp:Label ID="Label9" runat="server" width="80px" Text="Año" 
            Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txtAno" width="128px" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label3" width="80px"  runat="server" Text="Genero" 
            Font-Bold="True"></asp:Label>
        <asp:ListBox ID="lstGeneros" runat="server" Width="190px" OnInit="lstGeneros_Init"></asp:ListBox>
    </p>
     <p>
        <asp:Label ID="Label7" width="80px"  runat="server" Text="Autor" 
            Font-Bold="True"></asp:Label>
        <asp:ListBox ID="lstAutor" runat="server" Width="190px" OnInit="lstAutor_Init" ></asp:ListBox>
    </p>
        <p>
        <asp:Label ID="Label8" width="80px"  runat="server" Text="Pais" 
            Font-Bold="True"></asp:Label>
        <asp:ListBox ID="lstPais" runat="server" Width="190px" OnInit="lstPais_Init"></asp:ListBox>
    </p>
    <p>
        <asp:Label ID="Label5" width="80px" runat="server" Text="Precio" Font-Bold="True"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtPrecio" width="158px" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label6" width="96px" runat="server" Text="Comentario" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txtComentario" width="161px" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label10" width="96px" runat="server" Text="Tipo de orden" Font-Bold="True"></asp:Label>
       
        <asp:RadioButton ID="rbtnIngreso" name="orden" runat="server" GroupName="orden"  Text="Por Ingreso" Checked="True" OnCheckedChanged="rbtnIngreso_CheckedChanged" AutoPostBack="true" />
        <asp:RadioButton ID="rbtnNombre" name="orden" runat="server" GroupName="orden" Text="Por Titulo" OnCheckedChanged="rbtnNombre_CheckedChanged" AutoPostBack="true"  />
&nbsp;<p>
        <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click"  />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBaja" runat="server" Text="Baja" OnClick="btnBaja_Click"  />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click"  />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click"  />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMensajes" runat="server" Text="."></asp:Label>
</p>
    <p>
        <asp:ListBox ID="lstLibro" runat="server" Width="384px" OnInit="lstLibro_Init" ></asp:ListBox>
        <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" OnClick="btnSeleccionar_Click"  />
</p>
    <p>
        &nbsp;</p>
</asp:Content>
