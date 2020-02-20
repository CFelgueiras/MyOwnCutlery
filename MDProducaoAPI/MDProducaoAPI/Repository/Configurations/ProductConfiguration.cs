using MDProducaoAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDProducaoAPI.Repository
{
    public class ProductConfiguration : EntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.OwnsOne(p => p.Name, pn =>
            {
                pn.Property(p => p.name).HasMaxLength(300)
                    .HasColumnName("ProductName")
                    .HasDefaultValue("");
            });

            base.Configure(builder);
        }
    }
}