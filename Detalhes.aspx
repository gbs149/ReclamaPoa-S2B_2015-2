<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalhes.aspx.cs" Inherits="ReclamaPoa2013.Detalhes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView 
        ID="detalhesReclamacao" 
        runat="server"
        ItemType="ReclamaPoa2013.Models.ReclamacaoViewModel"
        SelectMethod="getReclamacao">
        <ItemTemplate>
            <h1><%#:Item.Titulo%></h1>

            <p><strong><%#:Item.Categoria%></strong></p>

            <p><%#:Item.Bairro%></p>

            <p><%#:Item.Data%></p>
            <p><%#:Item.Situacao%></p>
            <p><%#:Item.Descricao%></p>

            <img src="<%#:Item.UrlImagem%>" />

            <p><em><%#:Item.Usuario%></em></p>


        </ItemTemplate>

        
    </asp:FormView>
</asp:Content>
