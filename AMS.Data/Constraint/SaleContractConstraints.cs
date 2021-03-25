using AMS.Core.Constant;
using AMS.Data.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMS.Data.Constraint
{
    public class SaleContractConstraints : IEntityTypeConfiguration<SaleContractDbEntity>
    {
        public void Configure(EntityTypeBuilder<SaleContractDbEntity> builder)
        {
            builder.ToTable(DbTablesName.SaleContractTable);

            builder.Property(x => x.Price).IsRequired().HasMaxLength(7);
            builder.Property(x => x.AccessoryServices).HasMaxLength(150);

            builder.HasOne(x => x.Client).WithMany(x => x.SaleContracts).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Motor).WithMany(x => x.SaleContracts).OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(x => x.Transaction).WithOne(x => x.SaleContract)
                .HasForeignKey<SaleContractDbEntity>(x=> x.TransactionId).OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(x => x.AccessorySpareParts);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}