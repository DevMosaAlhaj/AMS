using AMS.Core.Constant;
using AMS.Data.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMS.Data.Constraint
{
    public class MotorConstraints : IEntityTypeConfiguration<MotorDbEntity>
    {
        public void Configure(EntityTypeBuilder<MotorDbEntity> builder)
        {
            
            builder.ToTable(DbTablesName.MotorTable);
            
            builder.Property(x => x.Address).IsRequired().HasMaxLength(250);
            builder.Property(x => x.MotorType).IsRequired().HasMaxLength(100);
            builder.Property(x => x.MotorModel).IsRequired().HasMaxLength(100);
            builder.Property(x => x.MotorNumber).HasMaxLength(100);
            builder.Property(x => x.MotorPower).HasMaxLength(100);
            builder.Property(x => x.Charger).HasMaxLength(100);
            builder.Property(x => x.EngineType).IsRequired().HasMaxLength(100);
            builder.Property(x => x.EngineModel).HasMaxLength(100);
            builder.Property(x => x.EngineNumber).HasMaxLength(100);
            builder.Property(x => x.PreviousCounterReading).HasMaxLength(100);
            builder.Property(x => x.CurrentCounterReading).HasMaxLength(100);
            builder.Property(x => x.MufflerType).IsRequired();
            builder.Property(x => x.OliCounter).HasMaxLength(4).IsRequired();


            builder.HasMany(x => x.MaintenanceContracts).WithOne(x => x.Motor).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.MaintenanceServices).WithOne(x => x.Motor).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.MaintenanceCycles);
            builder.HasMany(x => x.SparePartsSold).WithOne(x => x.Motor).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.SaleContracts).WithOne(x => x.Motor).OnDelete(DeleteBehavior.Restrict);

            
            builder.HasOne(x => x.Client).WithMany(x => x.Motors).OnDelete(DeleteBehavior.Restrict).HasForeignKey(x=> x.ClientId);
            
            builder.HasQueryFilter(x => !x.IsDeleted);
            
        }
    }
}