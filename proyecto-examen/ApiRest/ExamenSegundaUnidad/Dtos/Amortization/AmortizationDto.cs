namespace ExamenSegundaUnidad.Dtos.Amortization
{
    public class AmortizationDto
    {
        public string Name { get; set; }
        public Guid AmortizationId { get; set; }

        public double LoanAmount { get; set; }

        public int Commission { get; set; }

        public int InteretRate { get; set; }

        public DateTime DisbursmentDate { get; set; }

        public DateTime FirtsPaymentDate { get; set; }
    }
}
