using BitCoio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BitCoio.Data.Mappings
{
    public class TransacaoMap : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacoes", "dbo");

            builder.Property(p => p.Id);

            builder.Property(p => p.Data);

            builder.Property(p => p.Valor);

            builder.Property(p => p.Descricao);

            builder.Property(p => p.CarteiraEnvioId);

            builder.Property(p => p.CarteiraRecebimentoId);

            builder.HasOne(t => t.CarteiraEnvio)
                   .WithMany()
                   .HasForeignKey(f => f.CarteiraEnvioId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("transacao_fk01");

            builder.HasOne(t => t.CarteiraRecebimento)
                   .WithMany()
                   .HasForeignKey(f => f.CarteiraRecebimentoId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("transacao_fk02");
        }
    }
}
