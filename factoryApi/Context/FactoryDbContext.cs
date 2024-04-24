using Microsoft.EntityFrameworkCore;
using factoryApi.Model;

namespace factoryApi.Context

{
    public class FactoryDbContext : DbContext
    {
        public FactoryDbContext(DbContextOptions<FactoryDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Filter registers with isDeleted = false
            modelBuilder.Entity<Provider>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ProductStatus>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<RegistrationAction>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<FlowRecord>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ProductionCapacity>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ProductionLine>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<RawMaterial>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<RawMaterialProduct>().HasQueryFilter(p => !p.IsDeleted);


        }

        public DbSet<Provider> Providers { get; set; } //Proveedor
        public DbSet<Product> Products { get; set; } //Producto
        public DbSet<ProductStatus> ProductStatuses { get; set; } //EstadoProducto
        public DbSet<RegistrationAction> RegistrationActions { get; set; } //AccionRegistro
        public DbSet<FlowRecord> FlowRecords { get; set; } //RegistroFlujo
        public DbSet<ProductionCapacity> ProductionCapacities { get; set; } //CapacidadProduccion
        public DbSet<ProductionLine> ProductionLines { get; set; } //LineaProduccion
        public DbSet<RawMaterial> RawMaterials { get; set; } //MateriaPrima
        public DbSet<RawMaterialProduct> RawMaterialProducts { get; set; } //MateriaPrimaProducto

    }
}
