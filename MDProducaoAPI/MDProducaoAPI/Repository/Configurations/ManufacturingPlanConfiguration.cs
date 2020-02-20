using MDProducaoAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDProducaoAPI.Repository
{
    public class ManufacturingPlanConfiguration : EntityConfiguration<ManufacturingPlan>
    {
        public override void Configure(EntityTypeBuilder<ManufacturingPlan> builder)
        {
            builder.OwnsOne(mp => mp.Name, pn =>
            {
                pn.Property(p => p.name).HasMaxLength(300)
                    .HasColumnName("PlanName")
                    .HasDefaultValue("");
            });

            base.Configure(builder);
        }
    }
}