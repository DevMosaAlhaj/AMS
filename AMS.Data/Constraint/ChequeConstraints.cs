using AMS.Core.Constant;
using AMS.Data.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMS.Data.Constraint
{
    public class ChequeConstraints : IEntityTypeConfiguration<ChequeDbEntity>
    {
        public void Configure(EntityTypeBuilder<ChequeDbEntity> builder)
        {
            builder.ToTable(DbTablesName.ChequeTable);

            builder.Property(x => x.Amount).IsRequired().HasMaxLength(10);
            builder.Property(x => x.ByBank).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DueAt).IsRequired();
            builder.Property(x => x.Currency).IsRequired().HasMaxLength(15);
            builder.Property(x => x.DebtorName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IsPaid).IsRequired();

            builder.HasOne(x => x.Transaction).WithMany(x => x.Cheques).OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.IsDeleted);

        }
    }
}