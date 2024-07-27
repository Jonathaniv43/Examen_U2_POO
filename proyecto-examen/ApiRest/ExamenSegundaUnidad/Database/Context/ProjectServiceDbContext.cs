using ExamenSegundaUnidad.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace ExamenSegundaUnidad.Database.Context
{
    public class ProjectServiceDbContext : DbContext
    {
        public ProjectServiceDbContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<LoanEntity> Loans { get; set; }
        public DbSet<AmortizationDataEntity> AmortizationData { get; set; }
    }
}
