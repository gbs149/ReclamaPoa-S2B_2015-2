<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="painel-de-controle.aspx.cs" Inherits="ReclamaPoa2013.painel_de_controle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

    <h1>Painel de controle</h1>

    <div>Total de reclamações:</div>
    <div><asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></div>
    <div>Total de Comentários:</div>
    <div><asp:Label ID="lblTotalComentarios" runat="server" Text="Label"></asp:Label></div>
    <div>Média de <asp:Label ID="lblMediaComentGeral" runat="server" Text="Label"></asp:Label> comentários por reclamação.</div>



    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div class="col-sm-4">
                <p>Filtrar por Categoria</p>
                <asp:DropDownList ID="ddlCategorias" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="col-sm-4">
                <p>Filtrar por Bairro</p>
                <asp:DropDownList ID="ddlBairros" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBairros_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="col-sm-4">
                <p>Filtrar por período</p>
                <p>
                    Data inicial:
                <asp:TextBox ID="txtDataInicio" runat="server" AutoPostBack="true" OnTextChanged="txtDataInicio_TextChanged"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" TargetControlID="txtDataInicio" ID="CalendarExtender1" runat="server" />
                </p>

                <p>
                    Data final: 
                <asp:TextBox ID="txtDataFinal" runat="server" AutoPostBack="true" OnTextChanged="txtDataFinal_TextChanged"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" TargetControlID="txtDataFinal" ID="CalendarExtender2" runat="server" />
                </p>
            </div>

            <div>
                <%--<asp:Button ID="Button1" runat="server" Text="Filtrar" OnClick="Button1_Click" />--%>
                <div>                    
                <asp:Label ID="lblSubTotal" runat="server" Text=""></asp:Label>
                </div>
                <div><asp:Label ID="lblMediaFiltrada" runat="server" Text=""></asp:Label></div>
                <div>
                    <asp:Label ID="lblAbertas" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblResolvidas" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblEncerradas" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
