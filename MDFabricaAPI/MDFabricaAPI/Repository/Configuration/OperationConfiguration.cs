using MDFabricaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDFabricaAPI.Repository
{
    public class OperationConfiguration : EntityConfiguration<Operation>
    {
        public override void Configure(EntityTypeBuilder<Operation> builder)
        {

            builder.HasKey(o => o.OperationId);
            
            
            builder.OwnsOne(o => o.Name, on =>
            {
                on.Property(o => o.name).HasMaxLength(300)
                    .HasColumnName("OperationName")
                    .HasDefaultValue("");
            });
            builder.OwnsOne(t => t.ToolName, ot =>
            {
                ot.Property(t => t.toolName).HasMaxLength(300)
                    .HasColumnName("ToolName")
                    .HasDefaultValue("");
            });
            
            builder.OwnsOne(t => t.OperationTool, ot =>
            {
                ot.Property(t => t.operationTool).HasMaxLength(300)
                    .HasColumnName("OperationTool")
                    .HasDefaultValue("");
            });


            base.Configure(builder);
        }
    }
}