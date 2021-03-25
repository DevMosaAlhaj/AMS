using AMS.Core.Constant;
using AMS.Data.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMS.Data.Constraint
{
    public class TransactionConstraints : IEntityTypeConfiguration<TransactionDbEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionDbEntity> builder)
        {
            builder.ToTable(DbTablesName.TransactionTable);

            builder.Property(x => x.CashAmount).IsRequired().HasMaxLength(7);
            builder.Property(x => x.TotalPrice).IsRequired().HasMaxLength(7);
            builder.Property(x => x.CashCurrency).IsRequired().HasMaxLength(15);
            builder.Ignore(x => x.RemainingAmount);

            builder.HasOne(x => x.SaleContract).WithOne(x => x.Transaction)
                .HasForeignKey<TransactionDbEntity>( x=> x.SaleContractId).OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(x => x.Cheques).WithOne(x => x.Transaction).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.ExchangeBills).WithOne(x => x.Transaction).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.AccessoryFiles).WithOne(x => x.Transaction).OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.IsDeleted);

        }
    }
}