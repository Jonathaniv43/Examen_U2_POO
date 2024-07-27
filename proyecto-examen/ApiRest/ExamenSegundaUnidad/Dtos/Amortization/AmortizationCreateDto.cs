namespace ExamenSegundaUnidad.Dtos.Amortization
{
    public class AmortizatioDto 
    {
        public string Name { get; set; }

        public double LoanAmount { get; set; }

        public int Commission { get; set; }

        public int InteretRate { get; set; }

        public DateTime DisbursmentDate { get; set; }

        public DateTime FirtsPaymentDate { get; set; }
    }
}
