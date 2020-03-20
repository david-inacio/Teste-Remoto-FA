using System.Runtime.Serialization;

namespace GestaoClientes.Api.Models
{

    [DataContract]
    public class ClienteTipo
    {

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Descricao { get; set; }
    }
}
