using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenSegundaUnidad.Database.Entity
{
    public class ClientEntity
    {
        [Column("client_id")]
        public Guid ClientId { get; set; }

    }
}
