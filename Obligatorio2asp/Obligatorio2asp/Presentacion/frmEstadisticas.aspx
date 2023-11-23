<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEstadisticas.aspx.cs" Inherits="Obligatorio2asp.Presentacion.frmEstadisticas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p></p>
    <p>
    <asp:Label ID="Label1" runat="server" Text="1) Reporte de la recaudación total"></asp:Label>
        <p>
        <asp:Button ID="btnConsulta1" runat="server" OnClick="btnConsulta1_Click" Text="Consulta 1" />
    <asp:Label ID="lblConsulta1" runat="server" Text="..."></asp:Label>
        </p>
    <p>3) Mostrar el autor/res que vendieron más libros.</p>
    <p>
    
        <asp:ListBox ID="lstConsulta3" runat="server" Height="116px" Width="309px"></asp:ListBox>
    
        <asp:Button ID="btnConsulta3" runat="server" OnClick="btnConsulta3_Click" Text="Consulta 3" />
    
        </p>
    <p>
        4) Mostrar los libros que vendieron más vendidos.</p>
    <p>
    
        <asp:ListBox ID="lstConsulta4" runat="server" Height="116px" Width="307px"></asp:ListBox>
    
        <asp:Button ID="btnConsulta4" runat="server" OnClick="btnConsulta4_Click" Text="Consulta 4" />
    
        </p>
    <p>
        5) Dado un lector mostrar los títulos de los libros que compró</p>
    <p>
    
        &nbsp;<asp:ListBox ID="lstConsulta5" runat="server" Height="116px" Width="297px"></asp:ListBox>
    
        <asp:Button ID="btnConsulta5" runat="server" OnClick="btnConsulta5_Click" Text="Consulta 5" />
    
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    
        </p>
    <p>
        <span>6) Mostrar el nombre del país que más publicaciones presentó.</span></p>
    <p>
        <asp:ListBox ID="lstConsulta6" runat="server" Height="116px" Width="298px"></asp:ListBox>
    
        <asp:Button ID="btnConsulta6" runat="server" Text="Consulta 6" OnClick="btnConsulta6_Click" />
    
        </p>
    <p>
        7<span>) Dado un género mostrar todos los libros ordenados por </span>
    
        </p>
    <p>
        <asp:ListBox ID="lstConsulta7" runat="server" Height="116px" Width="298px"></asp:ListBox>
    
        <asp:Button ID="btnConsulta7" runat="server" Text="Consulta 7" OnClick="btnConsulta7_Click"  />
    
        <asp:TextBox ID="txtGenero" runat="server"></asp:TextBox>
    
        </p>
</asp:Content>
