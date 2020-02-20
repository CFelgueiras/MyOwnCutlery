using MDFabricaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDFabricaAPI.Repository
{
    public class MachineConfiguration : EntityConfiguration<Machine>
    {
        public override void Configure(EntityTypeBuilder<Machine> builder)
        {

            builder.HasKey(o => o.MachineId);
            
            
            builder.OwnsOne(o => o.Identification, on =>
            {
                on.Property(o => o.identification).HasMaxLength(300)
                    .HasColumnName("Identification")
                    .HasDefaultValue("");
            });
            builder.OwnsOne(t => t.Brand, ot =>
            {
                ot.Property(t => t.brand).HasMaxLength(300)
                    .HasColumnName("Brand")
                    .HasDefaultValue("");
            });
            
            builder.OwnsOne(t => t.Model, ot =>
            {
                ot.Property(t => t.model).HasMaxLength(300)
                    .HasColumnName("Model")
                    .HasDefaultValue("");
            });

            builder.OwnsOne(t => t.Localization, ot =>
            {
                ot.Property(t => t.localization).HasMaxLength(300)
                    .HasColumnName("Localization")
                    .HasDefaultValue("");
            });

            builder.OwnsOne(t => t.Capacity, ot =>
            {
                ot.Property(t => t.capacity)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("Capacity")
                    .HasDefaultValue("0");
            });

            base.Configure(builder);
        }
    }
}