using ExamenSegundaUnidad.Database.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenSegundaUnidad.Dtos.Amortization
{
    public class AmortizationDto
    {

     
        public int InstallmentNumber { get; set; }

    
        public Guid LoanId { get; set; }
    

        public DateTime PaymentDate { get; set; }

        public int Days { get; set; }

        public double Interest { get; set; }

        public double Installment { get; set; }
 
        public double LifeInsuranceOverDebt { get; set; }

        public double LvPayment_Linsurance { get; set; }

        public double LvPaymentNoLinsurance { get; set; }
 
        public double PrincipalBalance { get; set; }
    }
}
