using BitCoio.Entities;
using Microsoft.EntityFrameworkCore;

namespace BitCoio.Data
{
    public class CorretoraContext : DbContext
    {
        public DbSet<Carteira> Carteiras { get; set; }

        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost,1433;Database=BancoCorretora;User ID=sa;Password=PassWord!;Trusted_Connection=False; TrustServerCertificate=True;");
    }

}

