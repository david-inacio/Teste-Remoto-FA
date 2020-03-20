<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClienteEditar.aspx.cs" Inherits="GestaoClientes.Web.Cliente.ClienteEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row margin-top-10">
        <div class="col-md-12">
            <h3><asp:Literal ID="litAcaoDaPagina" runat="server"></asp:Literal></h3>

        </div>
    </div>

    <div class="row margin-top-10">
        <div class="col-md-12">
            <asp:PlaceHolder ID="phMensagem" runat="server" Visible="false">
                <div class="alert alert-warning">
                    <p>
                        <asp:Literal ID="litMensagem" runat="server" />
                    </p>
                </div>
            </asp:PlaceHolder>
        </div>
    </div>


    <div class="row margin-top-10">
        <div class="col-md-12">

            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <strong>Nome</strong>
                        <asp:TextBox ID="tbNome" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="tbNome" CssClass="errorValidate" runat="server" ErrorMessage="Digite um nome para continuar"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <strong>CPF</strong>
                         <asp:TextBox ID="tbCpf" CssClass="form-control cpf" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="tbCpf" CssClass="errorValidate" runat="server" ErrorMessage="Digite um número de CPF"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <div class="row">
               <div class="col-md-6">
                   <div class="form-group">
                       <strong>Tipo</strong>
                       <asp:DropDownList CssClass="form-control" ID="ddlTipo" runat="server"></asp:DropDownList>
                   </div>
                </div>
                <div class="col-md-6">
                        <div class="form-group">
                        <strong>Situação</strong>
                        <asp:DropDownList CssClass="form-control" ID="ddlSituacao" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="row margin-top-10">
                <div class="col-md-12">
                    <div class="form-group">
                        <strong>Sexo</strong>
                        <asp:RadioButtonList  ID="rbSexo" runat="server" OnSelectedIndexChanged="rbSexo_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Value="M">Masculino &nbsp;</asp:ListItem>
                            <asp:ListItem Value="F">Feminino &nbsp;</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ControlToValidate="rbSexo" CssClass="errorValidate" runat="server" ErrorMessage="Selecione uma opção"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <div class="row margin-top-10">
        <div class="col-md-12">
            <div class="pull-right">
                <a href="Clientes.aspx" title="Voltar" class="btn btn-warning"><i class="fa fa-backward"></i> Voltar</a>
                <asp:LinkButton runat="server" ID="lkbSalvar" CausesValidation="true" title="Salvar Cliente" class="btn btn-success"><i class="fa fa-save"></i> Salvar</asp:LinkButton>
            </div>
        </div>
    </div>

    <input type="hidden" id="RESULT_idHidden"  class="RESULT_idHidden" runat="server" />     

    <%: Scripts.Render("~/bundles/mask") %>

</asp:Content>
