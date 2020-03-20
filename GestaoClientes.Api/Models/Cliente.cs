using System.Runtime.Serialization;

namespace GestaoClientes.Api.Models
{

    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string CPF { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public int TipoID { get; set; }

        [DataMember]
        public char Sexo { get; set; }

        [DataMember]
        public int SituacaoID { get; set; }
    }
}
