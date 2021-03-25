using AMS.Core.Constant;
using AMS.Data.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMS.Data.Constraint
{
    public class MaintenanceContractConstraints : IEntityTypeConfiguration<MaintenanceContractDbEntity>
    {
        public void Configure(EntityTypeBuilder<MaintenanceContractDbEntity> builder)
        {

            builder.ToTable(DbTablesName.MaintenanceContractTable);
            
            builder.Property(x => x.ContractDate).IsRequired();
            builder.Property(x => x.ContractEndDate).IsRequired();
            builder.Property(x => x.ContractStartDate).IsRequired();
            builder.Ignore(x => x.ContractDuration);

            builder.HasMany(x => x.MaintenanceCycles).WithOne(x => x.MaintenanceContract).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Client).WithMany(x => x.MaintenanceContracts).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Motor).WithMany(x => x.MaintenanceContracts).OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}