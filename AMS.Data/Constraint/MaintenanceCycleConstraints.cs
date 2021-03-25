using AMS.Core.Constant;
using AMS.Data.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMS.Data.Constraint
{
    public class MaintenanceCycleConstraints : IEntityTypeConfiguration<MaintenanceCycleDbEntity>
    {
        public void Configure(EntityTypeBuilder<MaintenanceCycleDbEntity> builder)
        {
            builder.ToTable(DbTablesName.MaintenanceCycleTable);

            builder.Property(x => x.VisitAt).IsRequired();
            builder.Property(x => x.Service).HasMaxLength(100);

            builder.HasMany(x => x.MaintenanceTeam).WithMany(x => x.MaintenanceCycles);
            builder.HasMany(x => x.SpareParts);

            builder.HasOne(x => x.MaintenanceContract).WithMany(x => x.MaintenanceCycles).OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}