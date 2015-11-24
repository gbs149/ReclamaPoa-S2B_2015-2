<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reclamacoes.aspx.cs" Inherits="ReclamaPoa2013.Reclamacoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Reclamações</h1>

    <asp:ListView 
        ID="lvReclamacoes" 
        runat="server"
        ItemType="ReclamaPoa2013.Models.ReclamacaoViewModel"
        SelectMethod="getReclamacoes">
        <EmptyDataTemplate>
            <h1>Nenhuma reclamação encontrada</h1>
        </EmptyDataTemplate>

        <ItemTemplate>
            <h2><%#:Item.Titulo %></h2><br />
            <%#:Item.Descricao %><br />
            <%#:Item.Data.ToShortDateString() %><br />
            <%#:Item.Situacao %><br />
            <%#:Item.Endereco %><br />
            <%#:Item.Bairro %><br />
            <%#:Item.Categoria %><br /><br />
        </ItemTemplate>

    </asp:ListView>
</asp:Content>
