using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDFabricaAPI.Repository
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            //builder.Property(m => m.DateCreated).HasColumnType(DataConstants.SqlServer.DateTime2).HasDefaultValueSql(DataConstants.SqlServer.SysDateTime);
            //builder.Property(p => p.DateUpdated).HasColumnType(DataConstants.SqlServer.DateTime2);
        }
    }
}