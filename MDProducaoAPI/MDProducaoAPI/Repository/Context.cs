using Microsoft.EntityFrameworkCore;
using MDProducaoAPI.Models;

namespace MDProducaoAPI.Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ManufacturingPlan> ManufacturingPlans { get; set; }
        public DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ManufacturingPlanConfiguration());
            modelBuilder.ApplyConfiguration(new OperationConfiguration());
            modelBuilder.Entity<ManufacturingPlan>()
            .HasOne(p => p.Product)
            .WithOne(mp => mp.ManPlan)
            .HasForeignKey<Product>(mp => mp.ManPlanId);
        }
    }
}