using AULA13.Domains;
using AULA13.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace AULA13.Models.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts)
            :base(opts)
        {}

        public DbSet<Client> Clients { get; set; } 
        public DbSet<Cobranca> Cobrancas { get; set; }
    }
}