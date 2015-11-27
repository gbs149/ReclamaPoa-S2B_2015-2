<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="ReclamaPoa2013.Categorias" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   
    <br />
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server" Height="61px" Width="133px"></asp:DropDownList>
    </br>
    </br>
    <asp:ListView
        ID="lvbairros"
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

<%--<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <ul>
        <li style="height: 464px; margin-top: 51px">
        <asp:ListView
            ID="ListaCategorias"
            ItemType="ReclamaPoa2013.Models.Categoria"
            runat="server"
            SelectMethod="getCategorias">
            <ItemTemplate>
                <ul>
                    <%#:Item.Nome %>
                </ul>
            </ItemTemplate>
        </asp:ListView>
    </ul>
</asp:Content>--%>
