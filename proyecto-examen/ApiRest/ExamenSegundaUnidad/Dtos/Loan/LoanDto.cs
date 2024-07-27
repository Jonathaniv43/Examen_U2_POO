namespace ExamenSegundaUnidad.Dtos.New
{
    public class LoanDto
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public double LoanAmount { get; set; }

        public int Commission { get; set; }

        public int InteretRate { get; set; }

        public DateTime DisbursmentDate { get; set; }

        public DateTime FirtsPaymentDate { get; set; }
    }
}
