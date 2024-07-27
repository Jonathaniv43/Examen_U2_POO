using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenSegundaUnidad.Database.Entity
{
    public class ClientEntity
    {
        [Key]
      
        [Column("client_id")]
        public Guid ClientId { get; set; }

        [Column("client_name")]
        public string ClientName { get; set; }

    }
}
