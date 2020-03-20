<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GestaoClientes.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Sistema básico de Gestão de Clientes</h2>
        <p class="lead">Aplicação desenvolvida em C# (Asp.Net) com Banco de Dados SQL Server, estrutura em camadas, regra de negócio e acesso a Dados encapsulada em uma Api do tipo (WCF)</p>
        <p><a href="/Cliente/Clientes.aspx" class="btn btn-primary btn-lg">Lista de Clientes &raquo;</a></p>
    </div>

</asp:Content>
