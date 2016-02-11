<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bairros.aspx.cs" Inherits="ReclamaPoa2013.Bairros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   
    <br />
    <br />
    <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" Height="61px" Width="133px"></asp:DropDownList>
    <h3>Data Inicio</h3>
    <asp:Calendar ID="calInicio" runat="server"></asp:Calendar>
    <h3>Data Final</h3>
    <asp:Calendar ID="calFim" runat="server"></asp:Calendar>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <br />
    <br />
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