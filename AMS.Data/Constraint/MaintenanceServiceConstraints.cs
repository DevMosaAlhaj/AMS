using AMS.Core.Constant;
using AMS.Data.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMS.Data.Constraint
{
    public class MaintenanceServiceConstraints : IEntityTypeConfiguration<MaintenanceServiceDbEntity>
    {
        public void Configure(EntityTypeBuilder<MaintenanceServiceDbEntity> builder)
        {
            builder.ToTable(DbTablesName.MaintenanceServiceTable);

            builder.Property(x => x.EntryAt).IsRequired();
            builder.Property(x => x.TransportDescription).HasMaxLength(100);
            builder.Property(x => x.ExitNotes).HasMaxLength(200);
            
            builder.HasOne(x => x.WorkshopOfficial).WithMany(x => x.MaintenanceServices).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Client).WithMany(x => x.MaintenanceServices).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Motor).WithMany(x => x.MaintenanceServices).OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(x => x.PriceOffer).WithOne(x => x.MaintenanceService)
                .HasForeignKey<MaintenanceServiceDbEntity>(x=> x.PriceOfferId).OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.IsDeleted);

        }
    }
}