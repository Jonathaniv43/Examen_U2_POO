using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenSegundaUnidad.Dtos.New
{
    public class ProspectDto
    {

        public int Identity_Number { get; set; }

     
        public string ClientName { get; set; }


        public Guid LoanId { get; set; }


        public double LoanAmount { get; set; }

        public int Term { get; set; }

        public int Commission { get; set; }
 
        public int InterestRate { get; set; }
       
        public DateTime DisbursmentDate { get; set; }
  
        public DateTime FirstPaymentDate { get; set; }

    }
}
