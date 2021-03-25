using AMS.Core.Constant;
using AMS.Data.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMS.Data.Constraint
{
    public class ExchangeBillConstraints : IEntityTypeConfiguration<ExchangeBillDbEntity>
    {
        public void Configure(EntityTypeBuilder<ExchangeBillDbEntity> builder)
        {
            builder.ToTable(DbTablesName.ExchangeBillTable);

            builder.Property(x => x.Amount).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Currency).IsRequired().HasMaxLength(15);
            builder.Property(x => x.DebtorName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DueAt).IsRequired();
            builder.Property(x => x.WritingAt).IsRequired();
            builder.Property(x => x.IsPaid).IsRequired();

            builder.HasOne(x => x.Transaction).WithMany(x => x.ExchangeBills).OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.IsDeleted);

        }
    }
}