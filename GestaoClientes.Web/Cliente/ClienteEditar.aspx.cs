using GestaoClientes.Web.ServiceReference1;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace GestaoClientes.Web.Cliente
{
    public partial class ClienteEditar : System.Web.UI.Page
    {

        ClienteServiceClient servico = new ClienteServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

            Inicializar();

            int id = 0;

            if (!IsPostBack)
            {
                CarregarListas();

                if (!string.IsNullOrEmpty(RESULT_idHidden.Value))
                {
                    id = Convert.ToInt32(Request.QueryString["id"]);
                    Carrega(id);
                    litAcaoDaPagina.Text = "Editar Cliente";
                }
                else
                {
                    litAcaoDaPagina.Text = "Adicionar Cliente";
                }
            }
        }


        private void Carrega(int id)
        {
            var cliente = servico.GetCliente(id);

            ddlTipo.SelectedValue = Convert.ToString(cliente.TipoID);
            ddlSituacao.SelectedValue = Convert.ToString(cliente.SituacaoID);

            tbNome.Text = cliente.Nome;
            tbCpf.Text = cliente.CPF;            

            if (cliente.Sexo == char.Parse("M"))
            {
                rbSexo.SelectedValue = "Masculino";
                rbSexo.Items.FindByValue("M").Selected = true;
            }
            else
            {
                rbSexo.SelectedValue = "Feminino";
                rbSexo.Items.FindByValue("F").Selected = true;
            }               

        }


        private void CarregarListas()
        {

            var listClienteTipo = servico.GetClienteTipos().ToList();
            var listClientesSituacao = servico.GetClienteSituacoes().ToList();

            var tipos = listClienteTipo;
            ddlTipo.DataSource = tipos.ToList();
            ddlTipo.DataTextField = "Descricao";
            ddlTipo.DataValueField = "ID";
            ddlTipo.DataBind();

            var situacoes = listClientesSituacao;
            ddlSituacao.DataSource = situacoes.ToList();
            ddlSituacao.DataTextField = "Descricao";
            ddlSituacao.DataValueField = "ID";
            ddlSituacao.DataBind();
        }


        private void Inicializar()
        {
            if (Request.QueryString.AllKeys.Contains("id"))
            {
                RESULT_idHidden.Value = Request.QueryString["id"] == "0"
                                        ? ""
                                        : Request.QueryString["id"];
            }

        }


        protected void Page_Init(object sender, EventArgs e)
        {
            lkbSalvar.Click += lkbSalvar_Click;
        }


        void lkbSalvar_Click(object sender, EventArgs e)
        {

            try
            {

                bool Atualiza = (RESULT_idHidden.Value.Length > 0)
                                                    ? true
                                                    : false;


                ServiceReference1.Cliente cliente = new ServiceReference1.Cliente();

                if (Atualiza)
                {

                    cliente = servico.GetCliente(Convert.ToInt32(RESULT_idHidden.Value));

                    cliente.ID = cliente.ID;
                    cliente.Nome = tbNome.Text;
                    cliente.CPF = tbCpf.Text;
                    cliente.TipoID = int.Parse(ddlTipo.SelectedValue);
                    cliente.SituacaoID = int.Parse(ddlSituacao.SelectedValue);
                    cliente.Sexo = char.Parse(rbSexo.SelectedValue.ToString());

                    servico.UpdateCliente(cliente);
                }
                else
                {

                    cliente.Nome = tbNome.Text;
                    cliente.CPF = tbCpf.Text;
                    cliente.TipoID = int.Parse(ddlTipo.SelectedValue);
                    cliente.SituacaoID = int.Parse(ddlSituacao.SelectedValue);
                    cliente.Sexo = char.Parse(rbSexo.SelectedValue.ToString());

                    servico.CreateCliente(cliente);

                }              


                Response.Redirect("Clientes.aspx");

            }
            catch (Exception ex)
            {
                phMensagem.Visible = true;
                litMensagem.Text = ex.Message;
            }
        }


        protected void rbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}