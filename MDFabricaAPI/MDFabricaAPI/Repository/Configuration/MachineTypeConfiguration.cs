using MDFabricaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDFabricaAPI.Repository
{
    public class MachineTypeConfiguration : EntityConfiguration<MachineType>
    {
        public override void Configure(EntityTypeBuilder<MachineType> builder)
        {
            builder.OwnsOne(mt => mt.Name, on =>
            {
                on.Property(mt => mt.name).HasMaxLength(300)
                    .HasColumnName("MachineTypeName")
                    .HasDefaultValue("");
            });

            base.Configure(builder);
        }
    }
}