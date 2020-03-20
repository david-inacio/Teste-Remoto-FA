using GestaoClientes.Web.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace GestaoClientes.Web.Cliente
{
    public partial class Clientes : System.Web.UI.Page
    {

        ClienteServiceClient servico = new ClienteServiceClient();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                carregaDados();
            }            

        }

        private void carregaDados()
        {

            var listClientes = servico.GetClientes().ToList();
            var listClienteTipo = servico.GetClienteTipos().ToList();
            var listClientesSituacao = servico.GetClienteSituacoes().ToList();       

            List<dynamic> listTable = new List<dynamic>();

            foreach (var cliente in listClientes)
            {
                listTable.Add(new
                {
                    ID = cliente.ID,
                    Nome = cliente.Nome,
                    CPF = cliente.CPF,
                    Sexo = cliente.Sexo,
                    TipoLabel = listClienteTipo
                            .Where(t => t.ID == cliente.TipoID).FirstOrDefault().Descricao,
                    SituacaoLabel = listClientesSituacao
                            .Where(t => t.ID == cliente.SituacaoID).FirstOrDefault().Descricao
                });
            }

            clienteRepeater.DataSource = listTable.ToList();
            clienteRepeater.DataBind();

            if (clienteRepeater.Items.Count < 1)
            {
                clienteRepeater.Visible = false;
                phMensagem.Visible = true;
                litMensagem.Text = "Nenhum cliente foi encontrado!";
            }
            else
            {
                clienteRepeater.Visible = true;
                phMensagem.Visible = false;
            }
        }


        protected void DelItem(object sender, CommandEventArgs e)
        {

            try
            {

                var cliente = servico.GetCliente(int.Parse(e.CommandArgument.ToString()));

                if (cliente != null)
                {
                    servico.DeleteCliente(cliente.ID);
                    Response.Redirect("Clientes.aspx");
                }
            }
            catch (Exception ex)
            {
                phMensagem.Visible = true;
                litMensagem.Text = "Ocorreu um erro ao executar a operação: " + ex.Message;
            }

        }

    }
}