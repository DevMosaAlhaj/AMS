using AMS.Core.Constant;
using AMS.Data.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMS.Data.Constraint
{
    public class SparePartSoldConstraints : IEntityTypeConfiguration<SparePartSoldDbEntity>
    {
        public void Configure(EntityTypeBuilder<SparePartSoldDbEntity> builder)
        {
            builder.ToTable(DbTablesName.SparePartSoldTable);

            builder.Property(x => x.SaleAt).IsRequired();

            builder.HasMany(x => x.SalesStaff).WithMany(x => x.SparePartsSold);
            builder.HasMany(x => x.SpareParts);
            
            builder.HasOne(x => x.Client).WithMany(x => x.SparePartsSold).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Motor).WithMany(x => x.SparePartsSold).OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}