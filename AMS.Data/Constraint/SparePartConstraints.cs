using AMS.Core.Constant;
using AMS.Data.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMS.Data.Constraint
{
    public class SparePartConstraints : IEntityTypeConfiguration<SparePartDbEntity>
    {
        public void Configure(EntityTypeBuilder<SparePartDbEntity> builder)
        {
            
            builder.ToTable(DbTablesName.SparePartTable);
            
            builder.Property(x => x.Name).IsRequired().HasMaxLength(70);
            builder.Property(x => x.PricePerOne).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Quantity).IsRequired().HasMaxLength(5);
            builder.Property(x => x.UnitType).IsRequired();
            builder.Ignore(x => x.TotalPrice);
        }
    }
}