<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="GestaoClientes.Web.Cliente.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row margin-top-10">
        <div class="col-md-12">
            <h3>Lista de Clientes</h3>

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
            <div class="pull-right">
                <a href="ClienteEditar.aspx" title="Adicionar um novo cliente" class="btn btn-info">Novo Cliente</a>
            </div>
        </div>
    </div>

    <div class="row margin-top-10">
        <div class="col-md-12">
            <asp:Repeater ID="clienteRepeater" runat="server">
                <HeaderTemplate>
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th>Cód.</th>
                                <th>Nome</th>
                                <th>CPF</th>
                                <th>Sexo</th>
                                <th>Tipo</th>
                                <th>Situação</th>
                                <th style="text-align: center;">Editar</th>
                                <th style="text-align: center;">Excluir</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="odd gradeX" id='linha_<%# Eval("ID") %>_tr'>

                        <td style="width: 5%"><%# Eval("ID") %></td>
                        <td style="width: 17%"><%# Eval("Nome") %></td>
                        <td style="width: 17%"><%# Eval("CPF") %></td>
                        <%--<td style="width: 17%"><%# Eval("Sexo") %></td>--%>
                        <td style="width: 17%"><%# Eval("Sexo").ToString() == "M" ? "Masculino" : "Feminino" %></td>
                        <td style="width: 17%"><%# Eval("TipoLabel") %></td>
                        <td style="width: 17%"><%# Eval("SituacaoLabel") %></td>
                        <td style="width: 5%; text-align: center">
                            <a href="ClienteEditar.aspx?id=<%# Eval("ID") %>"><i class="fa fa-pencil fa-lg"></i></a>
                        </td>
                        <td style="width: 5%; text-align: center">
                            <asp:LinkButton ID="lkbExcluir" runat="server" OnCommand="DelItem" CommandArgument='<%# Eval("ID") %>'>
                                            <i class='fa  fa-trash-o fa-lg'></i></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                            </table>
                </FooterTemplate>

            </asp:Repeater>
        </div>
    </div>

</asp:Content>
