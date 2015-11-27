<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="painel-de-controle.aspx.cs" Inherits="ReclamaPoa2013.painel_de_controle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

    <h1>Painel de controle</h1>

    <h2>Total de reclamações</h2>
    <strong>
        <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></strong>


    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div class="col-sm-4">
                <p>Filtrar por Categoria</p>
                <asp:DropDownList ID="ddlCategorias" runat="server"></asp:DropDownList>
            </div>

            <div class="col-sm-4">
                <p>Filtrar por Bairro</p>
                <asp:DropDownList ID="ddlBairros" runat="server"></asp:DropDownList>
            </div>

            <div class="col-sm-4">
                <p>Filtrar por período</p>
                <p>
                    Data de início:
                <asp:TextBox ID="txtDataInicio" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" TargetControlID="txtDataInicio" ID="CalendarExtender1" runat="server" />
                </p>

                <p>
                    Data final: 
                <asp:TextBox ID="txtDataFinal" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" TargetControlID="txtDataFinal" ID="CalendarExtender2" runat="server" />
                </p>
            </div>

            <div>
                <asp:Button ID="Button1" runat="server" Text="Filtrar" OnClick="Button1_Click" />
                <p>
                    Total de reclamações: 
                <asp:Label ID="lblSubTotal" runat="server" Text=""></asp:Label>
                </p>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
