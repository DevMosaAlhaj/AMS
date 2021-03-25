using AMS.Core.Constant;
using AMS.Data.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMS.Data.Constraint
{
    public class EmployeeConstraints : IEntityTypeConfiguration<EmployeeDbEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeDbEntity> builder)
        {

            builder.ToTable(DbTablesName.EmployeeTable);
            
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Address).HasMaxLength(150);
            builder.Property(x => x.IdentityNo).HasMaxLength(9);
            builder.Property(x => x.JobName).HasMaxLength(70);
            builder.Property(x => x.PhoneNumber).HasMaxLength(15);


            builder.HasMany(x => x.MaintenanceCycles)
                .WithMany(x => x.MaintenanceTeam);
            builder.HasMany(x => x.MaintenanceServices)
                .WithOne(x => x.WorkshopOfficial).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.SparePartsSold)
                .WithMany(x => x.SalesStaff);
            builder.HasMany(x => x.CollectionCommissions)
                .WithOne(x => x.CollectedByEmp).OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}