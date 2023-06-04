using BitCoio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BitCoio.Data.Mappings
{
    public class CarteiraMap : IEntityTypeConfiguration<Carteira>
    {
        public void Configure(EntityTypeBuilder<Carteira> builder)
        {
            builder.ToTable("Carteiras", "dbo");

            builder.Property(p => p.Id);

            builder.Property(p => p.NomeCarteira).HasMaxLength(100).IsRequired();

            builder.Property(p => p.Valor);
        }
    }
}
