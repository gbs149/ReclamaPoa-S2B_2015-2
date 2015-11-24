<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="ReclamaPoa2013.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <ul>
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
</asp:Content>
