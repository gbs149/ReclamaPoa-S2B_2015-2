<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reclamacoes.aspx.cs" Inherits="ReclamaPoa2013.Reclamacoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div class="btn-group">
        <ul>
            <asp:ListView
                ID="ListaCategorias"
                ItemType="ReclamaPoa2013.Models.Categoria"
                runat="server"
                SelectMethod="getCategorias">
                <ItemTemplate>
                    <ul>
                        <button type="button" class="btn btn-sm btn-primary"><%#:Item.Nome %></button>
                    </ul>
                </ItemTemplate>
            </asp:ListView>
        </ul>
    </div>--%>

    <%--<h1>Reclamações</h1>--%>

    <asp:ListView
        ID="lvReclamacoes"
        runat="server"
        ItemType="ReclamaPoa2013.Models.ReclamacaoViewModel"
        SelectMethod="getReclamacoes">
        <EmptyDataTemplate>
            <h1>Nenhuma reclamação encontrada</h1>
        </EmptyDataTemplate>

        <ItemTemplate>
            <div class="col-sm-4">
                <a href="Detalhes.aspx?id=<%#:Item.ReclamacaoId %>">
                    <h2><%#:Item.Titulo %></h2>
                </a>
                <br />
                <img class="img-responsive" src="<%#:Item.UrlImagem %>" />
                <p><%#:Item.Data.ToShortDateString() %></p>
                <span class="<%#:Item.SituacaoClass %>"><%#:Item.Situacao %></span>
                <p><%#:Item.Bairro %></p>
                <p><%#:Item.Categoria %></p>
                <br />
            </div>
        </ItemTemplate>

    </asp:ListView>
</asp:Content>
