<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalhes.aspx.cs" Inherits="ReclamaPoa2013.Detalhes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

    <asp:FormView
        ID="detalhesReclamacao"
        runat="server"
        ItemType="ReclamaPoa2013.Models.ReclamacaoViewModel"
        SelectMethod="getReclamacao">
        <ItemTemplate>
            <h1><%#:Item.Titulo%></h1>
            <p><strong><%#:Item.Categoria%></strong></p>
            <p><%#:Item.Bairro%></p>
            <p><%#:Item.Data%></p
                >
            <p><span class="label label-warning"><%#:Item.Situacao%></span></p>

            <asp:Label ID="lblSituacao" runat="server" Text="Label"></asp:Label>

            <p><%#:Item.Descricao%></p>
            <img src="<%#:Item.UrlImagem%>" />
            <p><em><%#:Item.Usuario%></em></p>
        </ItemTemplate>
    </asp:FormView>

    <asp:TextBox ID="txtComentario"
        TextMode="MultiLine"
        Columns="50"
        Rows="5"
        runat="server" />
    <asp:Button ID="btnComentario" runat="server" Text="Salvar" OnClick="btnComentario_Click" />

    <div class="panel-group">
        <asp:ListView
            ID="lvComentarios"
            ItemType="ReclamaPoa2013.Models.ComentarioViewModel"
            SelectMethod="getComentarios"
            runat="server">
            <ItemTemplate>
                <div class="panel panel-default">
                    <div class="panel-heading"><%#:Item.Usuario %></div>
                    <div class="panel-body"><%#:Item.Texto %></div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"></asp:UpdatePanel>--%>
</asp:Content>
