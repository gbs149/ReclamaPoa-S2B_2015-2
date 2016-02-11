<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pesquisa.aspx.cs" Inherits="ReclamaPoa2013.Pesquisa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   

    <br />
    <br />
    
    <asp:DropDownList ID="ddlbairro" AutoPostBack="true" runat="server"></asp:DropDownList>
    <asp:DropDownList ID="ddlcategoria" AutoPostBack="true" runat="server"></asp:DropDownList>
    <h3>Data Inicio</h3>
    <asp:Calendar ID="calInicio" AutoPostBack="true" runat="server"></asp:Calendar>
    <h3>Data Final</h3>
    <asp:Calendar ID="calFim" AutoPostBack="true" runat="server"></asp:Calendar>
    <asp:Button ID="Btnpesquisa" runat="server" Text="Button" OnClick="Button1_Click" />
    <br />
    <br />

    <asp:ListView 
        ID="lvpesquisas" 
        runat="server" 
        ItemType="ReclamaPoa2013.Models.ReclamacaoViewModel" 
        SelectMethod="getReclamacoes" >

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
