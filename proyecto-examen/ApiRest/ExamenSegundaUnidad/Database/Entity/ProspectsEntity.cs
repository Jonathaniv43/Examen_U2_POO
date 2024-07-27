using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenSegundaUnidad.Database.Entity
{
    [Table("prospects", Schema = "dbo")]
    public class ProspectsEntity
    {
        [Key]
        public Guid Id { get; set; }


        [Column("identity_number")]
        public int Identity_Number { get; set; }

        [Column("client_name")]
        public string ClientName { get; set; }
        [Column  ("loan_id")]
        
        public Guid LoanId { get; set; }
        [Column("loan_amount")]
        
        public double LoanAmount { get; set; }
        [Column("term")]
        public int Term { get; set; }
        [Column("commision")]
        public int Commission { get; set; }
        [Column("interes_rate")]
        public int InterestRate { get; set; }
        [Column("disbursment_date")]
        public DateTime DisbursmentDate { get; set; }
        [Column("payment_date")]
        public DateTime FirstPaymentDate    { get; set; }

        public virtual IEnumerable<AmortizationDataEntity> AmortizationDataEntities { get; set; }

    }
}
