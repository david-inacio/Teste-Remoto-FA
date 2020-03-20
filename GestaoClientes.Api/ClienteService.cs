using GestaoClientes.Api.Models;
using System.Collections.Generic;

namespace GestaoClientes.Api
{
    public class ClienteService : IClienteService
    {

        List<Cliente> IClienteService.GetClientes()
        {
            ClienteDao dao = new ClienteDao();
            return dao.GetClientes();
        }

        List<ClienteSituacao> IClienteService.GetClienteSituacoes()
        {
            ClienteDao dao = new ClienteDao();
            return dao.GetClienteSituacoes();
        }

        List<ClienteTipo> IClienteService.GetClienteTipos()
        {
            ClienteDao dao = new ClienteDao();
            return dao.GetClienteTipos();
        }

        void IClienteService.CreateCliente(Cliente cliente)
        {
            ClienteDao dao = new ClienteDao();
            dao.Create(cliente);
        }

        Cliente IClienteService.GetCliente(int id)
        {
            ClienteDao dao = new ClienteDao();
            return dao.GetCliente(id);
        }

        void IClienteService.UpdateCliente(Cliente cliente)
        {
            ClienteDao dao = new ClienteDao();
            dao.Update(cliente);
        }

        void IClienteService.DeleteCliente(int id)
        {
            ClienteDao dao = new ClienteDao();
            dao.Delete(id);
        }
    }
}
