using GestaoClientes.Api.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace GestaoClientes.Api
{

    [ServiceContract]
    public interface IClienteService
    {

        [OperationContract]
        List<Cliente> GetClientes();

        [OperationContract]
        List<ClienteSituacao> GetClienteSituacoes();

        [OperationContract]
        List<ClienteTipo> GetClienteTipos();

        [OperationContract]
        void CreateCliente(Cliente cliente);

        [OperationContract]
        Cliente GetCliente(int id);

        [OperationContract]
        void UpdateCliente(Cliente cliente);

        [OperationContract]
        void DeleteCliente(int id);

    }
}
