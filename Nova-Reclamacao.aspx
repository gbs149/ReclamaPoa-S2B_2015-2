<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Nova-Reclamacao.aspx.cs" Inherits="ReclamaPoa2013.Nova_Reclamacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div class="form-group">
            <asp:Label ID="Label1" AssociatedControlID="txtNomeRec" runat="server" Text="Label">Título da Reclamação</asp:Label>
            <asp:TextBox class="form-control" ID="txtNomeRec" runat="server"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator CssClass="text-danger" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo obrigatório" ControlToValidate="txtNomeRec"></asp:RequiredFieldValidator>
        <br />

        <div class="form-group">
            <asp:Label ID="Label2" AssociatedControlID="txtDescRec" runat="server" Text="Label">Descrição</asp:Label>
            <asp:TextBox class="form-control" ID="txtDescRec" TextMode="MultiLine" Rows="5" Columns="60" runat="server"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator CssClass="text-danger" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo obrigatório" ControlToValidate="txtDescRec"></asp:RequiredFieldValidator>


        <div class="form-group">
            <asp:Label ID="Label3" AssociatedControlID="ddlBairros" runat="server" Text="Label">Bairro</asp:Label>
            <asp:DropDownList class="form-control" ID="ddlBairros" runat="server" AutoPostBack="True"></asp:DropDownList>
        </div>
        <asp:RequiredFieldValidator CssClass="text-danger" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo obrigatório" ControlToValidate="ddlBairros"></asp:RequiredFieldValidator>

        <div class="form-group">
            <asp:Label ID="Label4" AssociatedControlID="txtEndereco" runat="server" Text="Label">Endereço</asp:Label>
            <asp:TextBox class="form-control" ID="txtEndereco" runat="server"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator CssClass="text-danger" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo obrigatório" ControlToValidate="txtEndereco"></asp:RequiredFieldValidator>

        <div class="form-group">
            <asp:Label ID="Label6" AssociatedControlID="txtUrlImagem" runat="server" Text="Label">Link para imagem</asp:Label>
            <asp:TextBox class="form-control" ID="txtUrlImagem" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="Label5" AssociatedControlID="rblCategorias" runat="server" Text="Label">Categoria</asp:Label>
            <asp:RadioButtonList ID="rblCategorias" runat="server"></asp:RadioButtonList>
        </div>
        <asp:RequiredFieldValidator CssClass="text-danger" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo obrigatório" ControlToValidate="rblCategorias"></asp:RequiredFieldValidator>

        <asp:Button class="form-control" ID="btnSalvar" runat="server" Text="Registrar reclamação" OnClick="btnSalvar_Click" />

    </div>


</asp:Content>
