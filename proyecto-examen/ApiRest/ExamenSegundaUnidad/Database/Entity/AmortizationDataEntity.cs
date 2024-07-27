using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenSegundaUnidad.Database.Entity
{
    [Table ("amortization", Schema = "dbo")]
    public class AmortizationDataEntity
    {
        [Key]
        [Column("amortization_id")]
        public Guid AmortizationId { get; set; }
        [Column("loan_id")]
        public Guid LoanId { get; set; }
        [ForeignKey(nameof(LoanId))]
        
        public LoanEntity Loan  { get; set; }

        [Column("installment_number")]
        public int InstallmentNumber { get; set; }
        [Column("payment_date")]
        public DateTime PaymentDate { get; set; }
        [Column("days")]
        public int Days {  get; set; }
        [Column("interes_date")]
        public double Interest {  get; set; }
        [Column("lv_payment_Svds")]
        public double LvPaymentSVSD { get; set; }
        [Column("lv_payment_no_Svds")]
        public double LvPaymentNoSVSD { get; set; }
        [Column("principal_balance")]
        public double PrincipalBalance { get; set; }



    }
}
