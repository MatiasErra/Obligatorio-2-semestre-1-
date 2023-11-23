<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmVentas.aspx.cs" Inherits="Obligatorio2asp.Presentacion.frmVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p style="height: 65px">
        &nbsp;</p>
    <p style="height: 45px">
    <asp:Label ID="Label4" runat="server" Text="Gestor de Ventas" Font-Bold="True"></asp:Label></p>
    <p>
        <asp:Label ID="Label1" width="80px" runat="server" Text="Id" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="txtId" width="125px" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" width="115px" Text="Fecha vendido" 
            Font-Bold="True"></asp:Label>
    </p>
<p>
        <asp:Calendar ID="dtFecha" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="154px" NextPrevFormat="ShortMonth" Width="303px">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
            <DayStyle BackColor="#CCCCCC" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
            <TodayDayStyle BackColor="#999999" ForeColor="White" />
        </asp:Calendar>
    </p>
     <p>
        <asp:Label ID="Label9" runat="server" width="80px" Text="Libro" 
            Font-Bold="True"></asp:Label>
        <asp:ListBox ID="lstLibros" runat="server" Width="190px" OnInit="lstLibros_Init"></asp:ListBox>
    </p>
     <p>
        <asp:Label ID="Label7" width="80px"  runat="server" Text="Lector" 
            Font-Bold="True"></asp:Label>
        <asp:ListBox ID="lstLectores" runat="server" Width="190px" OnInit="lstLectores_Init"></asp:ListBox>
    </p>
        
    <p>
        <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click"  />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBaja" runat="server" Text="Baja" OnClick="btnBaja_Click"  />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar"  />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMensajes" runat="server" Text="."></asp:Label>
</p>
    <p>
        <asp:ListBox ID="lstVentas" runat="server" Width="322px" OnInit="lstVentas_Init"></asp:ListBox>
        <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" OnClick="btnSeleccionar_Click"  />
</p>
    <p>
        &nbsp;</p>
</asp:Content>
