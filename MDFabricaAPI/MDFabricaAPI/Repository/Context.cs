using Microsoft.EntityFrameworkCore;
using MDFabricaAPI.Models;

namespace MDFabricaAPI.Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }

        public DbSet<Operation> Operations { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<MachineType> MachineTypes { get; set; }
        public DbSet<ProductionLine> ProductionLines { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OperationConfiguration());
            modelBuilder.ApplyConfiguration(new MachineConfiguration());
            // modelBuilder.Entity<Machine>()
            // .HasOne(mt => mt.MachineType)
            // .WithMany(m => m.Machines);
            modelBuilder.ApplyConfiguration(new MachineTypeConfiguration());
            modelBuilder.Entity<MachineType>()
            .HasMany(o => o.OperationsList)
            .WithOne(mt => mt.MachineType);
            modelBuilder.ApplyConfiguration(new ProductionLineConfiguration());
            modelBuilder.Entity<ProductionLine>()
            .HasMany(m => m.Machines)
            .WithOne(pl => pl.ProductionLine);
        }
    }
}