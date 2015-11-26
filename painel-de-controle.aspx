<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="painel-de-controle.aspx.cs" Inherits="ReclamaPoa2013.painel_de_controle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Painel de controle</h1>

    <h2>Total de reclamações: 
        <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
    </h2>

    <h3>Categoria</h3>
    <asp:DropDownList ID="ddlCategorias" runat="server"></asp:DropDownList>

    <h3>Bairro</h3>
    <asp:DropDownList ID="ddlBairros" runat="server"></asp:DropDownList>

    <h3>Data</h3>
    <asp:Calendar ID="calInicio" runat="server"></asp:Calendar>
    <asp:Calendar ID="calFim" runat="server"></asp:Calendar>

    <asp:Button ID="Button1" runat="server" Text="Filtrar" OnClick="Button1_Click" />

    <p>
        Total de reclamações: 
        <asp:Label ID="lblSubTotal" runat="server" Text=""></asp:Label>
    </p>

</asp:Content>
