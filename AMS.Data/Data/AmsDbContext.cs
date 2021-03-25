using AMS.Data.DbEntity;
using AMS.Data.Extension;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AMS.Data.Data
{
    public class AmsDbContext : IdentityDbContext<UserDbEntity>
    {

        public AmsDbContext(DbContextOptions<AmsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConstrains();
        }

        public DbSet<ClientDbEntity> Clients { get; set; }
        
        public DbSet<ChequeDbEntity> Cheques { get; set; }
        
        public DbSet<CollectionCommissionDbEntity> CollectionCommissions { get; set; }
        
        
        public DbSet<EmployeeDbEntity> Employees { get; set; }
        
        public DbSet<ExchangeBillDbEntity> ExchangeBills { get; set; }
        
        
        public DbSet<FileDbEntity> Files { get; set; }
        
        
        public DbSet<MaintenanceContractDbEntity> MaintenanceContracts { get; set; }
        
        public DbSet<MaintenanceCycleDbEntity> MaintenanceCycles { get; set; }
        
        public DbSet<MaintenanceServiceDbEntity> MaintenanceServices { get; set; }
        
        public DbSet<MotorDbEntity> Motors { get; set; }
        
        
        public DbSet<PriceOfferDbEntity> PriceOffers { get; set; }
        
        
        public DbSet<SaleContractDbEntity> SaleContracts { get; set; }
        
        public DbSet<SparePartDbEntity> SpareParts { get; set; }
        
        public DbSet<SparePartSoldDbEntity> SparePartsSold { get; set; }
        
        
        public DbSet<TransactionDbEntity> Transactions { get; set; }
        
    }
}
