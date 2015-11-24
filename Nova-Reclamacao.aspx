<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Nova-Reclamacao.aspx.cs" Inherits="ReclamaPoa2013.Nova_Reclamacao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--TODO verificação de campos obrigatórios --%>

    <asp:Label ID="Label1" AssociatedControlID="txtNomeRec" runat="server" Text="Label">Título da Reclamação</asp:Label>
    <asp:TextBox ID="txtNomeRec" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="text-danger" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo obrigatório" ControlToValidate="txtNomeRec"></asp:RequiredFieldValidator>
    <br />

    <asp:Label ID="Label2" AssociatedControlID="txtDescRec" runat="server" Text="Label">Descrição</asp:Label>
    <asp:TextBox ID="txtDescRec" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="text-danger" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo obrigatório" ControlToValidate="txtDescRec"></asp:RequiredFieldValidator>


    <asp:Label ID="Label3" AssociatedControlID="ddlBairros" runat="server" Text="Label">Bairro</asp:Label>
    <asp:DropDownList ID="ddlBairros" runat="server" AutoPostBack="True"></asp:DropDownList>
    <asp:RequiredFieldValidator CssClass="text-danger" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo obrigatório" ControlToValidate="ddlBairros"></asp:RequiredFieldValidator>

    <asp:Label ID="Label4" AssociatedControlID="txtEndereco" runat="server" Text="Label">Endereço</asp:Label>
    <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator CssClass="text-danger" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo obrigatório" ControlToValidate="txtEndereco"></asp:RequiredFieldValidator>

    <asp:Label ID="Label6" AssociatedControlID="txtUrlImagem" runat="server" Text="Label">Link para imagem</asp:Label>
    <asp:TextBox ID="txtUrlImagem" runat="server"></asp:TextBox>

    <asp:Label ID="Label5" AssociatedControlID="rblCategorias" runat="server" Text="Label">Categoria</asp:Label>
    <asp:RadioButtonList ID="rblCategorias" runat="server"></asp:RadioButtonList>
    <asp:RequiredFieldValidator CssClass="text-danger" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo obrigatório" ControlToValidate="rblCategorias"></asp:RequiredFieldValidator>

    <asp:Button ID="btnSalvar" runat="server" Text="Registrar reclamação" OnClick="btnSalvar_Click" />

</asp:Content>
