using System.Runtime.Serialization;

namespace GestaoClientes.Api.Models
{

    [DataContract]
    public class ClienteSituacao
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Descricao { get; set; }
    }
}
