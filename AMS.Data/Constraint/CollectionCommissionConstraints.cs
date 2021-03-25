using AMS.Core.Constant;
using AMS.Data.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMS.Data.Constraint
{
    public class CollectionCommissionConstraints : IEntityTypeConfiguration<CollectionCommissionDbEntity>
    {
        public void Configure(EntityTypeBuilder<CollectionCommissionDbEntity> builder)
        {
            builder.ToTable(DbTablesName.CollectionCommissionTable);


            builder.Property(x => x.CollectedAt).IsRequired();
            builder.Property(x => x.CommissionAmount).HasMaxLength(7).IsRequired();
            builder.Property(x => x.CommissionCurrency).HasMaxLength(15).IsRequired();

            builder.HasOne(x => x.CollectedByEmp)
                .WithMany(x => x.CollectionCommissions).OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.IsDeleted);

        }
    }
}