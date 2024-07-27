using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenSegundaUnidad.Database.Entity
{
    [Table("loans", Schema = "dbo")]
    public class LoanEntity
    {
        [Key]
        [Column  ("loan_id")]
        public Guid LoanId { get; set; }
        [Column("client_name")]
        public string Name { get; set; }
        [Column("client_id")]
        public Guid ClientId { get; set; }
        [Column("loan_amount")]
        public bool LoanAmount { get; set; }
        [Column("commision")]
        public int Commission { get; set; }
        [Column("interes_rate")]
        public int InteretRate { get; set; }
        [Column("disbursment_date")]
        public DateTime DisbursmentDate { get; set; }
        [Column("payment_date")]
        public DateTime FirtsPaymentDate    { get; set; }

        public virtual IEnumerable<AmortizationDataEntity> Amortizations { get; set; }

    }
}
