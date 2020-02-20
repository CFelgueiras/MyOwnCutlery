using MDFabricaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDFabricaAPI.Repository
{
    public class ProductionLineConfiguration : EntityConfiguration<ProductionLine>
    {
        public override void Configure(EntityTypeBuilder<ProductionLine> builder)
        {
            builder.OwnsOne(pl => pl.Name, on =>
            {
                on.Property(pl => pl.name).HasMaxLength(300)
                    .HasColumnName("ProdLineName")
                    .HasDefaultValue("");
            });
            base.Configure(builder);
        }
    }
}